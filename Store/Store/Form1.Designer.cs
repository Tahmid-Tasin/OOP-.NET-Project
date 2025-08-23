namespace Store
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CreateAccountBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.pwBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 481);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.panel2.Controls.Add(this.CreateAccountBtn);
            this.panel2.Controls.Add(this.LoginBtn);
            this.panel2.Controls.Add(this.pwBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.UserNameBox);
            this.panel2.Controls.Add(this.UserComboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(450, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 481);
            this.panel2.TabIndex = 1;
            // 
            // CreateAccountBtn
            // 
            this.CreateAccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(122)))));
            this.CreateAccountBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateAccountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccountBtn.Font = new System.Drawing.Font("Noto Sans HK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountBtn.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.CreateAccountBtn.Location = new System.Drawing.Point(3, 435);
            this.CreateAccountBtn.Name = "CreateAccountBtn";
            this.CreateAccountBtn.Size = new System.Drawing.Size(238, 46);
            this.CreateAccountBtn.TabIndex = 9;
            this.CreateAccountBtn.Text = "Create New Account";
            this.CreateAccountBtn.UseVisualStyleBackColor = false;
            this.CreateAccountBtn.Click += new System.EventHandler(this.CreateAccountBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(122)))));
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.Font = new System.Drawing.Font("Noto Sans HK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.LoginBtn.Location = new System.Drawing.Point(241, 435);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(222, 46);
            this.LoginBtn.TabIndex = 8;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // pwBox
            // 
            this.pwBox.Font = new System.Drawing.Font("Noto Sans HK Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwBox.Location = new System.Drawing.Point(183, 363);
            this.pwBox.Multiline = true;
            this.pwBox.Name = "pwBox";
            this.pwBox.Size = new System.Drawing.Size(230, 34);
            this.pwBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Noto Sans HK", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // UserNameBox
            // 
            this.UserNameBox.Font = new System.Drawing.Font("Noto Sans HK Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameBox.Location = new System.Drawing.Point(183, 298);
            this.UserNameBox.Multiline = true;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(230, 34);
            this.UserNameBox.TabIndex = 5;
            // 
            // UserComboBox
            // 
            this.UserComboBox.Font = new System.Drawing.Font("Noto Sans HK Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(183, 232);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(145, 32);
            this.UserComboBox.TabIndex = 4;
            this.UserComboBox.SelectedIndexChanged += new System.EventHandler(this.UserComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Noto Sans HK", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select User";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Noto Sans HK", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Noto Sans HK Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(175, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(168, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 123);
            this.panel3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(916, 481);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pwBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button CreateAccountBtn;
    }
}

