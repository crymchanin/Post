using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;


namespace OASU_RPO.GUI {
    public partial class AboutWindow : Form {

        private const string Organisation   = "ФГУП \"Почта Крыма\"";
        private const string Author         = "Анатолий Карпекин";
        private const string Email          = "anatoliy.karpekin@crimeanpost.ru";
        private const string Phone          = "(0-262) 3-17-98";
        private const string City           = "г. Феодосия, 2018 г.";

        public AboutWindow() {
            InitializeComponent();

            try {
                FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                HeaderLabel.Text = fileInfo.FileDescription;
                VersionLabel.Text = string.Format("версия: {0}", fileInfo.FileVersion);
                InfoLabel.Text = string.Format("Организация: {0}\r\nАвтор: {1}\r\nE-mail: {2}\r\nТелефон: {3}\r\n{4}\r\n",
                    Organisation, Author, Email, Phone, City);

                string assemblies = "";
                AppDomain domain = AppDomain.CreateDomain("temporary");
                foreach (AssemblyName assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies()) {
                    Assembly assembly = domain.Load(assemblyName.FullName);
                    fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                    if (fileInfo.ProductName == "Microsoft® .NET Framework") {
                        continue;
                    }
                    assemblies += string.Format("{0} v.{1}\r\n", assemblyName.Name, assemblyName.Version);
                }
                AppDomain.Unload(domain);
                AssembliesLabel.Text = assemblies;
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
