using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    /// <summary>
    /// CLASS
    /// Extends from Abstract class APlayer and implements methods
    /// </summary>
    internal class UserPlayer : APlayer
    {
       // private string _email;
       // private readonly Guid _id = Guid.NewGuid();

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserPlayer()
        {
            base._name = "";
            base._email = "";
            base._level = 1;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public UserPlayer(string name, string email)
        {
            base._name = name;
            base._email = email;
            base._level = 1;
        }

        /// <summary>
        /// This method allows user to retrieve and set Name
        /// </summary>
        public string Name { get { return base._name; } set { base._name = value; } }

        /// <summary>
        /// This method allows user to retrieve and set Email
        /// </summary>
        public string Email { get { return base._email; } set { base._email = value; } }

        /// <summary>
        /// This method only allows user to retrieve ID
        /// </summary>
        public Guid Id { get { return base._id; } }

        /// <summary>
        /// This method retrieves and sets power level
        /// </summary>
        public int Level { get { return base._level; } set { base._level = value; } }

        /// <summary>
        /// These two methods are delegates to allow developer to create custom Print methods
        /// </summary>
        /// <param name="p"></param>
        public delegate void PrintUserPlayerInfo(UserPlayer p);
        public void Print(PrintUserPlayerInfo printUserPlayer, UserPlayer p) { printUserPlayer(p); }

        //public override void Print(APlayer a)
        //{
        //  Console.WriteLine(a.Name);
        //}
    }
}
