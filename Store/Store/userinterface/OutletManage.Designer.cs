using System.Drawing;

namespace Store.userinterface
{
    partial class OutletManage
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.cbFilterToggle = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new System.Windows.Forms.Button();

            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.txtSearchAddress = new System.Windows.Forms.TextBox();
            this.txtSearchCity = new System.Windows.Forms.TextBox();
            this.txtSearchPostal = new System.Windows.Forms.TextBox();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();

            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // ===== Form =====
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Text = "Outlet Management";

            // ===== topPanel =====
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 56;
            this.topPanel.BackColor = Color.WhiteSmoke;
            this.topPanel.Controls.Add(this.cbFilterToggle);
            this.topPanel.Controls.Add(this.btnAddNew);
            this.topPanel.SizeChanged += new System.EventHandler(this.topPanel_SizeChanged);

            // cbFilterToggle (combo to show/hide filters)
            this.cbFilterToggle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterToggle.Items.AddRange(new object[] { "Hide Filters", "Show Filters" });
            this.cbFilterToggle.SelectedIndex = 0;
            this.cbFilterToggle.Location = new Point(12, 16);
            this.cbFilterToggle.Size = new Size(140, 21);
            this.cbFilterToggle.SelectedIndexChanged += new System.EventHandler(this.cbFilterToggle_SelectedIndexChanged);

            // btnAddNew (upper-right)
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.Size = new Size(100, 28);
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAddNew.Location = new Point(980, 14); // will be corrected in SizeChanged
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);

            // ===== filterPanel (hidden until Show Filters) =====
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Height = 54;
            this.filterPanel.BackColor = Color.Gainsboro;
            this.filterPanel.Visible = false;

            this.txtSearchName.Location = new Point(12, 16);
            this.txtSearchName.Size = new Size(150, 22);

            this.txtSearchPhone.Location = new Point(170, 16);
            this.txtSearchPhone.Size = new Size(120, 22);

            this.txtSearchAddress.Location = new Point(296, 16);
            this.txtSearchAddress.Size = new Size(180, 22);

            this.txtSearchCity.Location = new Point(482, 16);
            this.txtSearchCity.Size = new Size(120, 22);

            this.txtSearchPostal.Location = new Point(608, 16);
            this.txtSearchPostal.Size = new Size(100, 22);

            this.btnDoSearch.Text = "Search";
            this.btnDoSearch.Location = new Point(714, 15);
            this.btnDoSearch.Size = new Size(80, 24);
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);

            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.Location = new Point(800, 15);
            this.btnResetSearch.Size = new Size(80, 24);
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);

            this.filterPanel.Controls.Add(this.txtSearchName);
            this.filterPanel.Controls.Add(this.txtSearchPhone);
            this.filterPanel.Controls.Add(this.txtSearchAddress);
            this.filterPanel.Controls.Add(this.txtSearchCity);
            this.filterPanel.Controls.Add(this.txtSearchPostal);
            this.filterPanel.Controls.Add(this.btnDoSearch);
            this.filterPanel.Controls.Add(this.btnResetSearch);

            // ===== dataGridView1 =====
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ID_Column,
                this.Name_Column,
                this.City_Column,
                this.Phone_Column,
                this.Contact_Column,
                this.View_Col,
                this.Edit_Col,
                this.Delete_Col
            });
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // Columns
            this.ID_Column.HeaderText = "ID";
            this.ID_Column.Name = "ID_Column";
            this.Name_Column.HeaderText = "Name";
            this.Name_Column.Name = "Name_Column";
            this.City_Column.HeaderText = "City";
            this.City_Column.Name = "City_Column";
            this.Phone_Column.HeaderText = "Phone";
            this.Phone_Column.Name = "Phone_Column";
            this.Contact_Column.HeaderText = "Contact";
            this.Contact_Column.Name = "Contact_Column";

            this.View_Col.HeaderText = "";
            this.View_Col.Name = "View_Col";
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;
            this.View_Col.Width = 70;

            this.Edit_Col.HeaderText = "";
            this.Edit_Col.Name = "Edit_Col";
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;
            this.Edit_Col.Width = 70;

            this.Delete_Col.HeaderText = "";
            this.Delete_Col.Name = "Delete_Col";
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;
            this.Delete_Col.Width = 70;

            // add to form
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

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox cbFilterToggle;
        private System.Windows.Forms.Button btnAddNew;

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.TextBox txtSearchAddress;
        private System.Windows.Forms.TextBox txtSearchCity;
        private System.Windows.Forms.TextBox txtSearchPostal;
        private System.Windows.Forms.Button btnDoSearch;
        private System.Windows.Forms.Button btnResetSearch;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn City_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact_Column;
        private System.Windows.Forms.DataGridViewButtonColumn View_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Edit_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_Col;
    }
}
