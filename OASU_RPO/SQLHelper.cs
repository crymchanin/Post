using Feodosiya.Lib.Security;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;


namespace OASU_RPO {
    /// <summary>
    /// Предоставляет методы ля работы с Firebird SQL
    /// </summary>
    public static class SQLHelper {

        /// <summary>
        /// Проверяет успешность подключения к серверу Firebird с указанными параметрами
        /// </summary>
        /// <param name="message">Возвращает текст ошибки подключения при ее наличии</param>
        /// <returns></returns>
        public static bool CheckConnection(out string message) {
            try {
                message = string.Empty;
                string connStr = string.Format("User={0};Password={1};Database={2};DataSource={3};Pooling={4};Connection lifetime={5};Charset={6};",
                    AppHelper.Configuration.FBConnection.Username.GetDecryptedString(), AppHelper.Configuration.FBConnection.Password.GetDecryptedString(),
                    AppHelper.Configuration.FBConnection.Database, AppHelper.Configuration.FBConnection.Datasource, AppHelper.Configuration.FBConnection.Pooling.ToString().ToLower(),
                    AppHelper.Configuration.FBConnection.ConnectionLifetime, AppHelper.Configuration.FBConnection.Charset);

                using (FbConnection connection = new FbConnection(connStr)) {
                    connection.Open();
                }
            }
            catch(Exception error) {
                message = error.Message;
                return false;
            }

            return true;
        }

       /// <summary>
       /// Получает список файлов которые были выгружены за заданный период
       /// </summary>
       /// <param name="daysAgo">Количество дней до текущего дня</param>
       /// <returns></returns>
        public static IEnumerable<FileInfo> GetCreatedFiles(int daysAgo) {
            string connStr = string.Format("User={0};Password={1};Database={2};DataSource={3};Pooling={4};Connection lifetime={5};Charset={6};",
                AppHelper.Configuration.FBConnection.Username.GetDecryptedString(), AppHelper.Configuration.FBConnection.Password.GetDecryptedString(),
                AppHelper.Configuration.FBConnection.Database, AppHelper.Configuration.FBConnection.Datasource, AppHelper.Configuration.FBConnection.Pooling.ToString().ToLower(),
                AppHelper.Configuration.FBConnection.ConnectionLifetime, AppHelper.Configuration.FBConnection.Charset);

            using (FbConnection connection = new FbConnection(connStr)) {
                connection.Open();

                string cmd = "SELECT FILENAME, TIMEEND, OPERATIONID " +
                                "FROM OPERATION " +
                                "WHERE TIMEEND >= (CURRENT_DATE - " + daysAgo.ToString() + ") " +
                                "AND TIMEEND <= (CURRENT_DATE + 1) " +
                                "AND FILENAME LIKE '298199%' " +
                                "AND OPERATIONTYPEID = 14 " +
                                "ORDER BY TIMEEND";
                using (FbCommand command = new FbCommand(cmd, connection)) {
                    using (FbTransaction transaction = connection.BeginTransaction()) {
                        command.Transaction = transaction;
                        using (FbDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                yield return new FileInfo((int)reader["OPERATIONID"], (string)reader["FILENAME"], (DateTime)reader["TIMEEND"]);
                            }
                        }
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
