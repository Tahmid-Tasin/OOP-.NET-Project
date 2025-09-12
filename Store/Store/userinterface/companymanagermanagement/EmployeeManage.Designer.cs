using System.Drawing;

namespace Store.userinterface
{
    partial class EmployeeManage
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnToggleSearch = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtSearchMobile = new System.Windows.Forms.TextBox();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address_Coloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete_Col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelTop.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Gainsboro;
            this.panelTop.Controls.Add(this.btnAddNew);
            this.panelTop.Controls.Add(this.btnToggleSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1350, 50);
            this.panelTop.TabIndex = 0;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnAddNew.Location = new System.Drawing.Point(1240, 10);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 30);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnToggleSearch
            // 
            this.btnToggleSearch.Location = new System.Drawing.Point(10, 10);
            this.btnToggleSearch.Name = "btnToggleSearch";
            this.btnToggleSearch.Size = new System.Drawing.Size(100, 30);
            this.btnToggleSearch.TabIndex = 0;
            this.btnToggleSearch.Text = "Search";
            this.btnToggleSearch.UseVisualStyleBackColor = true;
            this.btnToggleSearch.Click += new System.EventHandler(this.btnToggleSearch_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Silver;
            this.searchPanel.Controls.Add(this.lblName);
            this.searchPanel.Controls.Add(this.txtSearchName);
            this.searchPanel.Controls.Add(this.lblMobile);
            this.searchPanel.Controls.Add(this.txtSearchMobile);
            this.searchPanel.Controls.Add(this.btnDoSearch);
            this.searchPanel.Controls.Add(this.btnResetSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 50);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1350, 60);
            this.searchPanel.TabIndex = 1;
            this.searchPanel.Visible = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(130, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(185, 19);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(180, 20);
            this.txtSearchName.TabIndex = 1;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(385, 20);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(50, 20);
            this.lblMobile.TabIndex = 2;
            this.lblMobile.Text = "Mobile:";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchMobile
            // 
            this.txtSearchMobile.Location = new System.Drawing.Point(440, 19);
            this.txtSearchMobile.Name = "txtSearchMobile";
            this.txtSearchMobile.Size = new System.Drawing.Size(180, 20);
            this.txtSearchMobile.TabIndex = 3;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(640, 17);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(90, 25);
            this.btnDoSearch.TabIndex = 4;
            this.btnDoSearch.Text = "Search";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Location = new System.Drawing.Point(740, 17);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(90, 25);
            this.btnResetSearch.TabIndex = 5;
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Visible = false;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Coloumn,
            this.Name_Coloumn,
            this.Mobile_Coloumn,
            this.Address_Coloumn,
            this.View_Col,
            this.Edit_Col,
            this.Delete_Col});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = true;
            this.dataGridView1.Size = new System.Drawing.Size(1350, 619);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID_Coloumn
            // 
            this.ID_Coloumn.HeaderText = "ID";
            this.ID_Coloumn.Name = "ID_Coloumn";
            this.ID_Coloumn.ReadOnly = true;
            // 
            // Name_Coloumn
            // 
            this.Name_Coloumn.HeaderText = "Name";
            this.Name_Coloumn.Name = "Name_Coloumn";
            this.Name_Coloumn.ReadOnly = true;
            // 
            // Mobile_Coloumn
            // 
            this.Mobile_Coloumn.HeaderText = "Mobile";
            this.Mobile_Coloumn.Name = "Mobile_Coloumn";
            this.Mobile_Coloumn.ReadOnly = true;
            // 
            // Address_Coloumn
            // 
            this.Address_Coloumn.HeaderText = "Address";
            this.Address_Coloumn.Name = "Address_Coloumn";
            this.Address_Coloumn.ReadOnly = true;
            // 
            // View_Col
            // 
            this.View_Col.HeaderText = "View";
            this.View_Col.Name = "View_Col";
            this.View_Col.Text = "View";
            this.View_Col.UseColumnTextForButtonValue = true;
            this.View_Col.Width = 70;
            // 
            // Edit_Col
            // 
            this.Edit_Col.HeaderText = "Edit";
            this.Edit_Col.Name = "Edit_Col";
            this.Edit_Col.Text = "Edit";
            this.Edit_Col.UseColumnTextForButtonValue = true;
            this.Edit_Col.Width = 70;
            // 
            // Delete_Col
            // 
            this.Delete_Col.HeaderText = "Delete";
            this.Delete_Col.Name = "Delete_Col";
            this.Delete_Col.Text = "Delete";
            this.Delete_Col.UseColumnTextForButtonValue = true;
            this.Delete_Col.Width = 70;
            // 
            // EmployeeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.panelTop);
            this.Name = "EmployeeManage";
            this.Text = "EmployeeManage";
            this.panelTop.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnToggleSearch;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtSearchMobile;
        private System.Windows.Forms.Button btnDoSearch;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile_Coloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address_Coloumn;
        private System.Windows.Forms.DataGridViewButtonColumn View_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Edit_Col;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_Col;
    }
}
