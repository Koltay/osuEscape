// FormManager.cs
using osuEscape;
using System;

namespace osuEscape.Models
{
    public class FormManager
    {
        // Private readonly fields to hold the form instances
        private readonly MainForm _mainForm;
        private readonly SettingsForm _settingsForm;
        private readonly UploadedScoresForm _uploadedScoresForm;

        // Constructor to initialize the form instances
        public FormManager(MainForm mainForm, SettingsForm settingsForm, UploadedScoresForm uploadedScoresForm)
        {
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _settingsForm = settingsForm ?? throw new ArgumentNullException(nameof(settingsForm));
            _uploadedScoresForm = uploadedScoresForm ?? throw new ArgumentNullException(nameof(uploadedScoresForm));
        }

        public FormManager() {

        }

        // Public properties to access the form instances
        public MainForm MainForm => _mainForm;
        public SettingsForm SettingsForm => _settingsForm;
        public UploadedScoresForm UploadedScoresForm => _uploadedScoresForm;
    }
}