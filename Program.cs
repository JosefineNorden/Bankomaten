﻿namespace Bankomaten
{
    internal class Program
    {

        static string[] userNameArray = { "Lisa1", "Tilda2", "Freja3", "Eva4", "Stella5" };
        static int[] passWordArray = { 1111, 2222, 3333, 4444, 5555 };

        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Bankomaten!");


            while (true)
            {
                int userIndex = LogIn();

                if (userIndex >= 0)
                {
                    UserMenu(userIndex);
                }
                else
                {
                    Console.WriteLine("För många misslyckade försök. Banken spärras!****");
                }

            }



        }

        static int LogIn()
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                Console.WriteLine("Vänligen ange ditt användarnamn: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Skriv in din PIN: ");
                string passWord = Console.ReadLine();

                for (int i = 0; i < userNameArray.Length; i++)
                {
                    if (userNameArray[i] == userName)
                    {

                        int PIN;

                        if (int.TryParse(passWord, out PIN))
                        {
                            if (passWordArray[i] == PIN)
                            {
                                Console.WriteLine("Loggar nu in på din bank......*");
                                Console.WriteLine("Tryck enter för att fortsätta: ");
                                Console.ReadKey();
                                return i;
                            }
                            else
                            {
                                Console.WriteLine("Felaktigt användarnamn eller lösenord.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltlig PIN. Vänligen använd 4 siffror.");
                        }
                    }

                }
            }

            return -1;
        }
        static void UserMenu(int userIndex)
        {
            while (true)
            {
                Console.WriteLine("Vad vill du göra idag?");

                Console.WriteLine("[1] Se dina konton och saldo");
                Console.WriteLine("[2] Överföring mellan konton");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Logga ut");

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        // Metod för att se konton och saldo
                        Console.WriteLine("alternativ 1");
                        break;

                    case 2:
                        // Metod för överföring mellan konton
                        Console.WriteLine("Alternativ 2");
                        break;

                    case 3:
                        Console.WriteLine("Alternativ 3");
                        //Metod för att ta ut pengar
                        break;

                    case 4:
                        Console.WriteLine("Loggar ut...");
                        return;
                    default:
                        Console.WriteLine("Ogiltligt val. Försök igen.");
                        break;

                }
            }
        }
    }
}
