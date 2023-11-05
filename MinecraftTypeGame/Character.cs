using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftTypeGame
{
    public enum CharacterType
    {
        Villager,
        Warrior,
        King
    }

    public class Character : BaseCharacter
    {
        private bool _isFriendly;
        private CharacterType _type;
        private string _greetingPhrase;

        public Character(int locationX, int locationY, bool isFriendly, CharacterType characterType, string greetingPhrase) : base(locationX, locationY)
        {
            _isFriendly = isFriendly;
            _type = characterType;
            _greetingPhrase = greetingPhrase;
        }

        public CharacterType Type
        {
            get { return _type; }
        }

        public bool IsFriendly
        {
            get => _isFriendly;
            set => _isFriendly = value;
        }

        public string GreetingPhrase
        {
            get { return _greetingPhrase; }
            set { _greetingPhrase = value; }
        }
    }
}
