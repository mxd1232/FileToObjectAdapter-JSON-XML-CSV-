using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMettlerToledoApp
{
    abstract class FormatAdapter
    {
        public string FilePath { get; protected set; }
        public FormatAdapter(string filePath)
        {
            FilePath = filePath;
        }

        public List<User> Users
        {
            get;
            protected set;
        }

        public string GetUsersInfo()
        {
            if(Users==null)
            {
                return "Plik jest pusty";
            }


         //   StringBuilder strBuilder = new StringBuilder("Imię, Nazwisko, Email");
            StringBuilder strBuilder = new StringBuilder();
            foreach (var user in Users)
            {
                strBuilder.AppendLine();
                strBuilder.Append(user.Imie + " " + user.Nazwisko + " " + user.Email);
            }

            string userInfo = strBuilder.ToString();

            return userInfo;
        }
        public abstract void ReadFromFile();
    }
}
