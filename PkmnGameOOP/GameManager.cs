using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PkmnGameOOP
{
    public static class GameManager
    {
        public static Player currentPlayer;
        public static bool game_over = false;
        private static bool battle_mode = false;
        private static bool quit = false;
        private static char mm_input;
        public static Exception NotReadyYet = new Exception("Sorry, this feature isnt ready yet!");

        

        public static void MainMenu()
        {
            quit = false;
            do
            {
                Console.Clear();
                Message.PrintBlue(
                    "---------POKEMON!---------\n" +
                    "-Command Console Version-\n\n\n");
                    Message.Log("1 = New Game", ConsoleColor.White);
                    Message.Log("2 = Quit", ConsoleColor.White);

                mm_input = Convert.ToChar(Console.ReadLine());
                switch (mm_input)
                {
                    case '1':
                        currentPlayer = new Player();
                        Console.Clear();
                        GamePlay();
                        break;
                    case '2':              
                        quit = true;
                        break;
                    default:
                        Console.WriteLine($"|{mm_input} is not a Menu Choice!|");
                        break;
                }
            } while (!quit);
        }
        public static void GamePlay()
        {
            game_over = false;

            while (!game_over)
            {
                if (battle_mode)
                {
                    BattleMenu();
                }
                else
                {
                    ExploreMenu();
                }
            }

            Console.WriteLine("\n\nGame Over!\n" +
                "Thanks for Playing!\n\n" +
                "--Press any key to go back to Main Menu--");
            Console.ReadKey();
        }
        public static void BattleMenu()
        { 

            while (!game_over && battle_mode) 
            { 
            Message.PrintDarkGreen(
                "Menu: \n" +
                "| A = Attack Oppenent! | S = Stats on Fighters |\n" +
                "| P = Pokemon Party | R = RUN!!!|\n");

                mm_input = Convert.ToChar(Console.ReadLine());
                switch (mm_input)
                {
                    case 'A':
                        Battle();
                        break;
                    case 'S':

                        Message.Log("Your Fighter's Stats: " +
                        currentPlayer.Pokemon_current_fighter.ToString(), ConsoleColor.Cyan);

                        Message.Log("Wild Pokemon's Stats: " +
                        currentPlayer.Pokemon_target.ToString(), ConsoleColor.DarkCyan);

                        break;
                    case 'P':
                        Console.Write("Pokemon Party: ");
                        foreach (Pokemon p in currentPlayer.Pokemon_party)
                        {
                            Console.WriteLine($" {p.Name} | {p.State}");
                        }
                        break;
                    case 'R':
                        Run();
                        break;
                    default:
                        Console.WriteLine($"|{mm_input} is not a Menu Choice!|");
                        break;
                }
                
            }
        }
        public static void ExploreMenu() 
        {
            
            Message.PrintDarkGreen(
                "Menu: \n" +
                "| L = Look Around | S = Stats on Current Fighter |\n" +
                "| E = Energies | P = Pokemon Party | Q = Quit |\n");
                
            mm_input = Convert.ToChar(Console.ReadLine());
            switch (mm_input)
            {
                case 'L':
                    Explore();
                    break;
                case 'S':
                    Message.Log("Fighter Stats: " +
                    currentPlayer.Pokemon_current_fighter.ToString(), ConsoleColor.Cyan);
                    break;
                case 'E':
                    Message.Log("Energy Collection:", ConsoleColor.DarkBlue);
                    foreach (Energy e in currentPlayer.Energy_collection)
                    {
                         Message.Log($" {e.ToString()} |", ConsoleColor.Blue);
                    }
                    break;
                case 'P':
                    Message.Log("Pokemon Party:", ConsoleColor.Magenta);
                    foreach (Pokemon p in currentPlayer.Pokemon_party)
                    {
                        Console.WriteLine($" {p.Name} | {p.State}");
                    }
                    break;
                case 'Q':
                    game_over = true;                   
                    break;

                default:
                    Console.WriteLine($"|{mm_input} is not a Menu Choice!|");
                    break;
            }
        }

        public static void Explore() 
        {

            if (RNG.random.Next(0, 3) == 2)
            {
                currentPlayer.PrepareBattle(GameFactory.Get_Random_Pokemon());
                battle_mode = true;
            }
            else 
            {
                currentPlayer.AddEnergy(GameFactory.Get_Random_Energy());
            } 
        }
        public static void Battle()
        {
            if(currentPlayer.Pokemon_current_fighter.Speed >= currentPlayer.Pokemon_target.Speed)
            {
                currentPlayer.Pokemon_current_fighter.Attack(currentPlayer.Pokemon_target);
                currentPlayer.Pokemon_target.Attack(currentPlayer.Pokemon_current_fighter);
            } 
            else
            {
                currentPlayer.Pokemon_target.Attack(currentPlayer.Pokemon_current_fighter);
                currentPlayer.Pokemon_current_fighter.Attack(currentPlayer.Pokemon_target);
            }

            if(currentPlayer.Pokemon_current_fighter.Fainted == true)
            {
                currentPlayer.Pokemon_current_fighter = currentPlayer.PickPokemon();

                if (currentPlayer.Pokemon_current_fighter.Fainted == true)
                {
                    game_over = true;
                    battle_mode = false;
                    
                }
                
            }
            else if (currentPlayer.Pokemon_target.Fainted == true)
            {
                currentPlayer.AddPokemon(currentPlayer.Pokemon_target);
                Message.Log($"You caught {currentPlayer.Pokemon_target.Name} (^-^)!", ConsoleColor.Magenta);
                battle_mode = false;
            }
        }

        public static void Run()
        {

            if (RNG.random.Next(0, 3) == 2)
            {
                battle_mode = true;
                Message.PrintDanger("Escaped!");
            }
            else
            {
                Message.PrintDanger("Could not escape!");
                Battle();

            }
        }


    }
}
