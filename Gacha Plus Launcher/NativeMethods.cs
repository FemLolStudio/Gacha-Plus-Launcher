using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gacha_Plus_Launcher
{
    class NativeMethods
    {
        public const int GWL_STYLE = -16;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_POPUP = unchecked((int)0x80000000);
        public const int SW_MAXIMIZE = 3;
        public const int SWP_NOZORDER = 0x0004;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
