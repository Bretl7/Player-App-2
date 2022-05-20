using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    /// <summary>
    /// ABSTRACT CLASS
    /// Extends interface IPlayer. Bot and UserPlayer inherit from this bastract class
    /// </summary>
    internal abstract class APlayer : IPlayer
    {
        protected string _name;
        protected string _email;
        protected readonly Guid _id = Guid.NewGuid();

        /// <summary>
        /// This method retrieves ID. Extension of interface IPlayer,
        /// and is extended by Bot.cs and UserPlayer.cs
        /// </summary>
        public Guid Id { get { return _id; } }

        /// <summary>
        /// This method retrieves and set Name. Extension of interface IPlayer,
        /// and is extended by Bot.cs and UserPlayer.cs
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// This method retrieves and set Email. Extension of interface IPlayer,
        /// and is extended by Bot.cs and UserPlayer.cs
        /// </summary>
        public string Email { get { return _email; } set { _email = value; } }
    }
}
