using OsuMemoryDataProvider.OsuMemoryModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class UploadedScoresForm : Form
    {
        public UploadedScoresForm()
        {
            InitializeComponent();
        }

        public void UpdateScores(OsuBaseAddresses baseAddresses)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                ListViewItem item = new(baseAddresses.Beatmap.MapString);
                item.SubItems.Add(baseAddresses.Player.Score.ToString());
                item.SubItems.Add(baseAddresses.Player.Accuracy.ToString("0.00"));
                // rank icon TBD
                // pp TBD
                materialListView_uploadedScores.Items.Add(item);
            }));
        }
    }
}
