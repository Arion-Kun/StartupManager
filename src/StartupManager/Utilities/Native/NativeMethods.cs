namespace Dawn.Apps.StartupManager.Native;

using System;
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    internal const int WM_NCHITTEST = 0x84;
    internal const int HTClient = 0x1;
    internal const int HT_CAPTION = 0x2;
    internal const int WM_NCLBUTTONDOWN = 0xA1;
    
    [DllImport("user32.dll")]
    internal static extern bool ReleaseCapture();
    
    [DllImport("user32.dll")]
    internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
}