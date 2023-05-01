///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: This class instantiates the methods used for the rainbowtable attacks.
// A lengthy process of converting the binary files into dictionaries, then the dictionaries 
// into sorted dictionaries take place in the constructor
//
///////////////////////////////////////////////////////////////////////////////////
using SHA256_Encryption.binfiles;

namespace SHA256_Encryption.AttackTypes;

/// <summary>
/// The reason for converting the dictionaries into sorteddictionaries is because the search
/// time for cracked hashes is increased tremendously from a linear array search into a binary search tree.
/// </summary>
internal class RainbowTableAttacks
{
    public BinHandler Bin { get; private set; }
    public string Password { get; private set; } = String.Empty;
    public SortedDictionary<string, string> Current { get; private set; }
    public SortedDictionary<string, string> CrackedPasswords { get; private set; }
    public Dictionary<int, SortedDictionary<string, string>> RainbowTables { get; private set; }


    /// <summary>
    /// Ctor to instantiate different methods to use different types of Rainbow Table attacks
    /// </summary>
    public RainbowTableAttacks(BinHandler binHandler)
    {
        Bin = binHandler;
        Current = new();
        CrackedPasswords = CrackedEntriesToSortedDictionary();
        RainbowTables = new();
        for (int i = 0; i < Bin.FilePaths.Count; i++)
        {
            RainbowTables[i] = ConvertToSortedDictionary(Bin.FilePaths[i]);
        }
    }

    /// <summary>
    /// Specifically for the CrackedEntries.bin file as the logic for serializing cracked entries is different
    /// than serializing entire Dictionary objects.
    /// </summary>
    /// <returns> the sorted dictionary for CrackedPasswords </returns>
    public SortedDictionary<string, string> CrackedEntriesToSortedDictionary()
    {
        Dictionary<string, string> entries = Bin.ConvertEntriesToDictionary("..\\..\\..\\binfiles\\CrackedEntries.bin");
        return new SortedDictionary<string, string>(entries);
    }

    /// <summary>
    /// Takes the bin file encoded for a Dictionary, serializes it into a Dictionary object, 
    /// then converts the dictionary to a SortedDictionary for faster lookup speeds.
    /// </summary>
    /// <param name="path"> the file path of the bin file </param>
    /// <returns> a sorted dictionary for faster query speeds </returns>
    public SortedDictionary<string, string> ConvertToSortedDictionary(string path)
    {
        Dictionary<string, string> dictionary = Bin.ConvertBinFileToDictonary(path);
        return new SortedDictionary<string, string>(dictionary);
    }

    /// <summary>
    /// Works just like the RainbowTableAttack, but Dictionary file consists of previously CRACKED! passwords
    /// </summary>
    public void CrackedPasswordAttack(string hashToCrack)
    {
        try
        {
            Password = CrackedPasswords[hashToCrack];
            Console.Write($"Password CRACKED! Hash was found in CrackedEntries.bin\nWithin arrows -->{Password}<--\nEnter anything to continue");
        }
        catch (KeyNotFoundException) { Console.Write($"Hashed Key is not within CrackedEntries.bin, Password not found. Enter anything to continue."); }
    }

    /// <summary>
    /// Used to first check if there are any matching hashes in any available RainbowTable (Dictionary) binary file. 
    /// The System.Collections.Generic.Dictionary C# class can hold over 2 billion entries. This equates to around 131 GB of space if a full Dictionary
    /// were written to a file. For this reason and example, I will limit this Dictionary to hold only 95^3 + 95^2 + 95^1 entries as this will be around 100 MB.
    /// 95^4, or a 4 character password has above 81,450,625 possible combinations. This equates to around 5 GB and a bit too large to exemplify.
    /// </summary>
    public void Attack(string hashToCrack)
    {
        int i = 0;
        while (i < RainbowTables.Count)
        {
            Current = RainbowTables[i];
            try
            {
                Password = Current[hashToCrack];
                Console.WriteLine($"Password CRACKED! Hash found within RainbowTable{i}.bin\nWithin arrows -->{Password}<--\nEnter anything to continue");
                return;
            }
            catch (Exception)
            {
                i++;
            }
        }
        Console.WriteLine("Hash was not found in any RainbowTable bin file. Enter anything to continue");
    }
}

