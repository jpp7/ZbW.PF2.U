using System;
using System.Windows.Forms;
using MB15.SortComparison;

namespace MB15
{
    /// <summary>
    /// The Program class serves as the entry point for the application.
    /// This class is marked as static, indicating that it cannot be instantiated
    /// and is intended to house static members only.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Original from here:
        /// https://www.codeproject.com/Articles/1087568/Visualization-and-Comparison-of-sorting-algorith
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}