using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;

namespace GS1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowError(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowError(e.ExceptionObject as Exception);
        }

        private static void ShowError(Exception ex)
        {
            string message = "An unexpected error occurred.";
            string details = ex?.ToString() ?? "No exception details.";
            string logPath = null;

            if (ex is MySqlException || ex?.InnerException is MySqlException)
            {
                message = "Database connection is unstable. Please check internet/Railway and try again.";
            }
            else if (ex != null)
            {
                message = ex.Message;
            }

            try
            {
                logPath = Path.Combine(Application.StartupPath, "error.log");
                var sb = new StringBuilder();
                sb.AppendLine("==== GS1 ERROR ====");
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.AppendLine(details);
                sb.AppendLine();
                File.AppendAllText(logPath, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
                // Intentionally ignore logging failures.
            }

            var uiMessage = logPath == null
                ? message
                : message + Environment.NewLine + Environment.NewLine + "Details saved to: " + logPath;

            MessageBox.Show(uiMessage, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
