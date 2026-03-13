using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ObuvApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Вход — ООО Обувь";
        }

        // Login button click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Введите логин и пароль.",
                    "Ошибка входа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            User user = AuthenticateUser(login, password);

            if (user == null)
            {
                MessageBox.Show(
                    "Неверный логин или пароль. Проверьте введённые данные и попробуйте снова.",
                    "Ошибка входа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Open products form with authenticated user
            ProductsForm productsForm = new ProductsForm(user);
            productsForm.Show();
            this.Hide();
        }

        // Guest button click — open products without login
        private void btnGuest_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm(null);
            productsForm.Show();
            this.Hide();
        }

        // Authenticate user against database
        private User AuthenticateUser(string login, string password)
        {
            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT u.user_id, u.login, u.last_name, u.first_name, u.middle_name, r.role_name
                        FROM users u
                        INNER JOIN roles r ON u.role_id = r.role_id
                        WHERE u.login = @login AND u.password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId     = reader.GetInt32(0),
                                    Login      = reader.GetString(1),
                                    LastName   = reader.GetString(2),
                                    FirstName  = reader.GetString(3),
                                    MiddleName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    RoleName   = reader.GetString(5)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка подключения к базе данных:\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return null;
        }

        // When login form is closed entirely, exit the app
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
