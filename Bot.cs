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
    internal class Bot : APlayer
    {
        /// <summary>
        /// Constructor that automatically names the bot upon instantiation
        /// </summary>
        public Bot()
        {
            base._name = "bot_" + base._id.ToString().Substring(0, 7);
        }

        /// <summary>
        /// This method allows user to only retrieve name of Bot
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// This method allows user to only retrieve ID
        /// </summary>
        public Guid Id { get { return _id; } }

        /// <summary>
        /// This delegate allows developer to create custom Print methods
        /// </summary>
        /// <param name="b"></param>
        public delegate void PrintBotInfo(APlayer b);
        public void Print(PrintBotInfo printBot, Bot b) { printBot(b); }

       // public override void Print(APlayer b)
       // {
           // Console.WriteLine("Bot Name: " + b.Name +
                              //"\nID: " + b.Id);
       // }
    }
}
