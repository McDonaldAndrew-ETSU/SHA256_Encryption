///////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: Lightweight and powerful SHA256 hasher and decryptor!
//
///////////////////////////////////////////////////////////////////////////////
using SHA256_Encryption.AttackTypes;
using SHA256_Encryption.binfiles;
using SHA256_Encryption.UI;
using System.Diagnostics;

namespace SHA256_Encryption;

internal class Program
{
    private static readonly Stopwatch sw = new();
    private static readonly BinHandler binHandler = new();
    private static RainbowTableAttacks rfa;

    public static Task newTask = new(BinToObjectWorker);
    public static Dictionary<int, dynamic> dispatchTable = new();

    /// <summary>
    /// Main method to create most objects before program starts. The point is to show how to hash 
    /// a string input into a 64 char SHA256 hash.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        DispatchMaker.AddMostMethodsToDispatchTable(binHandler);

        sw.Start();
        Console.WriteLine("Converting all Bin files to SortedDictionary objects.\nThis may take a few minutes depending on number of bin files.\nPress enter if you would like to continue, or do not if you would like to wait.");
        newTask.Start();
        Console.ReadKey();
        Console.Clear();

        Console.Write(Menus.MainMenu());
        MenuChoices.Activate();

        Console.Clear();
        Console.WriteLine("Exiting...");
    }

    /// <summary>
    /// The other task to run in the background so the user can run other program's options.
    /// </summary>
    private static void BinToObjectWorker()
    {
        rfa = new(binHandler);
        sw.Stop();
        double min = sw.ElapsedMilliseconds / 60000.00;
        min = Math.Round(min, 2);
        Console.SetCursorPosition(0, 15);
        Console.WriteLine($"Task Finished Converting Bin Files to SortedDictionary objects in {min} minutes");
        Thread.Sleep(5000);
        Console.SetCursorPosition(0, 15);
        Console.WriteLine($"      Use the arrow keys to navigate.       Press Enter to select an option.        Press Esc to Exit.");
        DispatchMaker.AddRestOfMethodsToDispatchTable(rfa);
    }
}