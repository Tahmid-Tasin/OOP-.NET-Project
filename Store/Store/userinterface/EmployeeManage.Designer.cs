using System.Drawing;

namespace Store
{
    partial class EmployeeManage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Addressbox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.MobileBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchNameBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SearchMobileBox = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 729);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // View
            this.View_Col.HeaderText = "View";
            this.View_Col.Name = "View_Col";
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;
            this.View_Col.Width = 60;
            // Edit
            this.Edit_Col.HeaderText = "Edit";
            this.Edit_Col.Name = "Edit_Col";
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;
            this.Edit_Col.Width = 60;
            // Delete
            this.Delete_Col.HeaderText = "Delete";
            this.Delete_Col.Name = "Delete_Col";
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;
            this.Delete_Col.Width = 60;
            // text columns
            this.ID_Coloumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_Coloumn.HeaderText = "ID";
            this.ID_Coloumn.Name = "ID_Coloumn";
            this.ID_Coloumn.ReadOnly = true;
            this.Name_Coloumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name_Coloumn.HeaderText = "Name";
            this.Name_Coloumn.Name = "Name_Coloumn";
            this.Name_Coloumn.ReadOnly = true;
            this.Mobile_Coloumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile_Coloumn.HeaderText = "Mobile";
            this.Mobile_Coloumn.Name = "Mobile_Coloumn";
            this.Mobile_Coloumn.ReadOnly = true;
            this.Address_Coloumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address_Coloumn.HeaderText = "Address";
            this.Address_Coloumn.Name = "Address_Coloumn";
            this.Address_Coloumn.ReadOnly = true;

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.View_Col,
            this.Edit_Col,
            this.Delete_Col,
            this.ID_Coloumn,
            this.Name_Coloumn,
            this.Mobile_Coloumn,
            this.Address_Coloumn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 615);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Addressbox);
            this.panel2.Controls.Add(this.PassBox);
            this.panel2.Controls.Add(this.MobileBox);
            this.panel2.Controls.Add(this.NameBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.SearchNameBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.SearchMobileBox);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.IDBox);
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(679, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 729);
            this.panel2.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(205, 314);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 39);
            this.button5.TabIndex = 17;
            this.button5.Text = "Update";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button4.Location = new System.Drawing.Point(472, 671);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 58);
            this.button4.TabIndex = 16;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(444, 530);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 39);
            this.button3.TabIndex = 15;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(325, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 39);
            this.button2.TabIndex = 12;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(445, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 39);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Addressbox
            // 
            this.Addressbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Addressbox.Location = new System.Drawing.Point(237, 271);
            this.Addressbox.Multiline = true;
            this.Addressbox.Name = "Addressbox";
            this.Addressbox.Size = new System.Drawing.Size(320, 33);
            this.Addressbox.TabIndex = 10;
            // 
            // PassBox
            // 
            this.PassBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PassBox.Location = new System.Drawing.Point(237, 223);
            this.PassBox.Multiline = true;
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(320, 33);
            this.PassBox.TabIndex = 9;
            // 
            // MobileBox
            // 
            this.MobileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MobileBox.Location = new System.Drawing.Point(237, 177);
            this.MobileBox.Multiline = true;
            this.MobileBox.Name = "MobileBox";
            this.MobileBox.Size = new System.Drawing.Size(320, 33);
            this.MobileBox.TabIndex = 8;
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NameBox.Location = new System.Drawing.Point(237, 131);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(320, 33);
            this.NameBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(85, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(85, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(85, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mobile";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(85, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.label1.Location = new System.Drawing.Point(160, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(85, 450);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 32);
            this.label8.TabIndex = 18;
            this.label8.Text = "Search Name";
            // 
            // SearchNameBox
            // 
            this.SearchNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SearchNameBox.Location = new System.Drawing.Point(237, 450);
            this.SearchNameBox.Multiline = true;
            this.SearchNameBox.Name = "SearchNameBox";
            this.SearchNameBox.Size = new System.Drawing.Size(320, 33);
            this.SearchNameBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(85, 490);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 32);
            this.label9.TabIndex = 20;
            this.label9.Text = "Search Mobile";
            // 
            // SearchMobileBox
            // 
            this.SearchMobileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SearchMobileBox.Location = new System.Drawing.Point(237, 490);
            this.SearchMobileBox.Multiline = true;
            this.SearchMobileBox.Name = "SearchMobileBox";
            this.SearchMobileBox.Size = new System.Drawing.Size(320, 33);
            this.SearchMobileBox.TabIndex = 21;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(76)))), ((int)(((byte)(15)))));
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(324, 530);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(114, 39);
            this.button7.TabIndex = 22;
            this.button7.Text = "Reset";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // IDBox
            // 
            this.IDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.IDBox.Location = new System.Drawing.Point(237, 90);
            this.IDBox.Multiline = true;
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(320, 33);
            this.IDBox.TabIndex = 23;
            this.IDBox.Visible = false;
            // 
            // EmployeeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeManage";
            this.Text = "EmployeeManage";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Addressbox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.TextBox MobileBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SearchNameBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SearchMobileBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.DataGridViewButtonColumn View_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Edit_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_Col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Coloumn;
    }
}
