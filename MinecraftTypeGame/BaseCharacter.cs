using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftTypeGame
{
    public abstract class BaseCharacter
    {
        private int _health = 100;
        private int _locationX;
        private int _locationY;
        private bool _isDead = false;

        public BaseCharacter(int locationX, int locationY) { 
            _locationX = locationX;
            _locationY = locationY;
        }

        public int LocationX
        {
            get => _locationX;
        }
        public int LocationY
        {
            get => _locationY;
        }

        public int Health
        {
            get => _health;
        }

        public bool IsDead
        {
            get => _isDead;
        }

        public void SetLocation(int locationX, int locationY)
        {
            _locationX = locationX > 0 ? locationX : 0;
            _locationY = locationY > 0 ? locationY : 0;
        }

        public int DecreaseHealth(int decreaseAmmount)
        {
            _health -= decreaseAmmount;
            if (_health < 1)
            {
                _health = 0;
                _isDead = true;
            }

            return _health;
        }

        public int IncreaseHealth(int increaseAmmount)
        {
            _health += increaseAmmount;
            if (_health > 100)
            {
                _health = 100;
                _isDead = false;
            }

            return _health;
        }

        public void Attack(int weaponPower, BaseCharacter baseCharacter)
        {
            baseCharacter.DecreaseHealth(weaponPower);
        }

        public void Heal(int healthAdded, BaseCharacter baseCharacter)
        {
            baseCharacter.IncreaseHealth(healthAdded);
        }
    }
}
