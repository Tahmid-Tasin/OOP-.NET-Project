using System.Drawing;

namespace Store.userinterface
{
    partial class EmployeeEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MobileBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // EmployeeEditForm (Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee";
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Employee";
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(175, 76, 15);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.AutoSize = true;
            // 
            // label2 (Name)
            // 
            this.label2.Text = "Name";
            this.label2.Location = new Point(22, 70);
            this.label2.Size = new Size(80, 20);
            // 
            // NameBox
            // 
            this.NameBox.Location = new Point(110, 68);
            this.NameBox.Size = new Size(370, 22);
            this.NameBox.TabIndex = 0;
            // 
            // label4 (Mobile)
            // 
            this.label4.Text = "Mobile";
            this.label4.Location = new Point(22, 105);
            this.label4.Size = new Size(80, 20);
            // 
            // MobileBox
            // 
            this.MobileBox.Location = new Point(110, 103);
            this.MobileBox.Size = new Size(370, 22);
            this.MobileBox.TabIndex = 1;
            // 
            // label5 (Password)
            // 
            this.label5.Text = "Password";
            this.label5.Location = new Point(22, 140);
            this.label5.Size = new Size(80, 20);
            // 
            // PassBox
            // 
            this.PassBox.Location = new Point(110, 138);
            this.PassBox.Size = new Size(370, 22);
            this.PassBox.TabIndex = 2;
            this.PassBox.UseSystemPasswordChar = true;
            // 
            // label6 (Address)
            // 
            this.label6.Text = "Address";
            this.label6.Location = new Point(22, 175);
            this.label6.Size = new Size(80, 20);
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new Point(110, 173);
            this.AddressBox.Size = new Size(370, 60);
            this.AddressBox.Multiline = true;
            this.AddressBox.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(290, 260);
            this.btnSave.Size = new Size(90, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(390, 260);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MobileBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            // Must be set after buttons exist
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MobileBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
