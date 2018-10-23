namespace SpamLib
{
    /// <summary>База данных</summary>
    public static class DataBase
    {
        // Пока только может отправлять с яндекса. 

        /// <summary>
        /// Хост
        /// </summary>
        public static string Host { get; set; } = "smtp.yandex.ru";

        /// <summary>
        /// Порт
        /// </summary>
        public static int Port { get; set; } = 25;
    }
}
