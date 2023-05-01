///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: This class is to define and then add different Actions and functions to the 
// Program's dispatch table.  These dispatch methods control the changing between 
// windows of the main menu as well as providing actual functionality.
//
///////////////////////////////////////////////////////////////////////////////////
using SHA256_Encryption.AttackTypes;
using SHA256_Encryption.binfiles;
using SHA256_Encryption.Encryption;

namespace SHA256_Encryption.UI
{
    /// <summary>
    /// Creates and adds the methods to the dispatchTable and does so more once all objects are created.
    /// </summary>
    internal class DispatchMaker
    {
        /// <summary>
        /// Adds multiple menu options to the program dispatch table
        /// </summary>
        /// <param name="bH"> the program bin handler </param>
        public static void AddMostMethodsToDispatchTable(BinHandler bH)
        {
            Program.dispatchTable[1] = new Action(() => SHA256EncryptInput());
            Program.dispatchTable[2] = new Func<ConsoleKey>(() => ExitApplication());
            Program.dispatchTable[3] = new Action(() => About());
            Program.dispatchTable[4] = new Action(() => RainbowTableAttack());
            Program.dispatchTable[5] = new Action(() => BruteForceAttack(bH));
            Program.dispatchTable[6] = new Action(() => HowTo());
        }

        /// <summary>
        /// Once the rfa object is finished creating itself, the rest of the dispatch options can be added in
        /// </summary>
        /// <param name="rfa"> the rfa object </param>
        public static void AddRestOfMethodsToDispatchTable(RainbowTableAttacks rfa)
        {
            Program.dispatchTable[7] = new Action(() => CrackedEntriesAttack(rfa));
            Program.dispatchTable[8] = new Action(() => RainbowAttack(rfa));

        }

        /// <summary>
        /// Returns the hash of a user input and displays it as well as stores it.
        /// </summary>
        /// <param name="sha256"> the class that encrypts </param>
        /// <returns> an encrypted sha 256 hash </returns>
        private static void SHA256EncryptInput()
        {
            SHA256 sha256 = new();
            Console.SetCursorPosition(0, 5);
            Console.Write(Menus.EncryptMenu());
            Console.SetCursorPosition(4, 8);
            string input = Console.ReadLine();

            string hash = sha256.Encrypt(input);
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.ReturnEncryption(hash));
            Console.WriteLine($"Above is the encrypted hash of -->{input}<--  Enter anything to continue.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }

        /// <summary>
        /// Returns escape key to exit application gracefully
        /// </summary>
        /// <returns> the escape key </returns>
        private static ConsoleKey ExitApplication() => ConsoleKey.Escape;
        
        /// <summary>
        /// Returns the about page for the program
        /// </summary>
        private static void About()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.AboutMenu());
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }
    

        /// <summary>
        /// Opens the brute force attack menu in order to paset a hash and use the brute force methods
        /// </summary>
        private static void BruteForceAttack(BinHandler handler)
        {
            BruteForceAttacks bfa = new(handler);

            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.DecryptBruteForceMenu());
            Console.SetCursorPosition(53, 8);
            string hash = Console.ReadLine();

            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.DecryptInProgress(hash));

            Console.SetCursorPosition(57, 12);
            Console.WriteLine("Breaking Hash...This may take some time...");

            bfa.WriteGuessAttack(hash);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }

        /// <summary>
        /// Checks first to make sure rfa object is finished bulding. Then user is able to go into mini menu
        /// </summary>
        private static void RainbowTableAttack()
        {
            if (Program.newTask.IsCompletedSuccessfully != true)
            {
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Cannot start until bin files are Converted. Enter anything to continue");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine(Menus.MainMenu());
                Console.SetCursorPosition(0, 5);
            }
            else
            {
                Console.SetCursorPosition(0, 5);
                MenuChoices.ActivateRainbowMenu();
                Console.SetCursorPosition(0, 5);
            }
        }

        /// <summary>
        /// Rainbow attack for the Cracked Entries bin file
        /// </summary>
        /// <param name="rfa"> the rainbow attack object </param>
        private static void CrackedEntriesAttack(RainbowTableAttacks rfa)
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.DecryptCrackedMenu());
            Console.SetCursorPosition(53, 8);
            string hash = Console.ReadLine();

            Console.SetCursorPosition(0, 10);

            rfa.CrackedPasswordAttack(hash);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }

        /// <summary>
        /// Rainbow attack for the Rainbow Table bin files
        /// </summary>
        /// <param name="rfa"> the rainbow attack object </param>
        private static void RainbowAttack(RainbowTableAttacks rfa)
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.DecryptRainbowMenu());
            Console.SetCursorPosition(53, 8);
            string hash = Console.ReadLine();

            Console.SetCursorPosition(0, 10);

            rfa.Attack(hash);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }

        /// <summary>
        /// Displays the How to Menu
        /// </summary>
        private static void HowTo()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Menus.HowToMenu());
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(Menus.MainMenu());
            Console.SetCursorPosition(0, 5);
        }
    }
}
