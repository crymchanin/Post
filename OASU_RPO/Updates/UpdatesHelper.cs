using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;


namespace OASU_RPO.Updates {
    public static class UpdatesHelper {

        /// <summary>
        /// Проверяет наличие обновлений на сервере
        /// </summary>
        /// <param name="curVerStr">Текущая версия программы</param>
        /// <returns></returns>
        public static bool CheckUpdates(string curVerStr) {
            string url = AppHelper.Configuration.Global.UpdatesServerName + "?method=getVersion&appName=" + Program.ProductName;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse()) {
                using (StreamReader stream = new StreamReader(resp.GetResponseStream())) {
                    string json = stream.ReadToEnd();
                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseObject));

                        ResponseObject respObj = (ResponseObject)ser.ReadObject(ms);
                        if (respObj.success) {
                            Version newVersion = new Version(respObj.result);
                            Version currentVersion = new Version(curVerStr);

                            if (newVersion.CompareTo(currentVersion) > 0) {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Загружает пакет обновлений с сервера
        /// </summary>
        public static void DownloadPackage() {
            string url = AppHelper.Configuration.Global.UpdatesServerName + "?method=getPackage&appName=" + Program.ProductName;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse()) {
                using (Stream stream = resp.GetResponseStream()) {
                    if (resp.Headers[HttpResponseHeader.ContentType] == "application/octet-stream") {
                        using (FileStream file = File.OpenWrite(Program.ProductName + ".pkg")) {
                            stream.CopyTo(file);
                        }
                    }
                    else {
                        using (MemoryStream ms = new MemoryStream()) {
                            stream.CopyTo(ms);
                            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseObject));

                            ResponseObject respObj = (ResponseObject)ser.ReadObject(ms);
                            throw new Exception(respObj.result);
                        }
                    }
                }
            }
        }

        public static void InstallUpdate() {

        }
    }
}
