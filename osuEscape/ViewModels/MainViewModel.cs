using osuEscape.Models;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace osuEscape
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonCommand { get; private set; }

        public MainViewModel()
        {
            ButtonCommand = new RelayCommand(ShowMessage);
        }

        private void ShowMessage(object obj)
        {
            MessageBox.Show("Button clicked");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
