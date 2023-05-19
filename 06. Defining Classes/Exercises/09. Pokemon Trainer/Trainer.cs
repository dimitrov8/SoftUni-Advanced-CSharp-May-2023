using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name)
        {
            Name = name;
            PokemonCollection = new List<Pokemon>();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Trainer otherTrainers)
            {
                return Name.Equals(otherTrainers.Name);
            }

            return false;
        }

        public Trainer(string name, int badgesCount, List<Pokemon> pokemonCollection) : this(name)
        {
            BadgesCount = badgesCount;
            PokemonCollection = pokemonCollection;
        }

        public void Caught(Pokemon pokemonCaught)
        {
            PokemonCollection.Add(pokemonCaught);
        }

        public void Damage(List<Pokemon> pokemonCollection)
        {
            foreach (var pokemon in PokemonCollection)
            {
                Pokemon currentPokemon = pokemon;
                pokemon.Health -= 10;
            }

            PokemonCollection.RemoveAll(x => x.Health <= 0);
        }

        public override string ToString()
        {
            return $"{Name} {BadgesCount} {PokemonCollection.Count}";
        }
    }
}