using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PkmnGameOOP
{
    public class Player
    {
        #region Fields
        private List<Pokemon> pokemon_party = new List<Pokemon>();
        private List<Energy> energy_collection = new List<Energy>();
        private Pokemon pokemon_current_fighter;
        private Pokemon pokemon_target;
        private Pokemon pokemon_hspeed = null;
        #endregion

        #region Properties
        public Pokemon Pokemon_target { get => pokemon_target; }
        public List<Pokemon> Pokemon_party { get => pokemon_party;}
        public List<Energy> Energy_collection { get => energy_collection;}
        public Pokemon Pokemon_current_fighter { get => pokemon_current_fighter; set => pokemon_current_fighter = value; }
        #endregion

        #region Functions
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
            else
            {
                Message.Log("Its already in your Collection!", ConsoleColor.Blue);
            }
        }

        public void ActivateAllPokemons()
        {
            Message.Log("Depleting Energies for Healing!", ConsoleColor.DarkBlue);
            Message.Log($"Healing Results: ", ConsoleColor.Green);
            foreach (Energy e in energy_collection)
            {
                foreach (Pokemon p in pokemon_party)
                {
                    if (p.Type == e)
                    {
                        p.Heal();
                        Message.Log($"{p.Name} | ", ConsoleColor.Green);
                    }
                }
            }
            energy_collection.Clear();
        }

        public Pokemon PickPokemon()
        { 
            foreach (Pokemon p in pokemon_party)
            {       
                if (!p.Fainted)
                {
                    continue;              
                }
                else if (p.Speed > pokemon_hspeed.Speed)
                {
                    pokemon_hspeed = p;
                }
            }
                return pokemon_hspeed;
        }

        public void PrepareBattle(Pokemon enemy)
        {
            ActivateAllPokemons();
            pokemon_target = enemy;
            pokemon_current_fighter =  PickPokemon();

        }
        #endregion

        #region Constructorz
        public Player()
        {
            Pokemon pokemon_start = GameFactory.CreatePartnerPikachu();
            AddPokemon(pokemon_start);
            pokemon_current_fighter = pokemon_start;
            pokemon_hspeed = pokemon_current_fighter;
        } 
        #endregion

    }
}
