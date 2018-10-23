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
using System.Windows.Shapes;

namespace MailSenderGUI
{
    /// <summary>
    /// Окно ошибки
    /// </summary>
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string message)
        {
            
            InitializeComponent();
            txtError.Text = message;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
