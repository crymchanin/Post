using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;


namespace Updater.Updates {
    public static class UpdatesHelper {

        /// <summary>
        /// Проверяет наличие обновлений на сервере
        /// </summary>
        /// <param name="curVerStr">Текущая версия программы</param>
        /// <returns></returns>
        public static bool CheckUpdates(string curVerStr, string serverName, string productName) {
            string url = serverName + "?method=getVersion&appName=" + productName;
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
        public static string DownloadPackage(string serverName, string productName) {
            string url = serverName + "?method=getPackage&appName=" + productName;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse()) {
                using (Stream stream = resp.GetResponseStream()) {
                    if (resp.Headers[HttpResponseHeader.ContentType] == "application/octet-stream") {
                        string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), productName + ".pkg");
                        using (FileStream file = File.OpenWrite(fileName)) {
                            stream.CopyTo(file);

                            return fileName;
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

        public static void InstallUpdate(string fileName) {
            using (ZipInputStream zipStream = new ZipInputStream(File.OpenRead(fileName))) {
                ZipEntry zipEntry = zipStream.GetNextEntry();
                while (zipEntry != null) {
                    string zipEntryName = zipEntry.Name;
                    byte[] buffer = new byte[4096];
                    string fullZipToPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), zipEntryName);
                    string dirName = Path.GetDirectoryName(fullZipToPath);
                    if (dirName.Length > 0) {
                        if (!Directory.Exists(dirName)) {
                            Directory.CreateDirectory(dirName);
                        }
                    }
                    if (Path.GetFileName(fullZipToPath).Length == 0) {
                        zipEntry = zipStream.GetNextEntry();
                        continue;
                    }
                    using (FileStream streamWriter = File.Create(fullZipToPath)) {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }

                    zipEntry = zipStream.GetNextEntry();
                }
            }

            File.Delete(fileName);
        }
    }
}
