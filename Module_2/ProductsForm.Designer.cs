namespace ObuvApp
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.rdoSortAsc = new System.Windows.Forms.RadioButton();
            this.rdoSortDesc = new System.Windows.Forms.RadioButton();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();

            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список товаров — ООО Обувь";

            // lblUserName (top right)
            this.lblUserName.AutoSize = false;
            this.lblUserName.Size = new System.Drawing.Size(300, 30);
            this.lblUserName.Location = new System.Drawing.Point(790, 10);
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // btnBack
            this.btnBack.Text = "← Назад";
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Size = new System.Drawing.Size(90, 30);
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // pnlFilters
            this.pnlFilters.Location = new System.Drawing.Point(0, 50);
            this.pnlFilters.Size = new System.Drawing.Size(1100, 50);
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            // lblSearch
            this.lblSearch.Text = "Поиск:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Size = new System.Drawing.Size(50, 24);
            this.lblSearch.Location = new System.Drawing.Point(10, 13);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Size = new System.Drawing.Size(220, 24);
            this.txtSearch.Location = new System.Drawing.Point(65, 12);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblSupplier
            this.lblSupplier.Text = "Поставщик:";
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplier.Size = new System.Drawing.Size(80, 24);
            this.lblSupplier.Location = new System.Drawing.Point(300, 13);

            // cmbSupplier
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSupplier.Size = new System.Drawing.Size(180, 24);
            this.cmbSupplier.Location = new System.Drawing.Point(385, 12);
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);

            // lblSort
            this.lblSort.Text = "Сортировка по кол-ву:";
            this.lblSort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSort.Size = new System.Drawing.Size(160, 24);
            this.lblSort.Location = new System.Drawing.Point(580, 13);

            // rdoSortAsc
            this.rdoSortAsc.Text = "↑ По возр.";
            this.rdoSortAsc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoSortAsc.Size = new System.Drawing.Size(90, 24);
            this.rdoSortAsc.Location = new System.Drawing.Point(745, 13);
            this.rdoSortAsc.CheckedChanged += new System.EventHandler(this.rdoSort_CheckedChanged);

            // rdoSortDesc
            this.rdoSortDesc.Text = "↓ По убыв.";
            this.rdoSortDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoSortDesc.Size = new System.Drawing.Size(90, 24);
            this.rdoSortDesc.Location = new System.Drawing.Point(840, 13);
            this.rdoSortDesc.CheckedChanged += new System.EventHandler(this.rdoSort_CheckedChanged);

            this.pnlFilters.Controls.Add(this.lblSearch);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.lblSupplier);
            this.pnlFilters.Controls.Add(this.cmbSupplier);
            this.pnlFilters.Controls.Add(this.lblSort);
            this.pnlFilters.Controls.Add(this.rdoSortAsc);
            this.pnlFilters.Controls.Add(this.rdoSortDesc);

            // dgvProducts
            this.dgvProducts.Location = new System.Drawing.Point(0, 110);
            this.dgvProducts.Size = new System.Drawing.Size(1100, 490);
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);

            // Columns
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", Visible = false });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Наименование" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Категория" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colDescription", HeaderText = "Описание" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colManufacturer", HeaderText = "Производитель" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colSupplier", HeaderText = "Поставщик" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Цена (руб.)" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colUnit", HeaderText = "Ед. изм." });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colStock", HeaderText = "Кол-во на складе" });
            this.dgvProducts.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colDiscount", HeaderText = "Скидка" });

            // btnAddProduct
            this.btnAddProduct.Text = "+ Добавить товар";
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddProduct.Size = new System.Drawing.Size(150, 30);
            this.btnAddProduct.Location = new System.Drawing.Point(10, 610);
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(46, 80, 144);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            // btnDeleteProduct
            this.btnDeleteProduct.Text = "🗑 Удалить товар";
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteProduct.Size = new System.Drawing.Size(150, 30);
            this.btnDeleteProduct.Location = new System.Drawing.Point(170, 610);
            this.btnDeleteProduct.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);

            // btnOrders
            this.btnOrders.Text = "📋 Заказы";
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOrders.Size = new System.Drawing.Size(130, 30);
            this.btnOrders.Location = new System.Drawing.Point(340, 610);
            this.btnOrders.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            // Add to form
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnOrders);

            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.RadioButton rdoSortAsc;
        private System.Windows.Forms.RadioButton rdoSortDesc;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnOrders;
    }
}