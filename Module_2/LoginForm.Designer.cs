namespace ObuvApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblLogin      = new System.Windows.Forms.Label();
            this.lblPassword   = new System.Windows.Forms.Label();
            this.txtLogin      = new System.Windows.Forms.TextBox();
            this.txtPassword   = new System.Windows.Forms.TextBox();
            this.btnLogin      = new System.Windows.Forms.Button();
            this.btnGuest      = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.ClientSize    = new System.Drawing.Size(380, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox   = false;
            this.Text          = "Вход — ООО Обувь";
            this.FormClosed   += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);

            // lblTitle
            this.lblTitle.Text      = "ООО «Обувь»";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Size      = new System.Drawing.Size(340, 40);
            this.lblTitle.Location  = new System.Drawing.Point(20, 20);

            // lblLogin
            this.lblLogin.Text     = "Логин:";
            this.lblLogin.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLogin.Size     = new System.Drawing.Size(80, 24);
            this.lblLogin.Location = new System.Drawing.Point(40, 90);

            // txtLogin
            this.txtLogin.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.Size     = new System.Drawing.Size(260, 26);
            this.txtLogin.Location = new System.Drawing.Point(40, 116);

            // lblPassword
            this.lblPassword.Text     = "Пароль:";
            this.lblPassword.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Size     = new System.Drawing.Size(80, 24);
            this.lblPassword.Location = new System.Drawing.Point(40, 155);

            // txtPassword
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Size         = new System.Drawing.Size(260, 26);
            this.txtPassword.Location     = new System.Drawing.Point(40, 181);
            this.txtPassword.PasswordChar = '●';

            // btnLogin
            this.btnLogin.Text      = "Войти";
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogin.Size      = new System.Drawing.Size(120, 36);
            this.btnLogin.Location  = new System.Drawing.Point(40, 230);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(46, 80, 144);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // btnGuest
            this.btnGuest.Text      = "Войти как гость";
            this.btnGuest.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuest.Size      = new System.Drawing.Size(160, 36);
            this.btnGuest.Location  = new System.Drawing.Point(180, 230);
            this.btnGuest.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnGuest.ForeColor = System.Drawing.Color.White;
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuest.Click    += new System.EventHandler(this.btnGuest_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGuest);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblLogin;
        private System.Windows.Forms.Label    lblPassword;
        private System.Windows.Forms.TextBox  txtLogin;
        private System.Windows.Forms.TextBox  txtPassword;
        private System.Windows.Forms.Button   btnLogin;
        private System.Windows.Forms.Button   btnGuest;
    }
}
