namespace ObuvApp
{
    partial class ProductEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId           = new System.Windows.Forms.Label();
            this.lblName         = new System.Windows.Forms.Label();
            this.txtName         = new System.Windows.Forms.TextBox();
            this.lblCategory     = new System.Windows.Forms.Label();
            this.cmbCategory     = new System.Windows.Forms.ComboBox();
            this.lblDescription  = new System.Windows.Forms.Label();
            this.txtDescription  = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.lblSupplier     = new System.Windows.Forms.Label();
            this.cmbSupplier     = new System.Windows.Forms.ComboBox();
            this.lblPrice        = new System.Windows.Forms.Label();
            this.txtPrice        = new System.Windows.Forms.TextBox();
            this.lblStock        = new System.Windows.Forms.Label();
            this.txtStock        = new System.Windows.Forms.TextBox();
            this.lblDiscount     = new System.Windows.Forms.Label();
            this.txtDiscount     = new System.Windows.Forms.TextBox();
            this.picProduct      = new System.Windows.Forms.PictureBox();
            this.btnChooseImage  = new System.Windows.Forms.Button();
            this.btnSave         = new System.Windows.Forms.Button();
            this.btnCancel       = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize    = new System.Drawing.Size(520, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.FormClosed   += new System.Windows.Forms.FormClosedEventHandler(this.ProductEditForm_FormClosed);

            int labelX  = 20;
            int inputX  = 160;
            int inputW  = 220;
            int rowH    = 35;
            int startY  = 20;

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblId.Location = new System.Drawing.Point(labelX, startY);
            this.lblId.Text     = "ID: (авто)";

            // Row helper
            int y = startY + 30;

            // Name
            AddLabel(this.lblName, "Наименование:", labelX, y);
            AddTextBox(this.txtName, inputX, y, inputW);
            y += rowH;

            // Category
            AddLabel(this.lblCategory, "Категория:", labelX, y);
            AddCombo(this.cmbCategory, inputX, y, inputW);
            y += rowH;

            // Description
            AddLabel(this.lblDescription, "Описание:", labelX, y);
            this.txtDescription.Location  = new System.Drawing.Point(inputX, y);
            this.txtDescription.Size      = new System.Drawing.Size(inputW, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.Font      = new System.Drawing.Font("Segoe UI", 9F);
            y += 70;

            // Manufacturer
            AddLabel(this.lblManufacturer, "Производитель:", labelX, y);
            AddCombo(this.cmbManufacturer, inputX, y, inputW);
            y += rowH;

            // Supplier
            AddLabel(this.lblSupplier, "Поставщик:", labelX, y);
            AddCombo(this.cmbSupplier, inputX, y, inputW);
            y += rowH;

            // Price
            AddLabel(this.lblPrice, "Цена (руб.):", labelX, y);
            AddTextBox(this.txtPrice, inputX, y, 100);
            y += rowH;

            // Stock
            AddLabel(this.lblStock, "Кол-во на складе:", labelX, y);
            AddTextBox(this.txtStock, inputX, y, 100);
            y += rowH;

            // Discount
            AddLabel(this.lblDiscount, "Скидка (%):", labelX, y);
            AddTextBox(this.txtDiscount, inputX, y, 100);
            y += rowH;

            // Image
            this.picProduct.Location  = new System.Drawing.Point(400, 50);
            this.picProduct.Size      = new System.Drawing.Size(100, 80);
            this.picProduct.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnChooseImage.Text      = "Выбрать фото";
            this.btnChooseImage.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.btnChooseImage.Size      = new System.Drawing.Size(100, 26);
            this.btnChooseImage.Location  = new System.Drawing.Point(400, 140);
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Click    += new System.EventHandler(this.btnChooseImage_Click);

            // Buttons
            this.btnSave.Text      = "Сохранить";
            this.btnSave.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Size      = new System.Drawing.Size(120, 36);
            this.btnSave.Location  = new System.Drawing.Point(labelX, y + 10);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 80, 144);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text      = "Отмена";
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Size      = new System.Drawing.Size(120, 36);
            this.btnCancel.Location  = new System.Drawing.Point(160, y + 10);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // Add all controls
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblName);          this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);      this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblDescription);   this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblManufacturer);  this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.lblSupplier);      this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblPrice);         this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);         this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblDiscount);      this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
        }

        private void AddLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text     = text;
            lbl.Font     = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Size     = new System.Drawing.Size(135, 24);
            lbl.Location = new System.Drawing.Point(x, y + 3);
        }

        private void AddTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w)
        {
            txt.Font     = new System.Drawing.Font("Segoe UI", 9F);
            txt.Size     = new System.Drawing.Size(w, 24);
            txt.Location = new System.Drawing.Point(x, y);
        }

        private void AddCombo(System.Windows.Forms.ComboBox cmb, int x, int y, int w)
        {
            cmb.Font          = new System.Drawing.Font("Segoe UI", 9F);
            cmb.Size          = new System.Drawing.Size(w, 24);
            cmb.Location      = new System.Drawing.Point(x, y);
            cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private System.Windows.Forms.Label      lblId;
        private System.Windows.Forms.Label      lblName;
        private System.Windows.Forms.TextBox    txtName;
        private System.Windows.Forms.Label      lblCategory;
        private System.Windows.Forms.ComboBox   cmbCategory;
        private System.Windows.Forms.Label      lblDescription;
        private System.Windows.Forms.TextBox    txtDescription;
        private System.Windows.Forms.Label      lblManufacturer;
        private System.Windows.Forms.ComboBox   cmbManufacturer;
        private System.Windows.Forms.Label      lblSupplier;
        private System.Windows.Forms.ComboBox   cmbSupplier;
        private System.Windows.Forms.Label      lblPrice;
        private System.Windows.Forms.TextBox    txtPrice;
        private System.Windows.Forms.Label      lblStock;
        private System.Windows.Forms.TextBox    txtStock;
        private System.Windows.Forms.Label      lblDiscount;
        private System.Windows.Forms.TextBox    txtDiscount;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Button     btnChooseImage;
        private System.Windows.Forms.Button     btnSave;
        private System.Windows.Forms.Button     btnCancel;
    }
}
