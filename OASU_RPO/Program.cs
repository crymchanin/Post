using Feodosiya.Lib.IO;
using Feodosiya.Lib.Logs;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;


namespace OASU_RPO {
    static class Program {

        public static string ProductName { get; set; }

        public static string CurrentDirectory { get; set; }


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            try {
                ProductName = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
                CurrentDirectory = IOHelper.GetCurrentDir(Assembly.GetExecutingAssembly());
                AppHelper.Log = new Log(Path.Combine(CurrentDirectory, ProductName + ".log")) { InsertDate = true, AutoCompress = true };

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AppHelper.GUID = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;
                string mutexId = string.Format("Global\\{{{0}}}", AppHelper.GUID);
                bool createdNew;
                MutexAccessRule allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    MutexRights.FullControl, AccessControlType.Allow);
                MutexSecurity securitySettings = new MutexSecurity();
                securitySettings.AddAccessRule(allowEveryoneRule);

                using (Mutex mutex = new Mutex(false, mutexId, out createdNew, securitySettings)) {
                    bool hasHandle = false;

                    try {
                        try {
                            hasHandle = mutex.WaitOne(3000, false);
                            if (hasHandle == false) {
                                MessageBox.Show("Программа уже запущена", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                        }
                        catch (AbandonedMutexException err) {
                            try {
                                AppHelper.Log.Write("Ошибка синхронизации Mutex: " + err.ToString(), MessageType.Error);
                            }
                            catch (Exception error) {
                                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            hasHandle = true;
                        }

                        Application.Run(new MainForm());
                    }
                    finally {
                        if (hasHandle) {
                            mutex.ReleaseMutex();
                        }
                    }
                }
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
