using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMettlerToledoApp
{
    public class User
    {
        
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }


        public string FullInfo {
            get => Imie + " " + Nazwisko + " " + Email;           
            }

    }
}
