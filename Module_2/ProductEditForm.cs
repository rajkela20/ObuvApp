using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ObuvApp
{
    public partial class ProductEditForm : Form
    {
        private readonly Product _product; // null = adding new product
        private static bool _isOpen = false; // prevent multiple edit windows
        private string _newImagePath = null;

        public ProductEditForm(Product product)
        {
            // Only one edit window allowed at a time
            if (_isOpen)
            {
                MessageBox.Show(
                    "Окно редактирования уже открыто. Закройте его перед открытием нового.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }

            _isOpen = true;
            _product = product;
            InitializeComponent();

            this.Text = product == null ? "Добавить товар" : "Редактировать товар";
            LoadDropdowns();

            if (product != null)
                FillFields(product);
        }

        // Fill fields when editing existing product
        private void FillFields(Product p)
        {
            txtName.Text        = p.ProductName;
            txtDescription.Text = p.Description;
            txtPrice.Text       = p.Price.ToString("F2");
            txtStock.Text       = p.StockQuantity.ToString();
            txtDiscount.Text    = p.Discount.ToString("F2");
            lblId.Text          = $"ID: {p.ProductId}";

            // Select correct category
            for (int i = 0; i < cmbCategory.Items.Count; i++)
                if (cmbCategory.Items[i].ToString() == p.CategoryName)
                    cmbCategory.SelectedIndex = i;

            // Select correct manufacturer
            for (int i = 0; i < cmbManufacturer.Items.Count; i++)
                if (cmbManufacturer.Items[i].ToString() == p.ManufacturerName)
                    cmbManufacturer.SelectedIndex = i;

            // Select correct supplier
            for (int i = 0; i < cmbSupplier.Items.Count; i++)
                if (cmbSupplier.Items[i].ToString() == p.SupplierName)
                    cmbSupplier.SelectedIndex = i;

            // Show image
            LoadProductImage(p.ImagePath);
        }

        // Load categories, manufacturers, suppliers from DB
        private void LoadDropdowns()
        {
            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();

                    FillCombo(conn, cmbCategory,     "SELECT category_name FROM categories ORDER BY category_name");
                    FillCombo(conn, cmbManufacturer, "SELECT manufacturer_name FROM manufacturers ORDER BY manufacturer_name");
                    FillCombo(conn, cmbSupplier,     "SELECT supplier_name FROM suppliers ORDER BY supplier_name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCombo(SqlConnection conn, ComboBox cmb, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    cmb.Items.Add(reader.GetString(0));
            }
            if (cmb.Items.Count > 0)
                cmb.SelectedIndex = 0;
        }

        // Choose image button
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title  = "Выберите фото товара";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                string sourcePath = dlg.FileName;
                string appFolder  = Application.StartupPath;
                string fileName   = Path.GetFileName(sourcePath);
                string destPath   = Path.Combine(appFolder, fileName);

                // Resize to 300x200 and save
                using (Image original = Image.FromFile(sourcePath))
                using (Bitmap resized = new Bitmap(original, new Size(300, 200)))
                {
                    // Delete old image if replacing
                    if (_product != null && !string.IsNullOrEmpty(_product.ImagePath))
                    {
                        string oldPath = Path.Combine(appFolder, _product.ImagePath);
                        if (File.Exists(oldPath)) File.Delete(oldPath);
                    }

                    resized.Save(destPath);
                }

                _newImagePath = fileName;
                LoadProductImage(fileName);
            }
        }

        // Display product image or placeholder
        private void LoadProductImage(string imageName)
        {
            string appFolder = Application.StartupPath;
            string fullPath  = string.IsNullOrEmpty(imageName)
                ? Path.Combine(appFolder, "picture.png")
                : Path.Combine(appFolder, imageName);

            if (File.Exists(fullPath))
                picProduct.Image = Image.FromFile(fullPath);
            else if (File.Exists(Path.Combine(appFolder, "picture.png")))
                picProduct.Image = Image.FromFile(Path.Combine(appFolder, "picture.png"));
        }

        // Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate fields
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование товара.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть неотрицательным числом.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Количество на складе не может быть отрицательным.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Скидка должна быть числом от 0 до 100.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();

                    // Get IDs for selected dropdown values
                    int categoryId     = GetId(conn, "categories",    "category_id",    "category_name",    cmbCategory.SelectedItem.ToString());
                    int manufacturerId = GetId(conn, "manufacturers", "manufacturer_id","manufacturer_name", cmbManufacturer.SelectedItem.ToString());
                    int supplierId     = GetId(conn, "suppliers",     "supplier_id",    "supplier_name",    cmbSupplier.SelectedItem.ToString());
                    int unitId         = GetId(conn, "units",         "unit_id",        "unit_name",        "шт.");

                    string imagePath = _newImagePath ?? _product?.ImagePath;

                    if (_product == null)
                    {
                        // INSERT new product
                        string insertQuery = @"
                            INSERT INTO products
                                (product_name, category_id, description, manufacturer_id,
                                 supplier_id, price, unit_id, stock_quantity, discount, image_path)
                            VALUES
                                (@name, @cat, @desc, @man, @sup, @price, @unit, @stock, @discount, @img)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name",     txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@cat",      categoryId);
                            cmd.Parameters.AddWithValue("@desc",     txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@man",      manufacturerId);
                            cmd.Parameters.AddWithValue("@sup",      supplierId);
                            cmd.Parameters.AddWithValue("@price",    price);
                            cmd.Parameters.AddWithValue("@unit",     unitId);
                            cmd.Parameters.AddWithValue("@stock",    stock);
                            cmd.Parameters.AddWithValue("@discount", discount);
                            cmd.Parameters.AddWithValue("@img",      (object)imagePath ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // UPDATE existing product
                        string updateQuery = @"
                            UPDATE products SET
                                product_name    = @name,
                                category_id     = @cat,
                                description     = @desc,
                                manufacturer_id = @man,
                                supplier_id     = @sup,
                                price           = @price,
                                unit_id         = @unit,
                                stock_quantity  = @stock,
                                discount        = @discount,
                                image_path      = @img
                            WHERE product_id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name",     txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@cat",      categoryId);
                            cmd.Parameters.AddWithValue("@desc",     txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@man",      manufacturerId);
                            cmd.Parameters.AddWithValue("@sup",      supplierId);
                            cmd.Parameters.AddWithValue("@price",    price);
                            cmd.Parameters.AddWithValue("@unit",     unitId);
                            cmd.Parameters.AddWithValue("@stock",    stock);
                            cmd.Parameters.AddWithValue("@discount", discount);
                            cmd.Parameters.AddWithValue("@img",      (object)imagePath ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@id",       _product.ProductId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Товар успешно сохранён.", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetId(SqlConnection conn, string table, string idCol, string nameCol, string value)
        {
            string query = $"SELECT {idCol} FROM {table} WHERE {nameCol} = @val";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@val", value);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void ProductEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _isOpen = false;
        }
    }
}
