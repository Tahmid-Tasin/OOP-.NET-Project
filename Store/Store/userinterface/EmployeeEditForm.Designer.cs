using System.Drawing;
using System.Windows.Forms;

namespace Store.userinterface
{
    partial class EmployeeEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel contentPanel;
        private Label lblTitle;

        private Label labelName;
        private TextBox NameBox;

        private Label labelMobile;
        private TextBox MobileBox;

        private Label labelEmail;
        private TextBox EmailBox;

        private Label labelPassword;
        private TextBox PassBox;

        private Label labelAddress;
        private TextBox AddressBox;

        private Label labelOutlet;
        private ComboBox OutletCombo;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.contentPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.labelName = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();

            this.labelMobile = new System.Windows.Forms.Label();
            this.MobileBox = new System.Windows.Forms.TextBox();

            this.labelEmail = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();

            this.labelPassword = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();

            this.labelAddress = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();

            this.labelOutlet = new System.Windows.Forms.Label();
            this.OutletCombo = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // contentPanel (single focusable container to avoid overlays)
            // 
            this.contentPanel.BackColor = Color.WhiteSmoke;
            this.contentPanel.Location = new Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new Size(540, 400);
            this.contentPanel.TabIndex = 0;
            this.contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Add Employee";
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(175, 76, 15);
            this.lblTitle.Location = new Point(20, 18);
            this.lblTitle.AutoSize = true;
            this.lblTitle.TabIndex = 0;
            // 
            // Name
            // 
            this.labelName.Text = "Name";
            this.labelName.Location = new Point(24, 70);
            this.labelName.Size = new Size(80, 18);
            this.labelName.TabIndex = 1;

            this.NameBox.Location = new Point(120, 68);
            this.NameBox.Size = new Size(380, 22);
            this.NameBox.TabIndex = 2;
            // 
            // Mobile
            // 
            this.labelMobile.Text = "Mobile";
            this.labelMobile.Location = new Point(24, 102);
            this.labelMobile.Size = new Size(80, 18);
            this.labelMobile.TabIndex = 3;

            this.MobileBox.Location = new Point(120, 100);
            this.MobileBox.Size = new Size(380, 22);
            this.MobileBox.TabIndex = 4;
            // 
            // Email
            // 
            this.labelEmail.Text = "Email";
            this.labelEmail.Location = new Point(24, 134);
            this.labelEmail.Size = new Size(80, 18);
            this.labelEmail.TabIndex = 5;

            this.EmailBox.Location = new Point(120, 132);
            this.EmailBox.Size = new Size(380, 22);
            this.EmailBox.TabIndex = 6;
            // 
            // Password
            // 
            this.labelPassword.Text = "Password";
            this.labelPassword.Location = new Point(24, 166);
            this.labelPassword.Size = new Size(80, 18);
            this.labelPassword.TabIndex = 7;

            this.PassBox.Location = new Point(120, 164);
            this.PassBox.Size = new Size(380, 22);
            this.PassBox.UseSystemPasswordChar = true;
            this.PassBox.TabIndex = 8;
            // 
            // Address
            // 
            this.labelAddress.Text = "Address";
            this.labelAddress.Location = new Point(24, 198);
            this.labelAddress.Size = new Size(80, 18);
            this.labelAddress.TabIndex = 9;

            this.AddressBox.Location = new Point(120, 196);
            this.AddressBox.Size = new Size(380, 60);
            this.AddressBox.Multiline = true;
            this.AddressBox.TabIndex = 10;
            // 
            // Outlet
            // 
            this.labelOutlet.Text = "Outlet";
            this.labelOutlet.Location = new Point(24, 266);
            this.labelOutlet.Size = new Size(80, 18);
            this.labelOutlet.TabIndex = 11;

            this.OutletCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.OutletCombo.Location = new Point(120, 264);
            this.OutletCombo.Size = new Size(380, 24);
            this.OutletCombo.TabIndex = 12;
            // 
            // Buttons
            // 
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(310, 310);
            this.btnSave.Size = new Size(90, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(410, 310);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to contentPanel (ensures correct z-order)
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.labelName);
            this.contentPanel.Controls.Add(this.NameBox);
            this.contentPanel.Controls.Add(this.labelMobile);
            this.contentPanel.Controls.Add(this.MobileBox);
            this.contentPanel.Controls.Add(this.labelEmail);
            this.contentPanel.Controls.Add(this.EmailBox);
            this.contentPanel.Controls.Add(this.labelPassword);
            this.contentPanel.Controls.Add(this.PassBox);
            this.contentPanel.Controls.Add(this.labelAddress);
            this.contentPanel.Controls.Add(this.AddressBox);
            this.contentPanel.Controls.Add(this.labelOutlet);
            this.contentPanel.Controls.Add(this.OutletCombo);
            this.contentPanel.Controls.Add(this.btnSave);
            this.contentPanel.Controls.Add(this.btnCancel);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(540, 400);
            this.Controls.Add(this.contentPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Employee";
            this.Shown += new System.EventHandler(this.EmployeeEditForm_Shown);

            // make Enter submit, Esc cancel
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;

            this.ResumeLayout(false);
        }
        #endregion
    }
}
