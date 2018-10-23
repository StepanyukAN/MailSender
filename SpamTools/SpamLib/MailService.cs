using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    /// <summary>Рассылка почты</summary>
    public class MailService
    {
        /// <summary>Тема письма</summary>
        private string _subject;

        /// <summary>Текст письма</summary>
        private string _mailText;

        /// <summary>От кого</summary>
        public string From { get; set; } = "fargogimoney@yandex.ru";

        /// <summary>Кому</summary>
        public string To { get; set; } = "fargogi85@gmail.com";

        /// <summary>Логин</summary>
        private string _login;

        /// <summary>Пароль</summary>
        private SecureString _password;

        /// <summary>Делегат для события ошибки</summary>
        /// <param name="message">Текст ошибки</param>
        public delegate void ErrorDelegate(string message);

        /// <summary>Делегат для события Complete</summary>
        public delegate void CompleteDelegate();
        
        /// <summary>Событие ошибки</summary>
        public static event ErrorDelegate Error;

        /// <summary>Событие удачного завершения</summary>
        public static event CompleteDelegate Complete;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="mailText">Текст письма</param>
        public MailService(string login, SecureString password, string subject, string mailText)
        {
            _login = login;
            _password = password;
            _subject = subject;
            _mailText = mailText;
            Send();
        }

        /// <summary>Метод отправки письма</summary>
        private void Send()
        {
            try
            {
                using (var email = new MailMessage(From, To))
                {
                    email.Subject = _subject;
                    email.Body = _mailText;

                    using (var client = new SmtpClient(DataBase.Host, DataBase.Port))
                    {
                        client.Credentials = new NetworkCredential(_login, _password);
                        client.EnableSsl = true;

                        client.Send(email);
                    }
                }
            }
            catch (Exception error)
            {
                Error?.Invoke(error.Message);
                return;
            }

            Complete?.Invoke();
        }
    }
}
