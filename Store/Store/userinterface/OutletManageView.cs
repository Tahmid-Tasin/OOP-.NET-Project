using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Store.Service;

namespace Store.userinterface
{
    public partial class OutletManageView : Form
    {
        private readonly OutletService _outletService;
        private List<Branch> branchList = new List<Branch>();
        private int editingOutletId = 0;

        public OutletManageView()
        {
            InitializeComponent();
            _outletService = new OutletService();
            LoadOutlets();
        }

        private void LoadOutlets()
        {
            OutletGrid.DataSource = null;
            OutletGrid.Rows.Clear();

            var outlets = _outletService.GetAll();
            foreach (var o in outlets)
            {
                OutletGrid.Rows.Add(o.ID, o.Name, "Edit", "Delete");
            }
        }

        private void AddBranchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BranchNameBox.Text))
            {
                MessageBox.Show("Enter a branch name.");
                return;
            }

            branchList.Add(new Branch
            {
                Name = BranchNameBox.Text.Trim(),
                Location = "" // can add a textbox for location if needed
            });

            BranchGrid.Rows.Add(BranchNameBox.Text.Trim(), "", "Delete");
            BranchNameBox.Text = "";
        }

        private void BranchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (BranchGrid.Columns[e.ColumnIndex].Name == "BranchDel_Col")
            {
                branchList.RemoveAt(e.RowIndex);
                BranchGrid.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void SaveUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OutletNameBox.Text))
            {
                MessageBox.Show("Enter outlet name.");
                return;
            }

            var outlet = new Outlet
            {
                ID = editingOutletId,
                Name = OutletNameBox.Text.Trim()
            };

            if (editingOutletId == 0)
            {
                _outletService.Create(outlet, branchList);
                MessageBox.Show("Outlet created successfully!");
            }
            else
            {
                _outletService.Update(outlet, branchList);
                MessageBox.Show("Outlet updated successfully!");
            }

            ResetForm();
            LoadOutlets();
        }

        private void OutletGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int outletId = (int)OutletGrid.Rows[e.RowIndex].Cells["OutletID_Col"].Value;

            if (OutletGrid.Columns[e.ColumnIndex].Name == "View_Col")
            {
                // open the new OutletDetailsView form
                var details = new OutletDetailsView(outletId);
                details.ShowDialog();
            }
            else if (OutletGrid.Columns[e.ColumnIndex].Name == "Edit_Col")
            {
                var outlet = _outletService.Get(outletId);
                if (outlet != null)
                {
                    editingOutletId = outlet.ID;
                    OutletNameBox.Text = outlet.Name;
                    branchList = outlet.Branches;

                    BranchGrid.Rows.Clear();
                    foreach (var b in branchList)
                    {
                        BranchGrid.Rows.Add(b.Name, "Delete");
                    }

                    SaveUpdateBtn.Text = "Update";
                }
            }
            else if (OutletGrid.Columns[e.ColumnIndex].Name == "Delete_Col")
            {
                if (MessageBox.Show("Delete this outlet?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _outletService.Delete(outletId);
                    LoadOutlets();
                }
            }
        }


        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            OutletNameBox.Text = "";
            BranchNameBox.Text = "";
            BranchGrid.Rows.Clear();
            branchList.Clear();
            editingOutletId = 0;
            SaveUpdateBtn.Text = "Save";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            var adm = new AdminView();
            adm.Show();
            this.Visible = false;
        }
    }
}
