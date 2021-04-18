using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UsersMettlerToledoApp
{
    class XmlAdapter : FormatAdapter
    {
        public XmlAdapter(string filePath) : base(filePath)
        {
            FilePath = filePath;
        }

        public override void ReadFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UsersXML));
            UsersXML usersXML;

            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                usersXML = (UsersXML)serializer.Deserialize(reader);                
            }
            SetUsers(usersXML);          
        }


        private void SetUsers(UsersXML usersXML)
        {
            List<User> users = new List<User>();

            foreach (var userXML in usersXML.UsersList)
            {
                users.Add(new User { Imie = userXML.Imie, Nazwisko = userXML.Nazwisko, Email = userXML.Email });

            }
            Users = users;

        }         
        
    }
    [XmlRoot("Users")]
    public class UsersXML
    {
        [XmlElement("User",Type = typeof(UserXML))]
        public List<UserXML> UsersList;
    }

    [XmlRoot("User")]
    public class UserXML
    {
        [XmlElement]
        public string Imie { get; set; }
        [XmlElement]
        public string Nazwisko { get; set; }
        [XmlElement]
        public string Email { get; set; }
    }
}
