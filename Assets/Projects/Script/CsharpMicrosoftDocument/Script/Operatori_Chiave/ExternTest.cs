using System;
using System.Runtime.InteropServices;

class ExternTest
{
    // Importa MessageBox da User32.dll (Windows)
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, int type);

    static void Main()
    {
        MessageBox(IntPtr.Zero, "Hello from C#", "My messagebox", 0);
    }
}