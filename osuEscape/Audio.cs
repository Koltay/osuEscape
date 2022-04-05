namespace osuEscape
{
    class Audio
    {
        public static void ToggleSound(bool enabled)
        {
            if (enabled)
            {
                System.Media.SystemSounds.Asterisk.Play();
            }

        }
    }
}
