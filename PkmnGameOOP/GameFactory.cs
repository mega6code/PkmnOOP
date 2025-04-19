using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnGameOOP
{
    public static class GameFactory
    {
        public static Energy Get_Random_Energy()
        {
            int random = RNG.random.Next(0, 4);
            switch (random)
            {
                case 0:
                    Message.PrintWarning("You found FIRE Energy (^_^)");
                    return Energy.FIRE;
                case 1:
                    Message.PrintWarning("You found GRASS Energy (^_^)");
                    return Energy.GRASS;
                case 2:
                    Message.PrintWarning("You found WATER Energy (^_^)");
                    return Energy.WATER;
                default:
                    Message.PrintWarning("You found LIGHTNING Energy (^_^)");
                    return Energy.LIGHTNING;
            }
        }
        public static Pokemon Get_Random_Pokemon()
        {
            int random = RNG.random.Next(0, 17);
            Pokemon randomPokemon = null;        
            switch (random)
            {
                case 0:
                    Message.PrintDanger("The GRASS Pokemon Bulbasaur approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Bulbasaur", ap_p: 28, hp_p: 100, speed_p: 50, type_p: Energy.GRASS);
                    break;
                case 1:
                    Message.PrintDanger("The GRASS Pokemon Treecko approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Treecko", ap_p: 28, hp_p: 100, speed_p: 50, type_p: Energy.GRASS);
                    break;
                case 2:
                    Message.PrintDanger("The GRASS Pokemon Chikorita approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Chikorita", ap_p: 35, hp_p: 100, speed_p: 45, type_p: Energy.GRASS);
                    break;
                case 3:
                    Message.PrintDanger("The GRASS Pokemon Bellossom approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Bellossom", ap_p: 40, hp_p: 100, speed_p: 50, type_p: Energy.GRASS);
                    break;
                case 4:
                    Message.PrintDanger("The GRASS Pokemon Sunflora approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Sunflora", ap_p: 20, hp_p: 100, speed_p: 30, type_p: Energy.GRASS);
                    break;
                case 5:
                    Message.PrintDanger("The FIRE Pokemon Charmander approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Charmander", ap_p:42, hp_p: 100, speed_p: 65, type_p: Energy.FIRE);
                    break;
                case 6:
                    Message.PrintDanger("The FIRE Pokemon Slugma approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Slugma", ap_p:30, hp_p: 100, speed_p: 20, type_p: Energy.FIRE);
                    break;
                case 7:
                    Message.PrintDanger("The FIRE Pokemon Charmander approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Charmander", ap_p:45, hp_p: 100, speed_p: 65, type_p: Energy.FIRE);
                    break;
                case 8:
                    Message.PrintDanger("The FIRE Pokemon Cyndaquil approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Cyndaquil", ap_p:40, hp_p: 100, speed_p: 70, type_p: Energy.FIRE);
                    break;
                case 9:
                    Message.PrintDanger("The WATER Pokemon Squirtle approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Squirtle", ap_p: 48, hp_p: 100, speed_p: 56, type_p: Energy.WATER);
                    break;
                case 10:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Totodile", ap_p: 55, hp_p: 100, speed_p: 43, type_p: Energy.WATER);
                    break;
                case 11:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Seel", ap_p: 30, hp_p: 100, speed_p: 35, type_p: Energy.WATER);
                    break;
                case 12:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Wooper", ap_p: 35, hp_p: 100, speed_p: 15, type_p: Energy.WATER);
                    break;
                case 13:
                    Message.PrintDanger("The LIGHTNING Pokemon Voltorb approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Voltorb", ap_p: 30, hp_p: 100, speed_p: 100, type_p: Energy.LIGHTNING);
                    break;
                case 14:
                    Message.PrintDanger("The LIGHTNING Pokemon Electrode approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Electrode", ap_p: 40, hp_p: 100, speed_p: 150, type_p: Energy.LIGHTNING);
                    break;
                case 15:
                    Message.PrintDanger("The LIGHTNING Pokemon Eelektrik approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Eelektrik", ap_p: 50, hp_p: 100, speed_p: 76, type_p: Energy.LIGHTNING);
                    break;
                default:
                    Message.PrintDanger("The LIGHTNING Pokemon Helioptile approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name_p: "Helioptile", ap_p: 30, hp_p: 100, speed_p: 70, type_p: Energy.LIGHTNING);
                    break;
            }
            return randomPokemon;
        }

        public static Pokemon CreatePartnerPikachu()
        {
            Pokemon partner = new Pokemon(name_p: "Partner Pikachu", hp_p: 120, ap_p: 60, speed_p: 120, type_p: Energy.LIGHTNING);
            return partner;
        }
    }   

}
