///////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: Here is the class that contains methods to try to BruteForce attack a SHA256 hash.
//
///////////////////////////////////////////////////////////////////////////////
using SHA256_Encryption.binfiles;
using SHA256_Encryption.Encryption;

namespace SHA256_Encryption.AttackTypes;

/// <summary>
/// This class handles writing the entries to the associated rainbow table files.
/// If a password hash is cracked, it is written to the CrackedEntries.bin file.
/// </summary>
internal class BruteForceAttacks
{
    private static readonly BinaryWriter writer = new(new FileStream("..\\..\\..\\binfiles\\CrackedEntries.bin", FileMode.Append));
    private static readonly char[] validChars = new char[] {
        (char)32, (char)33, (char)34, (char)35, (char)36, (char)37, (char)38, (char)39, (char)40, (char)41, (char)42, (char)43, (char)44, (char)45, (char)46, (char)47, (char)48,
        (char)49, (char)50, (char)51, (char)52, (char)53, (char)54, (char)55, (char)56, (char)57, (char)58, (char)59, (char)60, (char)61, (char)62, (char)63, (char)64, (char)65,
        (char)66, (char)67, (char)68, (char)69, (char)70, (char)71, (char)72, (char)73, (char)74, (char)75, (char)76, (char)77, (char)78, (char)79, (char)80, (char)81, (char)82,
        (char)83, (char)84, (char)85, (char)86, (char)87, (char)88, (char)89, (char)90, (char)91, (char)92, (char)93, (char)94, (char)95, (char)96, (char)97, (char)98, (char)99,
        (char)100, (char)101, (char)102, (char)103, (char)104, (char)105, (char)106, (char)107, (char)108, (char)109, (char)110, (char)111, (char)112, (char)113, (char)114,
        (char)115, (char)116, (char)117, (char)118, (char)119, (char)120, (char)121, (char)122, (char)123, (char)124, (char)125, (char)126,
    }; // 95

    public BinHandler Bin { get; private set; }
    public bool Continue { get; private set; } = true;
    public string Password { get; private set; } = String.Empty;
    public int RainbowTableIncrementor { get; private set; } = 0;
    public string CurrentFilePath { get; private set; } = String.Empty;
    public Dictionary<string, string> CrackedPasswords { get; private set; }
    public Dictionary<string, string> RainbowTable { get; private set; }

    /// <summary>
    /// initial ctor that takes in the encrypted hash that we will try to "decrypt".
    /// </summary>
    public BruteForceAttacks(BinHandler binHandler)
    {
        Bin = binHandler;
        RainbowTable = new Dictionary<string, string>();
        CrackedPasswords = Bin.ConvertEntriesToDictionary("..\\..\\..\\binfiles\\CrackedEntries.bin");
    }


