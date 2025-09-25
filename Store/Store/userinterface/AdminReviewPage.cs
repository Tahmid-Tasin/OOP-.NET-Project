using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using Store.Repository;

namespace Store.userinterface
{
    public partial class AdminReviewPage : Form
    {
        private readonly SqlConnectionFactory factory;

        public AdminReviewPage()
        {
            InitializeComponent();
            factory = new SqlConnectionFactory();

            // Attach event handler for DataGridView button clicks
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void bsckbtn_Click(object sender, EventArgs e)
        {
            AdminView ad = new AdminView();
            ad.Show();
            this.Close();
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = factory.Create()) // ✅ use Create()
            {
                SqlCommand cd = new SqlCommand("SELECT * FROM Review", con);
                SqlDataAdapter d = new SqlDataAdapter(cd);
                DataTable dt = new DataTable();
                d.Fill(dt);

                dataGridView1.DataSource = dt;

                // Optional: make it look better
                dataGridView1.AllowUserToAddRows = false; // remove the blank row
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // fit columns

                // Add "View" button column only once
                if (!dataGridView1.Columns.Contains("ViewButton"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Action";
                    btn.Name = "ViewButton";
                    btn.Text = "View";
                    btn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(btn);
                }
            }
        }

        // ✅ Properly separated event handler
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ViewButton"].Index && e.RowIndex >= 0)
            {
                var reviewId = dataGridView1.Rows[e.RowIndex].Cells["review_id"].Value?.ToString();
                var customerId = dataGridView1.Rows[e.RowIndex].Cells["customer_id"].Value?.ToString();
                var comment = dataGridView1.Rows[e.RowIndex].Cells["comment"].Value?.ToString();

                MessageBox.Show(
                    $"Review ID: {reviewId}\nCustomer ID: {customerId}\nComment: {comment}",
                    "Review Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
