using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    internal class Bot : APlayer
    {
        public Bot()
        {
            base._name = "bot_" + base._id.ToString().Substring(0, 7);
        }

        public string Name { get { return _name; } }

        public Guid Id { get { return _id; } }

        public delegate void PrintBotInfo(APlayer b);
        public void Print(PrintBotInfo printBot, Bot b) { printBot(b); }
       // public override void Print(APlayer b)
       // {
           // Console.WriteLine("Bot Name: " + b.Name +
                              //"\nID: " + b.Id);
       // }
    }
}
