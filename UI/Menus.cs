///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: This class is to show the very many windows that are included in this program
//
///////////////////////////////////////////////////////////////////////////////////
namespace SHA256_Encryption.UI;

/// <summary>
/// static class that is used to return string representations of different menus
/// </summary>
internal static class Menus
{
    /// <summary>
    /// returns the static, non-moving, part of the mene.
    /// </summary>
    /// <returns> string </returns>
    public static string MainMenu()
    {
        return
            $"┌──────────────────────────────────────────NIST SHA256 ENCRYPTOR & DECRYPTOR─────────────────────────────────────────┐\n" +
            $"├─────────────────────────────────────────────────────  Welcome  ────────────────────────────────────────────────────┤\n" +
            $"├──────────────────────────────────────────────────┐   Main Menu   ┌─────────────────────────────────────────────────┤\n" +
            $"│                 Encrypt                          └───────────────┘                      Decrypt                    │\n" +
            $"├──────────────────────────────────────────────┐    Dispatch  Table    ┌─────────────────────────────────────────────┤\n";
    }

    /// <summary>
    /// returns the menu for option 1.
    /// </summary>
    /// <returns> string for option 1 </returns>
    public static string EncryptMenu()
    {
        return
            $"├─────────── SHA256 ENCRYPTION ────────────────┴─                     ─┴─────────────────────────────────────────────┘\n" +
            $"├─Please Enter any keyboard input below                                                                               \n" +
            $"│                                                                                                                     \n" +
            $"└───                                                                                                                    ";
    }

    /// <summary>
    /// Gives the output for the result of the encrypt menu.
    /// </summary>
    /// <param name="hash"> the encrypted hash output </param>
    /// <returns> a string sha256 hash </returns>
    public static string ReturnEncryption(string hash)
    {
        return
            $"├─────────── SHA256 ENCRYPTION ────────────────┴─                     ─┴─────────────────────────────────────────────┘\n" +
            $"├─Finished                                                                                                            \n" +
            $"│                                                                                                                     \n" +
            $"└───{hash}                                                                                                              ";
    }

    /// <summary>
    /// Show the user more about the program
    /// </summary>
    /// <returns> a string about 'page' </returns>
    public static string AboutMenu()
    {
        return
            $"├───── ABOUT SHA256 ENCRYPTOR & DECRYPTOR ─────┴─                     ─┴─────────────────────────────────────────────┘\n" +
            $"│                                                                                                                     \n" +
            $"├─The SHA256 Encryptor & Decryptor program is a lightweight and portable hacking tool that is extremely powerful.     \n" +
            $"│ Choosing from the list of options options gives the user a variety of tools. These tools include encryption of      \n" +
            $"│ passwords or phrases using the SHA256 encryption hashing algorithm (NIST Standardized and Tested) and the           \n" +
            $"│ associated methods for decrypting (or cracking) SHA256 hashes.                                                      \n" +
            $"│                                                                                                                     \n" +
            $"│                                                                                                                     \n" +
            $"│ Please use this tool at your own risk.                                                                              \n" +
            $"│ -Å∩DRΣW MCDσπαLD HACKING TΩΩLS                                                                                      \n" +
            $"│                                                                                                                     \n" +
            $"└─Enter anything to Exit                                                                                                ";
    }


    /// <summary>
    /// This is the standard menu option display for all cracked entry types
    /// </summary>
    /// <returns> the decrypt menu </returns>
    public static string DecryptCrackedMenu()
    {
        return
            $"└──────────────────────────────────────────────┴─                     ─┴─────────── USING CRACKED ENTRIES ───────────┤\n" +
            $"                                                                              Paste and Enter a SHA256 Hash here─────┤\n" +
            $"                                                                                                               ⌡     │\n" +
            $"                                                  ┌──                                                                │\n" +
            $"                                                  └──────────────────────────────────────────────────────────────────┘";
    }

    /// <summary>
    /// This is the standard menu option display for all rainbow attack types
    /// </summary>
    /// <returns> the decrypt menu </returns>
    public static string DecryptRainbowMenu()
    {
        return
            $"└──────────────────────────────────────────────┴─                     ─┴──────────── USING RAINBOW TABLE ────────────┤\n" +
            $"                                                     Paste and Enter a SHA256 Hash below                             │\n" +
            $"                                                                                                                     │\n" +
            $"                                                  ┌──                                                                │\n" +
            $"                                                  └──────────────────────────────────────────────────────────────────┘";
    }

    /// <summary>
    /// This is the standard menu option display for all attack types
    /// </summary>
    /// <returns> the decrypt menu </returns>
    public static string DecryptBruteForceMenu()
    {
        return
            $"└──────────────────────────────────────────────┘                       └───────────── BRUTE FORCE ATTACK ────────────┤\n" +
            $"                                                     Paste and Enter a SHA256 Hash below                             │\n" +
            $"                                                                                                                     │\n" +
            $"                                                  ┌──                                                                │\n" +
            $"                                                  └──────────────────────────────────────────────────────────────────┘";
    }

    /// <summary>
    /// This method will iterate as many times as there are rainbowtable bin files, or if used for the brute force guessing attack,
    /// it will iterate through as many combinations until it displays the hash being cracked.
    /// The bin file currently being used or the current pswd, and the message displaying the progress if the password was cracked, or if the 
    /// hash was not within the tables.
    /// </summary>
    /// <param name="hash"> the 64 char hash to crack </param>
    /// <param name="current"> either the current file being searched through or the current pswd iteration </param>
    /// <param name="message"> the </param>
    /// <returns></returns>
    public static string DecryptInProgress(string hash)
    {
        return
            $"└──────────────────────────────────────────────┘                       └────────── DECRYPTION IN PROGRESS ───────────┤\n" +
            $"                                                                                                                     │\n" +
            $"                                                                                                                     │\n" +
            $"                                                  ┌──{hash}│\n" +
            $"                                                  │                                                                  │\n" +
            $"                                                  ├────                                                              │\n" +
            $"                                                  │                                                                  │\n" +
            $"                                                  ├──────                                                            │\n" +
            $"                                                  │                                                                  │\n" +
            $"                                                  └──────────────────────────────────────────────────────────────────┘";
    }

    public static string HowToMenu()
    {
        return
            $"├───────────────── HOW TO USE ─────────────────┴─                     ─┴─────────────────────────────────────────────┘\n" +
            $"│                                                                                                                     \n" +
            $"├─Use the arrow keys to maneuver between options. Press the Enter key to select any option within the moving arrows.  \n" +
            $"│ When using a Decryption attack, copy a SHA256 hash to your clip board. You can use the 'SHA256 Encrypt Input' option\n" +
            $"│ or you can use an online SHA256 encryption. When using online hashes, make sure the hex 'letters' are capitalized.  \n" +
            $"│ The RainbowTable options cannot start until the objects have fully loaded. A notification will come when all objects\n" +
            $"│ are loaded into the program. For the BruteForce option, the program will continue until the hash is cracked.        \n" +
            $"│                                                                                                                     \n" +
            $"│ 'Have fun and do not do anything illegal!'                                                                          \n" +
            $"│                                                                                                                     \n" +
            $"│                   -Å∩DRΣW MCDσπαLD HACKING TΩΩLS                                                                    \n" +
            $"│                                                                                                                     \n" +
            $"└─Enter anything to Exit                                                                                                ";
    }

}
