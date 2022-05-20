using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    internal class UserPlayer : APlayer
    {
        private string _email;
        private readonly Guid _id = Guid.NewGuid();

        public UserPlayer()
        {
            base._name = "";
            _email = "";
        }

        public UserPlayer(string name, string email)
        {
            base._name = name;
            _email = email;
        }

        public string Name { get { return _name; } set { _name = value; } }

        public string Email { get { return _email; } set { _email = value; } }

        public Guid Id { get { return _id; } }

        public delegate void PrintUserPlayerInfo(UserPlayer p);
        public void Print(PrintUserPlayerInfo printUserPlayer, UserPlayer p) { printUserPlayer(p); }

        //public override void Print(APlayer a)
        //{
        //  Console.WriteLine(a.Name);
        //}
    }
}
