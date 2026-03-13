using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ObuvApp
{
    public partial class ProductsForm : Form
    {
        private readonly User _currentUser; // null = guest
        private List<Product> _allProducts = new List<Product>();

        public ProductsForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
            SetupFormForRole();
            LoadProducts();
        }

        // Show/hide controls based on role
        private void SetupFormForRole()
        {
            bool isGuest = _currentUser == null;
            bool isManager = !isGuest && _currentUser.RoleName == "Менеджер";
            bool isAdmin = !isGuest && _currentUser.RoleName == "Администратор";

            // Title
            this.Text = "Список товаров — ООО Обувь";

            // Show user name in top right
            if (!isGuest)
                lblUserName.Text = _currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            // Search, filter, sort — only for manager and admin
            pnlFilters.Visible = isManager || isAdmin;

            // Add/Edit/Delete buttons — only for admin
            btnAddProduct.Visible = isAdmin;
            btnDeleteProduct.Visible = isAdmin;

            // Orders button — manager and admin
            btnOrders.Visible = isManager || isAdmin;
        }

        // Load products from database
        private void LoadProducts()
        {
            _allProducts.Clear();

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT p.product_id, p.product_name, c.category_name,
                               p.description, m.manufacturer_name, s.supplier_name,
                               p.price, u.unit_name, p.stock_quantity, p.discount, p.image_path
                        FROM products p
                        INNER JOIN categories c    ON p.category_id     = c.category_id
                        INNER JOIN manufacturers m ON p.manufacturer_id = m.manufacturer_id
                        INNER JOIN suppliers s     ON p.supplier_id     = s.supplier_id
                        INNER JOIN units u         ON p.unit_id         = u.unit_id
                        ORDER BY p.product_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _allProducts.Add(new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                CategoryName = reader.GetString(2),
                                Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                ManufacturerName = reader.GetString(4),
                                SupplierName = reader.GetString(5),
                                Price = reader.GetDecimal(6),
                                UnitName = reader.GetString(7),
                                StockQuantity = reader.GetInt32(8),
                                Discount = reader.GetDecimal(9),
                                ImagePath = reader.IsDBNull(10) ? null : reader.GetString(10)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка загрузки товаров:\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            LoadSupplierFilter();
            ApplyFilters();
        }

        // Populate supplier dropdown
        private void LoadSupplierFilter()
        {
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("Все поставщики");
            HashSet<string> added = new HashSet<string>();
            foreach (var p in _allProducts)
            {
                if (!added.Contains(p.SupplierName))
                {
                    cmbSupplier.Items.Add(p.SupplierName);
                    added.Add(p.SupplierName);
                }
            }
            cmbSupplier.SelectedIndex = 0;
        }

        // Apply search + filter + sort in real time
        private void ApplyFilters()
        {
            string search = txtSearch.Text.Trim().ToLower();
            string supplier = cmbSupplier.SelectedItem?.ToString() ?? "Все поставщики";
            bool sortAsc = rdoSortAsc.Checked;
            bool sortDesc = rdoSortDesc.Checked;

            List<Product> filtered = new List<Product>();

            foreach (var p in _allProducts)
            {
                // Filter by supplier
                if (supplier != "Все поставщики" && p.SupplierName != supplier)
                    continue;

                // Search across all text fields
                if (!string.IsNullOrEmpty(search))
                {
                    bool match =
                        p.ProductName.ToLower().Contains(search) ||
                        p.CategoryName.ToLower().Contains(search) ||
                        p.Description.ToLower().Contains(search) ||
                        p.ManufacturerName.ToLower().Contains(search) ||
                        p.SupplierName.ToLower().Contains(search) ||
                        p.UnitName.ToLower().Contains(search);

                    if (!match) continue;
                }

                filtered.Add(p);
            }

            // Sort by stock quantity
            if (sortAsc)
                filtered.Sort((a, b) => a.StockQuantity.CompareTo(b.StockQuantity));
            else if (sortDesc)
                filtered.Sort((a, b) => b.StockQuantity.CompareTo(a.StockQuantity));

            DisplayProducts(filtered);
        }

        // Render products into DataGridView with color coding
        private void DisplayProducts(List<Product> products)
        {
            dgvProducts.Rows.Clear();

            foreach (var p in products)
            {
                string priceDisplay = p.Discount > 0
                    ? $"{p.Price:F2} → {p.FinalPrice:F2}"
                    : $"{p.Price:F2}";

                int rowIndex = dgvProducts.Rows.Add(
                    p.ProductId,
                    p.ProductName,
                    p.CategoryName,
                    p.Description,
                    p.ManufacturerName,
                    p.SupplierName,
                    priceDisplay,
                    p.UnitName,
                    p.StockQuantity,
                    $"{p.Discount}%"
                );

                DataGridViewRow row = dgvProducts.Rows[rowIndex];

                // Color coding per assignment rules
                if (p.StockQuantity == 0)
                {
                    // Out of stock — light blue
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (p.Discount > 15)
                {
                    // Discount > 15% — green #2E8B57
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E8B57");
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        // Real-time search
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilters();

        // Real-time filter
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();

        // Real-time sort
        private void rdoSort_CheckedChanged(object sender, EventArgs e) => ApplyFilters();

        // Back to login
        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // Open orders form — manager and admin only
        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm(_currentUser);
            ordersForm.ShowDialog();
        }

        // Add product — admin only
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductEditForm editForm = new ProductEditForm(null);
            editForm.FormClosed += (s, args) => LoadProducts();
            editForm.ShowDialog();
        }

        // Edit product on row click — admin only
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentUser == null || _currentUser.RoleName != "Администратор") return;
            if (e.RowIndex < 0) return;

            int productId = (int)dgvProducts.Rows[e.RowIndex].Cells["colId"].Value;
            Product selected = _allProducts.Find(p => p.ProductId == productId);

            ProductEditForm editForm = new ProductEditForm(selected);
            editForm.FormClosed += (s, args) => LoadProducts();
            editForm.ShowDialog();
        }

        // Delete product — admin only
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите товар для удаления.",
                    "Удаление товара",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int productId = (int)dgvProducts.SelectedRows[0].Cells["colId"].Value;

            // Warn user before irreversible delete
            DialogResult confirm = MessageBox.Show(
                "Вы уверены, что хотите удалить этот товар? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();

                    // Check if product is in any order
                    string checkQuery = "SELECT COUNT(*) FROM order_items WHERE product_id = @id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", productId);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Невозможно удалить товар, так как он присутствует в одном или нескольких заказах.",
                                "Удаление запрещено",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string deleteQuery = "DELETE FROM products WHERE product_id = @id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", productId);
                        deleteCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Товар успешно удалён.",
                    "Удаление товара",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при удалении товара:\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}