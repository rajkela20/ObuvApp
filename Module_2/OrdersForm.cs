using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ObuvApp
{
    public partial class OrdersForm : Form
    {
        private readonly User _currentUser;
        private List<Order> _allOrders = new List<Order>();

        public OrdersForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
            this.Text = "Заказы — ООО Обувь";
            lblUserName.Text = user.FullName;
            LoadOrders();
        }

        private void LoadOrders()
        {
            _allOrders.Clear();

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT o.order_id, o.article_number, os.status_name,
                               o.pickup_address, o.order_date, o.issue_date
                        FROM orders o
                        INNER JOIN order_statuses os ON o.status_id = os.status_id
                        ORDER BY o.order_date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _allOrders.Add(new Order
                            {
                                OrderId       = reader.GetInt32(0),
                                ArticleNumber = reader.GetString(1),
                                StatusName    = reader.GetString(2),
                                PickupAddress = reader.GetString(3),
                                OrderDate     = reader.GetDateTime(4),
                                IssueDate     = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DisplayOrders(_allOrders);
        }

        private void DisplayOrders(List<Order> orders)
        {
            dgvOrders.Rows.Clear();
            foreach (var o in orders)
            {
                dgvOrders.Rows.Add(
                    o.OrderId,
                    o.ArticleNumber,
                    o.StatusName,
                    o.PickupAddress,
                    o.OrderDate.ToString("dd.MM.yyyy"),
                    o.IssueDate.HasValue ? o.IssueDate.Value.ToString("dd.MM.yyyy") : "—"
                );
            }
        }

        // Add order — admin only
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderEditForm editForm = new OrderEditForm(null);
            editForm.FormClosed += (s, args) => LoadOrders();
            editForm.ShowDialog();
        }

        // Edit order on double click — admin only
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentUser.RoleName != "Администратор") return;
            if (e.RowIndex < 0) return;

            int orderId = (int)dgvOrders.Rows[e.RowIndex].Cells["colOrderId"].Value;
            Order selected = _allOrders.Find(o => o.OrderId == orderId);

            OrderEditForm editForm = new OrderEditForm(selected);
            editForm.FormClosed += (s, args) => LoadOrders();
            editForm.ShowDialog();
        }

        // Delete order — admin only
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Удаление заказа",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int orderId = (int)dgvOrders.SelectedRows[0].Cells["colOrderId"].Value;

            DialogResult confirm = MessageBox.Show(
                "Вы уверены, что хотите удалить этот заказ? Это действие нельзя отменить.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM orders WHERE order_id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Заказ успешно удалён.", "Удаление заказа",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении заказа:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
