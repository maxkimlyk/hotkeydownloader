using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HotkeyDownloader
{
    class Hotkey
    {
        public enum Modifiers
        {
            None = 0x0000,
            Alt = 0x0001,
            Ctrl = 0x0002,
            NoRepeat = 0x4000,
            Shift = 0x0004,
            Win = 0x0008
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IntPtr windowHandle;
        public int id = 0;

        public Hotkey(IntPtr hWnd)
        {
            windowHandle = hWnd;
        }

        public bool Register(Modifiers modifiers, Keys key)
        {
            id = (int)(modifiers) + (int)(key) << 16;
            return RegisterHotKey(windowHandle, id, (int)(modifiers), (int)(key));
        }

        public bool Unregister()
        {
            return UnregisterHotKey(windowHandle, 1);
        }

        public bool IsPressed(ref Message m)
        {
            const int WM_HOTKEY = 0x312;
            return (m.Msg == WM_HOTKEY && (int)m.WParam == id);
        }
    }
}