    /// <summary>
    /// Wrapper method that is used to find all possible strings of the length k of the last prefix enter the process of being found and are written
    /// to a new RainbowTable bin file. Is purposed to write to a binary file.
    /// If currentPrefix returns null, this means there are no entries in bin file, therefore, we have an empty file, and created a new file.
    /// </summary>
    public void WriteGuessAttack(string hashToCrack)
    {
        int k = 0;
        CurrentFilePath = Bin.FilePaths[Bin.FilePaths.Count - 1];
        bool filled = Bin.IsFileFilled(CurrentFilePath);
        if (filled)
        {
            Dictionary<string, string> d = Bin.ConvertBinFileToDictonary(CurrentFilePath);
            try { k = d.Values.Last().Length; } catch { }
            CurrentFilePath = Bin.SelectFile(String.Empty);
        }

        while (Continue)
        {
            Continue = WriteGuessAttack(validChars, String.Empty, ++k, hashToCrack);
        }

        Bin.WriteDictionaryObjectToBinFile(RainbowTable, CurrentFilePath);
    }
    /// <summary>
    /// The main recursive method to print all possible strings of length k. Is not limited.
    /// Writes each dictionary entry to a binary file.
    /// </summary>
    /// <param name="set"> the set of valid characters </param>
    /// <param name="prefix"> what we think the password is so far </param>
    /// <param name="k"> the constant number of chaacters in password string </param>
    /// <returns> false if we have found the password, true if we need to keep digging deeper with more characters </returns>
    private bool WriteGuessAttack(char[] set, string prefix, int k, string hashToCrack)
    {
        if (k == 0)  // Base case: k is 0, print prefix
        {
            if (!(RainbowTableIncrementor < 866495))
            {
                Bin.WriteDictionaryObjectToBinFile(RainbowTable, CurrentFilePath);
                CurrentFilePath = Bin.SelectFile(String.Empty);
                RainbowTable = Bin.ConvertBinFileToDictonary(CurrentFilePath);  
                RainbowTableIncrementor = 0;
            }

            Console.SetCursorPosition(55, 10);
            Console.Write(prefix);
            RainbowTable[new SHA256().Encrypt(prefix)] = prefix;
            ++RainbowTableIncrementor;
            return false;
        }

        for (int i = 0; i < validChars.Length; ++i)  // One by one add all characters from set and recursively call for k equals to k-1
        {
            string newPrefix = prefix + validChars[i];  // Next character of input added
            if (new SHA256().Encrypt(newPrefix) == hashToCrack)
            {
                Password = newPrefix;
                Console.SetCursorPosition(57, 12);
                Console.Write($"Password CRACKED!                            ");
                Console.SetCursorPosition(57, 13);
                Console.Write($"-->{Password}< --Enter anything to continue.");


                if (!(CrackedPasswords.ContainsKey(hashToCrack)))
                {
                    writer.Write(hashToCrack);
                    writer.Write(newPrefix);
                    writer.Dispose();
                }

                RainbowTable[hashToCrack] = newPrefix;
                ++RainbowTableIncrementor;
                return false;
            }
            else WriteGuessAttack(set, newPrefix, k - 1, hashToCrack); // k is decreased, because we have added a new character
            if (Password != string.Empty) return false; // Base case: If Password changed, then we have a cracked Password.
        }

        return true; // Return true if the number of letters in password (k) is incorrect and we need to increment another letter
    }


    /// <summary>
    /// Wrapper method that is used to find all possible strings of the length k of the last prefix enter the process of being found and are written to a new RainbowTable bin file.
    /// </summary>
    public void GuessAttack(string hashToCrack, int k = 0)
    {
        while (Continue)
        {
            Continue = GuessAttack(validChars, String.Empty, ++k, hashToCrack);
        }
    }
    /// <summary>
    /// The main recursive method to print all possible strings of length k. Is not limited.
    /// </summary>
    /// <param name="set"> the set of valid characters </param>
    /// <param name="prefix"> what we think the password is so far </param>
    /// <param name="k"> the constant number of chaacters in password string </param>
    /// <returns> false if we have found the password, true if we need to keep digging deeper with more characters </returns>
    private bool GuessAttack(char[] set, string prefix, int k, string hashToCrack)
    {
        if (k == 0)  // Base case: k is 0, print prefix
        {
            Console.WriteLine(prefix);
            return false;
        }

        for (int i = 0; i < validChars.Length; ++i)  // One by one add all characters from set and recursively call for k equals to k-1
        {
            string newPrefix = prefix + validChars[i];  // Next character of input added
            if (new SHA256().Encrypt(newPrefix) == hashToCrack)
            {
                Password = newPrefix;
                Console.WriteLine($"Password is cracked!\nWithin arrows-->{Password}<--\n");
                return false;
            }
            else GuessAttack(set, newPrefix, k - 1, hashToCrack); // k is decreased, because we have added a new character
            if (Password != String.Empty) return false; // Base case: If Password changed, then we have a cracked Password.
        }

        return true; // Return true if the number of letters in password (k) is incorrect and we need to increment another letter
    }
}
