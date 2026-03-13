using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ObuvApp
{
    public partial class OrderEditForm : Form
    {
        private readonly Order _order; // null = new order

        public OrderEditForm(Order order)
        {
            _order = order;
            InitializeComponent();
            this.Text = order == null ? "Добавить заказ" : "Редактировать заказ";
            LoadStatuses();

            if (order != null)
                FillFields(order);
        }

        private void LoadStatuses()
        {
            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT status_name FROM order_statuses ORDER BY status_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbStatus.Items.Add(reader.GetString(0));
                    }
                }
                if (cmbStatus.Items.Count > 0)
                    cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFields(Order o)
        {
            txtArticle.Text       = o.ArticleNumber;
            txtAddress.Text       = o.PickupAddress;
            dtpOrderDate.Value    = o.OrderDate;
            dtpIssueDate.Value    = o.IssueDate ?? DateTime.Today;
            chkIssueDate.Checked  = o.IssueDate.HasValue;
            dtpIssueDate.Enabled  = o.IssueDate.HasValue;

            for (int i = 0; i < cmbStatus.Items.Count; i++)
                if (cmbStatus.Items[i].ToString() == o.StatusName)
                    cmbStatus.SelectedIndex = i;
        }

        private void chkIssueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpIssueDate.Enabled = chkIssueDate.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Введите артикул заказа.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Введите адрес пункта выдачи.", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();

                    // Get status ID
                    int statusId;
                    string statusQuery = "SELECT status_id FROM order_statuses WHERE status_name = @name";
                    using (SqlCommand cmd = new SqlCommand(statusQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", cmbStatus.SelectedItem.ToString());
                        statusId = (int)cmd.ExecuteScalar();
                    }

                    string article  = txtArticle.Text.Trim();
                    string address  = txtAddress.Text.Trim();
                    DateTime orderDate = dtpOrderDate.Value.Date;
                    DateTime? issueDate = chkIssueDate.Checked ? dtpIssueDate.Value.Date : (DateTime?)null;

                    if (_order == null)
                    {
                        string insertQuery = @"
                            INSERT INTO orders (article_number, status_id, pickup_address, order_date, issue_date)
                            VALUES (@article, @status, @address, @orderDate, @issueDate)";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@article",   article);
                            cmd.Parameters.AddWithValue("@status",    statusId);
                            cmd.Parameters.AddWithValue("@address",   address);
                            cmd.Parameters.AddWithValue("@orderDate", orderDate);
                            cmd.Parameters.AddWithValue("@issueDate", (object)issueDate ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string updateQuery = @"
                            UPDATE orders SET
                                article_number = @article,
                                status_id      = @status,
                                pickup_address = @address,
                                order_date     = @orderDate,
                                issue_date     = @issueDate
                            WHERE order_id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@article",   article);
                            cmd.Parameters.AddWithValue("@status",    statusId);
                            cmd.Parameters.AddWithValue("@address",   address);
                            cmd.Parameters.AddWithValue("@orderDate", orderDate);
                            cmd.Parameters.AddWithValue("@issueDate", (object)issueDate ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@id",        _order.OrderId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Заказ успешно сохранён.", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
