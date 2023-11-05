using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftTypeGame
{
    public enum AnimalType
    {
        Dog,
        Horse,
        Pig,
        Cat,
        Creeper
    }

    public class Animal : BaseCharacter
    {
        private bool _isFriendly;
        private AnimalType _type;

        public Animal(int locationX, int locationY, bool isFriendly, AnimalType type) : base(locationX, locationY)
        {
            _isFriendly = isFriendly;
            _type = type;
        }

        public AnimalType Type
        {
            get { return _type; }
        }

        public bool IsFriendly
        {
            get => _isFriendly;
            set => _isFriendly = value;
        }
    }
}
