using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.entity
{
    class Member
    {
        private string _name;
        private string _phone;
        private string _email;

        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
