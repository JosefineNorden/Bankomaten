namespace Bankomaten
{
    internal class Program
    {
        // An array that contains the name of five users.
        static string[] userNameArray = { "Lisa1", "Tilda2", "Freja3", "Eva4", "Stella5" };
        // An array that contains the passwords for the five users.
        static int[] passWordArray = { 1111, 2222, 3333, 4444, 5555 };

        // Jagged Array that stores account values for each account.
        static decimal[][] accounts =


        {
          new  decimal [] {20000m},
          new  decimal [] {20000m, 200000m},
          new  decimal [] {20000m, 200000m, 2000m},
          new  decimal [] {10000m, 100000m, 1000m, 100m},
          new  decimal [] {10000m, 100000m, 1000m, 5000m, 7000m}
        };

        // Jagged Array that stores the name of each user account.
        static string[][] accountNames =
        {
          new string [] {"Lönekonto"},
          new string [] {"Lönekonto", "Sparkonto"},
          new string [] {"Lönekonto", "Sparkonto","Nöjen"},
          new string [] {"Lönekonto", "Sparkonto", "Ny Cykel", "Lördagsgodis"},
          new string [] {"Lönekonto", "Sparkonto", "Resekonto", "Veterinärkostnader", "Nöjen"}
            };
        static void Main(string[] args)
        {
            // Welcome-message to the user.
            Console.WriteLine("Välkommen till Bankomaten!");

            // A loop that check if the user is able to log on to usermenu.
            while (true)
            {
                // A method called to allow the user to sign in. It returns the index of the current user.
                int userIndex = LogIn();

                if (userIndex >= 0)
                {
                    // If the login is successful, this method is called to show the user menu.
                    UserMenu(userIndex);
                }
                else
                {
                    // A break for the loop if the user tries to log in more than three times.
                    Console.WriteLine("För många misslyckade försök. Banken spärras!****");
                    break;
                }
            }
        }

        static int LogIn() // Log In method.
        {
            // A loop that gives the user three attempts to log in.
            for (int attempt = 0; attempt < 3; attempt++)
            {
                // Ask user for user name.
                Console.WriteLine("Vänligen ange ditt användarnamn: ");
                // Get users input for user name.
                string userName = Console.ReadLine();
                // Ask user for password.
                Console.WriteLine("Skriv in din PIN: ");
                // Get users intput for password.
                string passWord = Console.ReadLine();

                // A loop that checks if userNameArray match with userName input.
                for (int i = 0; i < userNameArray.Length; i++)
                {
                    if (userNameArray[i] == userName)
                    {
                        int PIN;

                        // Attempts to convert the string to an int and stores it in PIN.
                        if (int.TryParse(passWord, out PIN))
                        {
                            if (passWordArray[i] == PIN)
                            {

                                // Text that shows if the log in is successful.
                                Console.WriteLine("Loggar nu in på din bank......*");
                                // Ask the user to press enter to continue.
                                Console.WriteLine("Tryck enter för att fortsätta: ");
                                // The user has to press a key to move forward in the program.
                                Console.ReadKey();
                                // Returns the user´s index.
                                return i;
                            }
                            // If the users name or password is not correct.
                            else
                            {
                                Console.WriteLine("Felaktigt användarnamn eller lösenord.");
                            }
                        }
                        // Error handling message if the input was incorrect.
                        else
                        {
                            Console.WriteLine("Ogiltlig PIN. Vänligen använd 4 siffror.");
                        }
                    }
                }
            }
            // returns a negative value if the log in wasn't sucessful.
            return -1;
        }
        static void UserMenu(int userIndex) // UserMenu method.
        {
            while (true)
            {
                // Shows a menu with options for the user.
                Console.WriteLine("Vad vill du göra idag?");

                Console.WriteLine("[1] Se dina konton och saldo");
                Console.WriteLine("[2] Överföring mellan konton");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Logga ut");

                string input = Console.ReadLine();
                int userInput;
                // Error-Handling so the user input is correct.
                if (!int.TryParse(input, out userInput))
                {
                    Console.WriteLine("Ogiltlig inmatning, skriv ett nummer mellan 1 - 4.");
                }

                // Depending on the user's choice, different methods are called.
                switch (userInput)
                {
                    case 1:
                        // Method for accounts and values.
                        Accounts(userIndex);
                        break;
                    case 2:
                        // Method for money transfer.
                        TransferMoney(userIndex);
                        break;
                    case 3:
                        //Method for withdrawal.
                        Withdrawal(userIndex);
                        break;
                    case 4:
                        // An option for log out that returns to the main menu.
                        Console.WriteLine("Loggar ut...");
                        return;
                    // If the user input is other than 1-4, the program ask the user to try again.
                    default:
                        Console.WriteLine("Försök igen.");
                        break;
                }
            }
        }
        static void Accounts(int userIndex) // Method for accounts
        {
            // A Loop that checks if AccountNames matches with the userIndex.
            for (int i = 0; i < accountNames[userIndex].Length; i++)
            {
                string accountName = accountNames[userIndex][i];
                decimal accountValue = accounts[userIndex][i];

                // Shows all accounts and their value.
                Console.WriteLine($"{i + 1}. {accountName}: {accountValue:C}");
            }
        }
        static void TransferMoney(int userIndex) // Method to transfer money between accounts.
        {
            try
            {
                for (int i = 0; i < accountNames[userIndex].Length; i++)
                {
                    string accountName = accountNames[userIndex][i];
                    decimal accountValue = accounts[userIndex][i];

                    Console.WriteLine($"{i + 1}. {accountName}: {accountValue:C}");
                }

                //Gets the users input that choose the account the user want to transfer from.
                Console.WriteLine("Välj vilket konto du vill överföra ifrån (1 - {0}):", accountNames[userIndex].Length);
                int fromAccount = int.Parse(Console.ReadLine()) - 1;
                // Gets the users input that choose the account the user want to transfer to.
                Console.WriteLine("Välj vilket konto du vill överföra till (1 - {0}):", accountNames[userIndex].Length);
                int toAccount = int.Parse(Console.ReadLine()) - 1;
                // Get the users input about how much money the user wants to transfer.
                Console.WriteLine("Hur mycket pengar vill du överföra?");
                decimal moneyToTransfer = decimal.Parse(Console.ReadLine());

                //Checks if the index of the account that the user wants to transfer money to is negative, and if the index of the accounts matches the length of the array.
                if (fromAccount < 0 || fromAccount >= accountNames[userIndex].Length ||
                    // A negative index is invalid.
                    toAccount < 0 || toAccount >= accountNames[userIndex].Length)
                {
                    // Ask the user to try again because the accounts is invalid.
                    Console.WriteLine("Ogiltiga konton. Försök igen.");
                    return;
                }
                // If the users choice is the same account twice the input is invalid.
                if (fromAccount == toAccount)
                {
                    Console.WriteLine("Du kan inte överföra mellan samma konto.");
                    return;
                }
                // If the user wants to transfer 0SEK or lower the input is invalid.
                if (moneyToTransfer <= 0)
                {
                    Console.WriteLine("Du måste överföra minst 1 SEK.");
                    return;
                }
                // If the account contains less money than chosen the transfer is invalid.
                if (accounts[userIndex][fromAccount] < moneyToTransfer)
                {
                    Console.WriteLine("Du har för lite pengar på valt konto.");
                    return;
                }
                // Updates the accounts to the new balances after the transfer is completed.
                accounts[userIndex][fromAccount] -= moneyToTransfer;
                accounts[userIndex][toAccount] += moneyToTransfer;
                //Clear console.
                Console.Clear();
                // Shows and confirms that the transfer was succedeed.
                Console.WriteLine($"Överföring genomförd: {moneyToTransfer:C} från {accountNames[userIndex][fromAccount]} till {accountNames[userIndex][toAccount]}.");
            }
            // Catches formatException and ask the user to use the correct input.
            catch (FormatException)
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange siffror.");
            }
            // Catches any other exceptions that haven't been handled by previous catch block.
            catch (Exception)
            {
                //Shows the text "ERROR".
                Console.WriteLine($"ERROR");
            }
        }
        static void Withdrawal(int userIndex) // Method to withdrawal money from accounts.
        {
            // A try block that could handle potentially errors.
            try
            {
                Console.WriteLine("Välj vilket konto du vill ta ut pengar från:");
                // Looping through accounts
                for (int i = 0; i < accountNames[userIndex].Length; i++)
                {
                    string accountName = accountNames[userIndex][i];
                    decimal accountValue = accounts[userIndex][i];

                    Console.WriteLine($"{i + 1}. {accountName}: {accountValue:C}");
                }
                // reads the users input as a string then converts it to an integer.
                int selectedAccount = int.Parse(Console.ReadLine()) - 1; // -1 adjust the index to zero in line with the array indexing.
                // Checks if the accounts index matches the users input.
                if (selectedAccount < 0 || selectedAccount >= accountNames[userIndex].Length)
                {
                    Console.WriteLine("Ogiltigt konto. Försök igen.");
                    return;
                }
                // Ask the user how much money that the user want to withdrawal and saves the answer in decimal for precision.
                Console.WriteLine("Hur mycket pengar vill du ta ut från ditt konto?");
                decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
                //Checks if the user input is higher than 0.
                if (withdrawalAmount <= 0)
                {
                    Console.WriteLine("Du måste ta ut minst 1 SEK.");
                    return;
                }
                //Checks if the user has enough money on the selected acount to withdrawal.
                if (accounts[userIndex][selectedAccount] < withdrawalAmount)
                {
                    Console.WriteLine("Du har för lite pengar på ditt konto.");
                    return;
                }
                // Ask for PIN to confirm.
                Console.WriteLine("Skriv in din PIN för att bekräfta:");
                string PINInput = Console.ReadLine();
                int PIN;
                // PIN validation that attempts to convert string to an int and if successful it assign the value to PIN.
                // Then checks if PIN matches the stored PIN for logged in user.
                if (int.TryParse(PINInput, out PIN) && passWordArray[userIndex] == PIN)
                {
                    // If pin is correct the amount is substracted from the users selected account.
                    accounts[userIndex][selectedAccount] -= withdrawalAmount;
                    // Clears console and confirms withdrawal.
                    Console.Clear();
                    Console.WriteLine($"Du har tagit ut: {withdrawalAmount:C} från {accountNames[userIndex][selectedAccount]}.");
                    Console.WriteLine($"Nytt saldo på ditt konto: {accounts[userIndex][selectedAccount]:C}");
                }
                //Invalid PIN handling
                else
                {
                    Console.WriteLine("Felaktig PIN-kod.");
                }
            }
            // If the users input is invalid a formatexception is caught.
            catch (FormatException)
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange fyra siffror.");
            }
            // If any other unexpected errors happends the program shows "ERROR".
            catch (Exception)
            {
                Console.WriteLine($"ERROR");
            }
        }
    }
}


