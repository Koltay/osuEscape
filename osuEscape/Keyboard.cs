using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public class Keyboard
    {
        public Keyboard()
        {
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct Input
        {
            [FieldOffset(0)]
            public uint type;
            [FieldOffset(4)]
            public KeyboardInput ki;
        }

        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public long time;
            public uint dwExtraInfo;
        }

        const int KEYEVENTF_KEYUP = 0x0002;
        const int INPUT_KEYBOARD = 1;

        [DllImport("user32.dll")]
        public static extern int SendInput(uint cInputs, ref Input inputs, int cbSize);

        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        static extern ushort MapVirtualKey(int wCode, int wMapType);


        public static bool IsKeyDown(Keys key)
        {
            return (GetKeyState((int)key) & -128) == -128;
        }

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag

        public static void HoldKey(byte key, int duration)
        {
            int totalDuration = 0;
            while (totalDuration < duration)
            {
                keybd_event(key, 0, KEY_DOWN_EVENT, 0);
                keybd_event(key, 0, KEY_UP_EVENT, 0);
                int PauseBetweenStrokes = 1;
                System.Threading.Thread.Sleep(PauseBetweenStrokes);
                totalDuration += PauseBetweenStrokes;
            }


        }

        public static void ReleaseKey(Keys vk)
        {
            ushort nScan = MapVirtualKey((ushort)vk, 0);

            Input input = new Input();
            input.type = INPUT_KEYBOARD;
            input.ki.wVk = (ushort)vk;
            input.ki.wScan = nScan;
            input.ki.dwFlags = KEYEVENTF_KEYUP;
            input.ki.time = 0;
            input.ki.dwExtraInfo = 0;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }

        public static void PressKey(Keys vk, int duration)
        {
            //HoldKey((byte)vk, duration);
            //ReleaseKey(vk);

            //HoldKey
            int totalDuration = 0;
            while (totalDuration < duration)
            {
                keybd_event((byte)vk, 0, KEY_DOWN_EVENT, 0);
                //keybd_event((byte)vk, 0, KEY_UP_EVENT, 0);
                int PauseBetweenStrokes = 1;
                System.Threading.Thread.Sleep(PauseBetweenStrokes);
                totalDuration += PauseBetweenStrokes;
            }


            //Release Key
            ushort nScan = MapVirtualKey((ushort)vk, 0);

            Input input = new Input();
            input.type = INPUT_KEYBOARD;
            input.ki.wVk = (ushort)vk;
            input.ki.wScan = nScan;
            input.ki.dwFlags = KEYEVENTF_KEYUP;
            input.ki.time = 0;
            input.ki.dwExtraInfo = 0;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }
    }
}
