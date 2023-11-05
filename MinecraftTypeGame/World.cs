using System;
using System.Collections.Generic;

namespace MinecraftTypeGame
{
    public class World
    {
        // minimal world size to be playable (5x5 square)
        private int _worldXSize = 5;
        private int _worldYSize = 5;
        private List<BaseCharacter> worldCharacters = new List<BaseCharacter>();

        public World(int worldXSize, int worldYSize)
        {
            if (worldXSize >= 5)
            {
                _worldXSize = worldXSize;
            }
            if (worldYSize >= 5)
            {
                _worldYSize = worldYSize;
            }
        }

        public void CreateWorld()
        {
            worldCharacters.Add(new Player(0, 0, "PlayerOne"));

            // Generate characters
            var random = new Random();
            for (int i = 0; i < 3; i++)
            {
                var position = GenerateNewCharacterPosition();
                worldCharacters.Add(new Character(position.Item1, position.Item2, random.Next(2) == 1, (CharacterType)i, $"Hello {i}"));
            }

            // Generate animals
            for (int i = 0; i < 5; i++)
            {
                var position = GenerateNewCharacterPosition();
                worldCharacters.Add(new Animal(position.Item1, position.Item2, random.Next(2) == 1, (AnimalType)i));
            }
        }

        public List<BaseCharacter> FindNearby(BaseCharacter character, int distance)
        {
            var nearbyCharacters = new List<BaseCharacter>();

            foreach (var worldCharacter in worldCharacters)
            {
                if (CalculateCharactersDistance(character, worldCharacter) <= distance)
                {
                    nearbyCharacters.Add(worldCharacter);
                }
            }

            return nearbyCharacters;
        }

        public void SetCharacterPosition(BaseCharacter character, int positionX, int positionY)
        {
            if (IsPositionFreeAndValid(positionX, positionY))
            {
                character.SetLocation(positionX, positionY);
            }
        }

        // using old good Pytagoras to determine distance
        private int CalculateCharactersDistance(BaseCharacter character, BaseCharacter anotherCharacter)
        {
            var charactersXDistance = character.LocationX - anotherCharacter.LocationX;
            var charactersYDistance = character.LocationY - anotherCharacter.LocationY;

            if (charactersXDistance < 0)
            {
                charactersXDistance *= -1;
            }

            if (charactersXDistance < 0)
            {
                charactersYDistance *= -1;
            }

            // if characters are on the same axis
            if (charactersXDistance == 0)
            {
                return charactersYDistance;
            }
            if (charactersYDistance == 0)
            {
                return charactersXDistance;
            }

            double pytagorTheoremResult = Math.Sqrt(Math.Pow(charactersXDistance, 2) + Math.Pow(charactersYDistance, 2));
            return (int)Math.Floor(pytagorTheoremResult);
        }

        private Tuple<int, int> GenerateNewCharacterPosition()
        {
            var random = new Random();
            int locationX = random.Next(0, _worldXSize);
            int locationY = random.Next(0, _worldYSize);

            // Teoretically, this could stuck forever..
            while (!IsPositionFreeAndValid(locationX, locationY))
            {
                locationX = random.Next(0, _worldXSize);
                locationY = random.Next(0, _worldYSize);
            }

            return Tuple.Create(locationX, locationY);
        }

        private bool IsPositionFreeAndValid(int locationX, int locationY)
        {
            if (locationX > _worldXSize
                || locationX < 0
                || locationY > _worldYSize
                || locationY < 0)
            {
                return false;
            }
            foreach (var character in worldCharacters)
            {
                if (character.LocationX == locationX && character.LocationY == locationY)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
