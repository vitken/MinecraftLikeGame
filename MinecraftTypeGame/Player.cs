using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftTypeGame
{
    public class Player : BaseCharacter
    {
        private string _name;

        public Player(int locationX, int locationY, string name) : base(locationX, locationY)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
