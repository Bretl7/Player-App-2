using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    /// <summary>
    /// This Interface is used for Program.cs
    /// and Player.cs files. It permits for the 
    /// program to retrieve a user's ID, get and
    /// set a user's Name, and get and set a user's Email
    /// </summary>
    internal interface IPlayer
    {
        /// <summary>
        /// This method allows the user to only retrieve a player's ID
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// This method allows the user to retrieve and set Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// This method allows the user to retrieve and set Email
        /// </summary>
        string Email { get; set; }
    }
}
