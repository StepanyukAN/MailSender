using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public class Senders
    {
        public static readonly ObservableCollection<Sender> Items =
            new ObservableCollection<Sender>(new[]
            {
                new Sender{ Name = "Ivanov", Email = "ivanov@server.org", Password = PasswordEncoder.Encode("Password1")},
                new Sender{ Name = "Petrov", Email = "petrov@server.org", Password = PasswordEncoder.Encode("Password2")},
                new Sender{ Name = "Sidorov", Email = "sidorov@server.org", Password = PasswordEncoder.Encode("Password3")},
            });
    }
}
