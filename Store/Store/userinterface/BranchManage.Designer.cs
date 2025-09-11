using System;
using System.Drawing;
using System.Windows.Forms;

namespace Store.userinterface
{
    partial class BranchManage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel topPanel;
        private ComboBox cbFilterToggle;
        private Button btnAddNew;

        private Panel filterPanel;
        private TextBox txtSearchName;
        private TextBox txtSearchCity;
        private TextBox txtSearchPhone;
        private TextBox txtSearchPostal;
        private Button btnDoSearch;
        private Button btnResetSearch;

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID_Column;
        private DataGridViewTextBoxColumn Name_Column;
        private DataGridViewTextBoxColumn City_Column;
        private DataGridViewTextBoxColumn Phone_Column;
        private DataGridViewTextBoxColumn Email_Column;
        private DataGridViewButtonColumn View_Col;
        private DataGridViewButtonColumn Edit_Col;
        private DataGridViewButtonColumn Delete_Col;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.topPanel = new System.Windows.Forms.Panel();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new System.Windows.Forms.Button();

            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchCity = new System.Windows.Forms.TextBox();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.txtSearchPostal = new System.Windows.Forms.TextBox();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();

            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // ===== Form =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Management";

            // ===== topPanel =====
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 56;
            this.topPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topPanel.Controls.Add(this.cbFilterToggle);
            this.topPanel.Controls.Add(this.btnAddNew);
            this.topPanel.SizeChanged += new System.EventHandler(this.topPanel_SizeChanged);

            // cbFilterToggle
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] { "Hide Filters", "Show Filters" });
            this.cbFilterToggle.Location = new System.Drawing.Point(12, 16);
            this.cbFilterToggle.Size = new System.Drawing.Size(140, 21);
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);

            // btnAddNew
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.Size = new System.Drawing.Size(100, 28);
            // No Anchor — we reposition manually in code-behind
            this.btnAddNew.Location = new System.Drawing.Point(980, 14);
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);

            // ===== filterPanel =====
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Height = 54;
            this.filterPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.filterPanel.Visible = false;

            // txtSearchName
            this.txtSearchName.Location = new System.Drawing.Point(12, 16);
            this.txtSearchName.Size = new System.Drawing.Size(150, 22);

            // txtSearchCity
            this.txtSearchCity.Location = new System.Drawing.Point(170, 16);
            this.txtSearchCity.Size = new System.Drawing.Size(120, 22);

            // txtSearchPhone
            this.txtSearchPhone.Location = new System.Drawing.Point(296, 16);
            this.txtSearchPhone.Size = new System.Drawing.Size(120, 22);

            // txtSearchPostal
            this.txtSearchPostal.Location = new System.Drawing.Point(422, 16);
            this.txtSearchPostal.Size = new System.Drawing.Size(100, 22);

            // btnDoSearch
            this.btnDoSearch.Text = "Search";
            this.btnDoSearch.Location = new System.Drawing.Point(530, 15);
            this.btnDoSearch.Size = new System.Drawing.Size(80, 24);
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);

            // btnResetSearch
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.Location = new System.Drawing.Point(620, 15);
            this.btnResetSearch.Size = new System.Drawing.Size(80, 24);
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            this.filterPanel.Controls.Add(this.txtSearchName);
            this.filterPanel.Controls.Add(this.txtSearchCity);
            this.filterPanel.Controls.Add(this.txtSearchPhone);
            this.filterPanel.Controls.Add(this.txtSearchPostal);
            this.filterPanel.Controls.Add(this.btnDoSearch);
            this.filterPanel.Controls.Add(this.btnResetSearch);

            // ===== dataGridView1 =====
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Columns (text)
            this.ID_Column.HeaderText = "ID";
            this.ID_Column.Name = "ID_Column";
            this.ID_Column.ReadOnly = true;

            this.Name_Column.HeaderText = "Name";
            this.Name_Column.Name = "Name_Column";
            this.Name_Column.ReadOnly = true;

            this.City_Column.HeaderText = "City";
            this.City_Column.Name = "City_Column";
            this.City_Column.ReadOnly = true;

            this.Phone_Column.HeaderText = "Phone";
            this.Phone_Column.Name = "Phone_Column";
            this.Phone_Column.ReadOnly = true;

            this.Email_Column.HeaderText = "Email";
            this.Email_Column.Name = "Email_Column";
            this.Email_Column.ReadOnly = true;

            // Button Columns (names MUST match the checks: "View", "Edit", "Delete")
            this.View_Col.HeaderText = "";
            this.View_Col.Name = "View";                      // <-- important
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;
            this.View_Col.Width = 60;

            this.Edit_Col.HeaderText = "";
            this.Edit_Col.Name = "Edit";                      // <-- important
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;
            this.Edit_Col.Width = 60;

            this.Delete_Col.HeaderText = "";
            this.Delete_Col.Name = "Delete";                  // <-- important
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;
            this.Delete_Col.Width = 70;

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ID_Column,
                this.Name_Column,
                this.City_Column,
                this.Phone_Column,
                this.Email_Column,
                this.View_Col,
                this.Edit_Col,
                this.Delete_Col
            });
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // ===== Add to Form =====
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);

            this.topPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
