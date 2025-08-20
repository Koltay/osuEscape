namespace osuEscape
{
    public static class Audio
    {
        // Method to toggle sound based on the enabled flag
        public static void ToggleSound(bool enabled)
        {
            if (enabled)
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }
    }
}