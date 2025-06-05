using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace RentalSystemApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Loaded when the form first appears
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        // Loads all items from the database into gridItems
        private void LoadItems()
        {
            string connStr = ConfigurationManager.ConnectionStrings["RentalDb"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT id, name, is_rented FROM items ORDER BY name";
                var cmd = new MySqlCommand(query, conn);
                var adapter = new MySqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                table.Columns.Add("Status", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    bool rented = Convert.ToBoolean(row["is_rented"]);
                    row["Status"] = rented ? "Rented" : "Available";
                }

                gridItems.DataSource = table;
                gridItems.Columns["id"].Visible = false;
                gridItems.Columns["is_rented"].Visible = false;
                gridItems.Columns["name"].HeaderText = "Item Name";
                gridItems.Columns["Status"].HeaderText = "Status";
            }
        }

        // Adds a brand-new item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string newItemName = txtNewItemName.Text.Trim();
            if (string.IsNullOrEmpty(newItemName))
            {
                MessageBox.Show("Please enter an item name.", "Warning");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["RentalDb"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string insertSql = "INSERT INTO items (name) VALUES (@name)";
                var cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@name", newItemName);
                cmd.ExecuteNonQuery();
            }

            txtNewItemName.Clear();
            LoadItems();
        }

        // Rents out the selected item
        private void btnRentItem_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to rent.", "Info");
                return;
            }

            var selectedRow = gridItems.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            bool isRented = Convert.ToBoolean(selectedRow.Cells["is_rented"].Value);

            if (isRented)
            {
                MessageBox.Show("That item is already rented.", "Info");
                return;
            }

            string customerName = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Please enter a customer name before renting.", "Warning");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["RentalDb"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string insertRentalSql =
                    "INSERT INTO rentals (item_id, customer, rent_date) VALUES (@iid, @cust, CURDATE())";
                using (var cmd1 = new MySqlCommand(insertRentalSql, conn))
                {
                    cmd1.Parameters.AddWithValue("@iid", itemId);
                    cmd1.Parameters.AddWithValue("@cust", customerName);
                    cmd1.ExecuteNonQuery();
                }

                string updateItemSql = "UPDATE items SET is_rented = 1 WHERE id = @iid";
                using (var cmd2 = new MySqlCommand(updateItemSql, conn))
                {
                    cmd2.Parameters.AddWithValue("@iid", itemId);
                    cmd2.ExecuteNonQuery();
                }
            }

            txtCustomerName.Clear();
            LoadItems();
            MessageBox.Show("Item rented successfully!", "Success");
        }

        // Returns the selected item
        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to return.", "Info");
                return;
            }

            var selectedRow = gridItems.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            bool isRented = Convert.ToBoolean(selectedRow.Cells["is_rented"].Value);

            if (!isRented)
            {
                MessageBox.Show("That item is not currently rented.", "Info");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["RentalDb"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string updateRentalSql =
                    "UPDATE rentals SET return_date = CURDATE() WHERE item_id = @iid AND return_date IS NULL";
                using (var cmd1 = new MySqlCommand(updateRentalSql, conn))
                {
                    cmd1.Parameters.AddWithValue("@iid", itemId);
                    cmd1.ExecuteNonQuery();
                }
                string updateItemSql = "UPDATE items SET is_rented = 0 WHERE id = @iid";
                using (var cmd2 = new MySqlCommand(updateItemSql, conn))
                {
                    cmd2.Parameters.AddWithValue("@iid", itemId);
                    cmd2.ExecuteNonQuery();
                }
            }

            LoadItems();
            MessageBox.Show("Item returned successfully!", "Success");
        }
    }
}
