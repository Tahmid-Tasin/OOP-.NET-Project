using System;

using System.Windows.Forms;

using Store.model;
using Store.service;

namespace Store.userinterface
{
    public partial class ReviewScene : Form
    {
        public ReviewScene()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            commentbox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (commentbox.Text != null)
            {

                Review review = new Review();
                var id = UserSession.Current;
                review.customer_id = id.UserId.Value;
                review.comment = commentbox.Text;

                ReviewService _reviewService = new ReviewService();

                var rows = _reviewService.Register(review);

                MessageBox.Show("Review has been sent");
                commentbox.Text = "";
            }
        }
    }
}
