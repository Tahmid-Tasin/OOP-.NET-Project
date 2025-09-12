using System;
using System.Drawing;

namespace Store.userinterface
{
    partial class BranchEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.Address1Box = new System.Windows.Forms.TextBox();
            this.Address2Box = new System.Windows.Forms.TextBox();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.StateBox = new System.Windows.Forms.TextBox();
            this.PostalBox = new System.Windows.Forms.TextBox();
            this.CountryBox = new System.Windows.Forms.TextBox();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // BranchEditForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Branch";
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Branch";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(175, 76, 15);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.AutoSize = true;
            // 
            // NameBox
            // 
            this.NameBox.Location = new Point(150, 70);
            this.NameBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Branch Name", Location = new Point(30, 70), AutoSize = true });
            // 
            // Address1Box
            // 
            this.Address1Box.Location = new Point(150, 100);
            this.Address1Box.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Address Line 1", Location = new Point(30, 100), AutoSize = true });
            // 
            // Address2Box
            // 
            this.Address2Box.Location = new Point(150, 130);
            this.Address2Box.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Address Line 2", Location = new Point(30, 130), AutoSize = true });
            // 
            // CityBox
            // 
            this.CityBox.Location = new Point(150, 160);
            this.CityBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "City", Location = new Point(30, 160), AutoSize = true });
            // 
            // StateBox
            // 
            this.StateBox.Location = new Point(150, 190);
            this.StateBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "State", Location = new Point(30, 190), AutoSize = true });
            // 
            // PostalBox
            // 
            this.PostalBox.Location = new Point(150, 220);
            this.PostalBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Postal Code", Location = new Point(30, 220), AutoSize = true });
            // 
            // CountryBox
            // 
            this.CountryBox.Location = new Point(150, 250);
            this.CountryBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Country", Location = new Point(30, 250), AutoSize = true });
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new Point(150, 280);
            this.PhoneBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Phone", Location = new Point(30, 280), AutoSize = true });
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new Point(150, 310);
            this.EmailBox.Size = new Size(300, 22);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Email", Location = new Point(30, 310), AutoSize = true });
            // 
            // btnSave
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(260, 370);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(360, 370);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // Add controls
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.Address1Box);
            this.Controls.Add(this.Address2Box);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.StateBox);
            this.Controls.Add(this.PostalBox);
            this.Controls.Add(this.CountryBox);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox Address1Box;
        private System.Windows.Forms.TextBox Address2Box;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.TextBox StateBox;
        private System.Windows.Forms.TextBox PostalBox;
        private System.Windows.Forms.TextBox CountryBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
