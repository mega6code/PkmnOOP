using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnGameOOP
{
    class Player
    {
        #region Fields
        List<Pokemon> pokemon_party;
        List<Energy> energy_collection;
        Pokemon pokemon_current;
        Pokemon pokemon_enemy;
        #endregion

        #region Funtions
        public void AddPokemon(Pokemon pokemon)
        {
            pokemon_party.Add(pokemon);
        }

        public void AddEnergy(Energy energy_pickup)
        {
            if (!energy_collection.Contains(energy_pickup))
            {
                energy_collection.Add(energy_pickup);
            }
        }

        public void ActivateAllPokemons()
        {
            foreach (Energy e in energy_collection)
            {
                foreach (Pokemon p in pokemon_party)
                {
                    if (p.Type == e)
                    {
                        p.Heal();
                    }
                }
            }
        }

        public Pokemon PickPokemon()
        {
            Pokemon pokemon_hspeed = null;

            foreach (Pokemon p in pokemon_party)
            {
                if (!p.Fainted)
                {
                    if (pokemon_hspeed == null)
                    {
                        pokemon_hspeed = p;
                    }
                    else if (p.Speed > pokemon_hspeed.Speed)
                    {
                        pokemon_hspeed = p;
                    }
                }
            }

            return pokemon_hspeed;
        }
            
        
        #endregion

    }
}
