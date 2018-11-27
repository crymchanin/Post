using OASU_RPO.Configuration;
using Feodosiya.Lib.Conf;
using Feodosiya.Lib.Logs;


namespace OASU_RPO {
    /// <summary>
    /// Вспомогательные методы и свойства
    /// </summary>
    public static class AppHelper {

        /// <summary>
        /// GUID приложения
        /// </summary>
        public static string GUID { get; set; }

        /// <summary>
        /// Конфигурационный файл
        /// </summary>
        public static ConfHelper ConfHelper { get; set; }

        /// <summary>
        /// Конфигурация программы
        /// </summary>
        public static Config Configuration { get; set; }

        /// <summary>
        /// Лог файл программы
        /// </summary>
        public static Log Log { get; set; }
    }
}
