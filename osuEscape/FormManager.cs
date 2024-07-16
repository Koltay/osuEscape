// FormManager.cs
using osuEscape;
using System;

namespace osuEscape
{
    public class FormManager
    {
        private readonly MainForm _mainForm;
        private readonly SettingsForm _settingsForm;
        private readonly UploadedScoresForm _uploadedScoresForm;

        public MainForm MainForm => _mainForm;
        public SettingsForm SettingsForm => _settingsForm;
        public UploadedScoresForm UploadedScoresForm => _uploadedScoresForm;
    }
}
