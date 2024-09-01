using OsuMemoryDataProvider.OsuMemoryModels;
using System.Windows.Forms;

namespace osuEscape
{
    public partial class UploadedScoresForm : Form
    {
        public UploadedScoresForm()
        {
            InitializeComponent();
        }

        // Method to update the scores in the ListView
        public void UpdateScores(OsuBaseAddresses baseAddresses)
        {
            // Use Invoke to ensure the code runs on the UI thread
            this.Invoke(new MethodInvoker(() =>
            {
                // Create a new ListViewItem with the map string
                ListViewItem item = new(baseAddresses.Beatmap.MapString);
                
                // Add subitems for score and accuracy
                item.SubItems.Add(baseAddresses.Player.Score.ToString());
                item.SubItems.Add(baseAddresses.Player.Accuracy.ToString("0.00"));
                
                // Add the item to the ListView
                materialListView_uploadedScores.Items.Add(item);
            }));
        }
    }
}
