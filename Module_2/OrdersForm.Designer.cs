namespace ObuvApp
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUserName      = new System.Windows.Forms.Label();
            this.btnBack          = new System.Windows.Forms.Button();
            this.dgvOrders        = new System.Windows.Forms.DataGridView();
            this.btnAddOrder      = new System.Windows.Forms.Button();
            this.btnDeleteOrder   = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize    = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Заказы — ООО Обувь";

            // lblUserName
            this.lblUserName.AutoSize  = false;
            this.lblUserName.Size      = new System.Drawing.Size(300, 30);
            this.lblUserName.Location  = new System.Drawing.Point(690, 10);
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserName.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // btnBack
            this.btnBack.Text      = "← Назад";
            this.btnBack.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Size      = new System.Drawing.Size(90, 30);
            this.btnBack.Location  = new System.Drawing.Point(10, 10);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click    += new System.EventHandler(this.btnBack_Click);

            // dgvOrders
            this.dgvOrders.Location            = new System.Drawing.Point(0, 55);
            this.dgvOrders.Size                = new System.Drawing.Size(1000, 500);
            this.dgvOrders.AllowUserToAddRows  = false;
            this.dgvOrders.ReadOnly            = true;
            this.dgvOrders.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvOrders.CellDoubleClick    += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);

            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colOrderId",      HeaderText = "ID",              Visible = false });
            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colArticle",      HeaderText = "Артикул заказа" });
            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colStatus",       HeaderText = "Статус" });
            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colAddress",      HeaderText = "Адрес пункта выдачи" });
            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colOrderDate",    HeaderText = "Дата заказа" });
            this.dgvOrders.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colIssueDate",    HeaderText = "Дата выдачи" });

            // btnAddOrder
            this.btnAddOrder.Text      = "+ Добавить заказ";
            this.btnAddOrder.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddOrder.Size      = new System.Drawing.Size(150, 30);
            this.btnAddOrder.Location  = new System.Drawing.Point(10, 562);
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(46, 80, 144);
            this.btnAddOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Click    += new System.EventHandler(this.btnAddOrder_Click);

            // btnDeleteOrder
            this.btnDeleteOrder.Text      = "🗑 Удалить заказ";
            this.btnDeleteOrder.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteOrder.Size      = new System.Drawing.Size(150, 30);
            this.btnDeleteOrder.Location  = new System.Drawing.Point(170, 562);
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDeleteOrder.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrder.Click    += new System.EventHandler(this.btnDeleteOrder_Click);

            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnDeleteOrder);

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblUserName;
        private System.Windows.Forms.Button       btnBack;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button       btnAddOrder;
        private System.Windows.Forms.Button       btnDeleteOrder;
    }
}
