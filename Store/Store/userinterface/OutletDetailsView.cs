using System.Windows.Forms;
using Store.Service;

namespace Store.userinterface
{
    public partial class OutletDetailsView : Form
    {
        private readonly OutletService _outletService;

        public OutletDetailsView(int outletId)
        {
            InitializeComponent();
            _outletService = new OutletService();
            LoadDetails(outletId);
        }

        private void LoadDetails(int outletId)
        {
            var outlet = _outletService.Get(outletId);
            if (outlet != null)
            {
                OutletNameLabel.Text = outlet.Name;

                BranchGrid.Rows.Clear();
                foreach (var b in outlet.Branches)
                {
                    BranchGrid.Rows.Add(b.Name);
                }
            }
        }
    }
}
