using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osuEscape
{
    internal static class NativeMethods
    {
        // Importing user32.dll methods for registering and unregistering hotkeys
        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    public sealed class KeyboardHook : IDisposable
    {
        private class Window : NativeWindow, IDisposable
        {
            private const int WM_HOTKEY = 0x0312; // Hotkey message identifier

            public Window()
            {
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // Check if the message is a hotkey message
                if (m.Msg == WM_HOTKEY)
                {
                    // Extract key and modifier from the message parameters
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // Raise the KeyPressed event
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            public void Dispose()
            {
                this.DestroyHandle();
            }
        }

        private readonly Window _window = new();
        private int _currentId;

        public KeyboardHook()
        {
            // Subscribe to the KeyPressed event of the inner window
            _window.KeyPressed += (sender, args) => KeyPressed?.Invoke(this, args);
        }

        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            _currentId++;

            // Register the hotkey and throw an exception if it fails
            if (!NativeMethods.RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Dispose()
        {
            // Unregister all registered hotkeys
            for (int i = _currentId; i > 0; i--)
            {
                NativeMethods.UnregisterHotKey(_window.Handle, i);
            }

            // Dispose the inner native window
            _window.Dispose();
        }
    }

    public class KeyPressedEventArgs : EventArgs
    {
        public ModifierKeys Modifier { get; }
        public Keys Key { get; }

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            Modifier = modifier;
            Key = key;
        }
    }

    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}
