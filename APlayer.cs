using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_App_2
{
    internal abstract class APlayer : IPlayer
    {
        protected string _name;
        protected string _email;
        protected readonly Guid _id = Guid.NewGuid();

        //public Guid Id => throw new NotImplementedException();
        public Guid Id { get { return _id; } }

        public string Name { get { return _name; } set { _name = value; } }
        //string IPlayer.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get { return _email; } set { _email = value; } }
        //public abstract string Name();

        //public abstract Guid GetId(); 

       
        //public abstract void Print(APlayer a);
    }
}
