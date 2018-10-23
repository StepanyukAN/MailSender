using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpamLib;

namespace MailSenderGUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор. В нем подписываемся на события созданные в MailService.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MailService.Error += ShowError;
            MailService.Complete += CompleteShow;
        }

        /// <summary>
        /// Показ формы, если все закончилось удачно.
        /// </summary>
        private void CompleteShow()
        {
            SendCompleteDialog scd = new SendCompleteDialog();
            scd.ShowDialog();
        }

        /// <summary>
        /// Показ формы, если произошла ошибка.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        private void ShowError(string message)
        {
            ErrorDialog ed = new ErrorDialog(message);
            ed.ShowDialog();
        }

        /// <summary>
        /// Создаем экземпляр MailService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            MailService ms = new MailService(txtLogin.Text, passBoxPassword.SecurePassword, txtSubject.Text, txtMailText.Text );
        }
    }
}
