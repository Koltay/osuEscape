using System.Reflection;

namespace osuEscape.Models
{
    public class StartupManager
    {
        private readonly string _startupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private readonly string _startupValue = Assembly.GetExecutingAssembly().GetName().Name;
        public string StartupKey => _startupKey;
        public string StartupValue => _startupValue;
    }
}