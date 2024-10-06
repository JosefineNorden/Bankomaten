namespace Bankomaten
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
                    Console.WriteLine("Snart händer spännande grejjor");
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
    }
}
