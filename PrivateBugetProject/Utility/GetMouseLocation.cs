using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Utility
{
    public static class GetMouseLocation
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        }
        public static Point GetMousePosition()
        {
            Win32Point CursorLocation = new Win32Point();
            GetCursorPos(ref CursorLocation);
            return new Point(CursorLocation.X, CursorLocation.Y);
        }

    }
}
