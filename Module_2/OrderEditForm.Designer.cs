namespace ObuvApp
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblArticle    = new System.Windows.Forms.Label();
            this.txtArticle    = new System.Windows.Forms.TextBox();
            this.lblStatus     = new System.Windows.Forms.Label();
            this.cmbStatus     = new System.Windows.Forms.ComboBox();
            this.lblAddress    = new System.Windows.Forms.Label();
            this.txtAddress    = new System.Windows.Forms.TextBox();
            this.lblOrderDate  = new System.Windows.Forms.Label();
            this.dtpOrderDate  = new System.Windows.Forms.DateTimePicker();
            this.lblIssueDate  = new System.Windows.Forms.Label();
            this.dtpIssueDate  = new System.Windows.Forms.DateTimePicker();
            this.chkIssueDate  = new System.Windows.Forms.CheckBox();
            this.btnSave       = new System.Windows.Forms.Button();
            this.btnCancel     = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.ClientSize    = new System.Drawing.Size(440, 320);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;

            int labelX = 20, inputX = 160, inputW = 240, rowH = 40, y = 20;

            // Article
            AddLabel(lblArticle, "Артикул:", labelX, y);
            AddTextBox(txtArticle, inputX, y, inputW);
            y += rowH;

            // Status
            AddLabel(lblStatus, "Статус:", labelX, y);
            this.cmbStatus.Location      = new System.Drawing.Point(inputX, y);
            this.cmbStatus.Size          = new System.Drawing.Size(inputW, 24);
            this.cmbStatus.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            y += rowH;

            // Address
            AddLabel(lblAddress, "Адрес выдачи:", labelX, y);
            AddTextBox(txtAddress, inputX, y, inputW);
            y += rowH;

            // Order Date
            AddLabel(lblOrderDate, "Дата заказа:", labelX, y);
            this.dtpOrderDate.Location = new System.Drawing.Point(inputX, y);
            this.dtpOrderDate.Size     = new System.Drawing.Size(inputW, 24);
            this.dtpOrderDate.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpOrderDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            y += rowH;

            // Issue Date
            AddLabel(lblIssueDate, "Дата выдачи:", labelX, y);
            this.chkIssueDate.Text     = "Указать";
            this.chkIssueDate.Location = new System.Drawing.Point(inputX, y);
            this.chkIssueDate.Size     = new System.Drawing.Size(70, 24);
            this.chkIssueDate.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.chkIssueDate.CheckedChanged += new System.EventHandler(this.chkIssueDate_CheckedChanged);

            this.dtpIssueDate.Location = new System.Drawing.Point(inputX + 75, y);
            this.dtpIssueDate.Size     = new System.Drawing.Size(165, 24);
            this.dtpIssueDate.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpIssueDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Enabled  = false;
            y += rowH + 10;

            // Buttons
            this.btnSave.Text      = "Сохранить";
            this.btnSave.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Size      = new System.Drawing.Size(120, 36);
            this.btnSave.Location  = new System.Drawing.Point(labelX, y);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 80, 144);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text      = "Отмена";
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Size      = new System.Drawing.Size(120, 36);
            this.btnCancel.Location  = new System.Drawing.Point(160, y);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(lblArticle);    this.Controls.Add(txtArticle);
            this.Controls.Add(lblStatus);     this.Controls.Add(cmbStatus);
            this.Controls.Add(lblAddress);    this.Controls.Add(txtAddress);
            this.Controls.Add(lblOrderDate);  this.Controls.Add(dtpOrderDate);
            this.Controls.Add(lblIssueDate);  this.Controls.Add(chkIssueDate);
            this.Controls.Add(dtpIssueDate);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.ResumeLayout(false);
        }

        private void AddLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Size = new System.Drawing.Size(135, 24); lbl.Location = new System.Drawing.Point(x, y + 3);
        }

        private void AddTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w)
        {
            txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            txt.Size = new System.Drawing.Size(w, 24); txt.Location = new System.Drawing.Point(x, y);
        }

        private System.Windows.Forms.Label           lblArticle;
        private System.Windows.Forms.TextBox         txtArticle;
        private System.Windows.Forms.Label           lblStatus;
        private System.Windows.Forms.ComboBox        cmbStatus;
        private System.Windows.Forms.Label           lblAddress;
        private System.Windows.Forms.TextBox         txtAddress;
        private System.Windows.Forms.Label           lblOrderDate;
        private System.Windows.Forms.DateTimePicker  dtpOrderDate;
        private System.Windows.Forms.Label           lblIssueDate;
        private System.Windows.Forms.DateTimePicker  dtpIssueDate;
        private System.Windows.Forms.CheckBox        chkIssueDate;
        private System.Windows.Forms.Button          btnSave;
        private System.Windows.Forms.Button          btnCancel;
    }
}
