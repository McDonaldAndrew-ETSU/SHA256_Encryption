///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: This class is used to create the 'magic' to make the different 
// arrow cursors move around on a selected object. The class also includes the methods
// used to navigate the menu
//
///////////////////////////////////////////////////////////////////////////////////
namespace SHA256_Encryption.UI;

/// <summary>
/// contains switch statement logic to loop through different options and display 
/// a menu animation
/// </summary>
internal static class MenuChoices
{
    public static readonly string[] option1 =
    {       //Choose op 1
            $"│ --»>  Option 1: SHA256 Encrypt Input  <«--   └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│  --»> Option 1: SHA256 Encrypt Input <«--    └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│   --»>Option 1: SHA256 Encrypt Input<«--     └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };
    public static readonly string[] option2 =
    {       //Choose op 2
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│   --»>  Option 2: Exit Application  <«--                                       Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│    --»> Option 2: Exit Application <«--                                        Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│     --»>Option 2: Exit Application<«--                                         Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };
    public static readonly string[] option3 =
    {       //Choose op 3
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│      --»>  Option 3:  About  <«--                                                  Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│       --»> Option 3:  About <«--                                                   Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│        --»>Option 3:  About<«--                                                    Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };
    public static readonly string[] option4 =
    {       //Choose op 4
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘  --»>  Option 4: Rainbow Table Attack  <«-- │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘   --»> Option 4: Rainbow Table Attack <«--  │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘    --»>Option 4: Rainbow Table Attack<«--   │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };
    public static readonly string[] option5 =
    {       //Choose op 5
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                       --»>  Option 5: BruteForce Attack  <«--   │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                        --»> Option 5: BruteForce Attack <«--    │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                         --»>Option 5: BruteForce Attack<«--     │\n" +
            $"│            Option 3:  About                                                        Option 6:  How To               │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };
    public static readonly string[] option6 =
    {       //Choose op 6
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                  --»>  Option 6:  How To  <«--         │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                   --»> Option 6:  How To <«--          │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"│       Option 1: SHA256 Encrypt Input         └─                     ─┘        Option 4: Rainbow Table Attack       │\n" +
            $"│         Option 2: Exit Application                                             Option 5: BruteForce Attack         │\n" +
            $"│            Option 3:  About                                                    --»>Option 6:  How To<«--           │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n"
    };

    public static readonly string[] cracked =
    {
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                       --»>  Option 1: Use CrackedEntries.bin  <«-- │\n" +
            $"│ Press Escape to Exit                                                         Option 2: Use Rainbow bin files       │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                        --»> Option 1: Use CrackedEntries.bin <«--  │\n" +
            $"│ Press Escape to Exit                                                         Option 2: Use Rainbow bin files       │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                         --»>Option 1: Use CrackedEntries.bin<«--   │\n" +
            $"│ Press Escape to Exit                                                         Option 2: Use Rainbow bin files       │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
    };
    public static readonly string[] rainbow = {
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                             Option 1: Use CrackedEntries.bin       │\n" +
            $"│ Press Escape to Exit                                                   --»>  Option 2: Use Rainbow bin files  <«-- │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                             Option 1: Use CrackedEntries.bin       │\n" +
            $"│ Press Escape to Exit                                                    --»> Option 2: Use Rainbow bin files <«--  │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
            $"├──────────────────────────────────────────────┴─                     ─┴─────────────RAINBOW TABLE ATTACK────────────┤\n" +
            $"│                                                                             Option 1: Use CrackedEntries.bin       │\n" +
            $"│ Press Escape to Exit                                                     --»>Option 2: Use Rainbow bin files<«--   │\n" +
            $"└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘\n",
    };


    /// <summary>
    /// This is the main code of the program, where a user can select options on what they would ike to do that is
    /// included in the passed in dispatch Table.
    /// </summary>
    /// <param name="dispatchTable"> a dispatch Table to allow actions to happen </param>
    public static void Activate()
    {
        int idx = 0;
        bool contin = true;
        ConsoleKey currentKey;
        int currentPosition = 1;
        do
        {
            switch (currentPosition)
            {
                case 1:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option1[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option1[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option1[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.DownArrow &&
                        currentKey != ConsoleKey.RightArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[1]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.DownArrow) currentPosition = 2;
                    else currentPosition = 4;

                    break;
                case 2:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option2[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option2[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option2[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.UpArrow &&
                        currentKey != ConsoleKey.DownArrow &&
                        currentKey != ConsoleKey.RightArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) currentKey = Program.dispatchTable[2]();
                    if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.UpArrow) currentPosition = 1;
                    else if (currentKey == ConsoleKey.DownArrow) currentPosition = 3;
                    else currentPosition = 5;

                    break;
                case 3:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option3[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option3[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option3[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.UpArrow &&
                        currentKey != ConsoleKey.RightArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[3]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.UpArrow) currentPosition = 2;
                    else currentPosition = 6;

                    break;
                case 4:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option4[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option4[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option4[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.DownArrow &&
                        currentKey != ConsoleKey.LeftArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[4]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.DownArrow) currentPosition = 5;
                    else currentPosition = 1;

                    break;
                case 5:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option5[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option5[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option5[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.UpArrow &&
                        currentKey != ConsoleKey.LeftArrow &&
                        currentKey != ConsoleKey.DownArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[5]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.DownArrow) currentPosition = 6;
                    else if (currentKey == ConsoleKey.LeftArrow) currentPosition = 2;
                    else currentPosition = 4;

                    break;
                case 6:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.option6[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.option6[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.option6[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.UpArrow &&
                        currentKey != ConsoleKey.LeftArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[6]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.UpArrow) currentPosition = 5;
                    else currentPosition = 3;

                    break;
            }
        } while (contin);
    }

    /// <summary>
    /// This activates the mini menu to select a different rainbow attack
    /// </summary>
    /// <param name="dispatchTable"> the dispatch table to map to methods </param>
    public static void ActivateRainbowMenu()
    {
        int idx = 0;
        bool contin = true;
        ConsoleKey currentKey;
        int currentPosition = 1;
        do
        {
            switch (currentPosition)
            {
                case 1:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.cracked[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.cracked[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.cracked[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.DownArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[7]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.DownArrow) currentPosition = 2;
                    else currentPosition = 4;

                    break;
                case 2:
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            if (idx == 3)
                            {
                                idx -= 2;
                                Console.Write(MenuChoices.rainbow[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                                --idx;
                                Console.Write(MenuChoices.rainbow[idx]);
                                Thread.Sleep(150);
                                Console.SetCursorPosition(0, 5);
                            }
                            Console.Write(MenuChoices.rainbow[idx]);
                            Thread.Sleep(150);
                            Console.SetCursorPosition(0, 5);
                            ++idx;
                        }
                        Console.SetCursorPosition(0, 5);
                        currentKey = Console.ReadKey(true).Key;
                    } while (
                        currentKey != ConsoleKey.UpArrow &&
                        currentKey != ConsoleKey.Enter &&
                        currentKey != ConsoleKey.Escape);

                    if (currentKey == ConsoleKey.Enter) Program.dispatchTable[8]();
                    else if (currentKey == ConsoleKey.Escape) contin = false;
                    else if (currentKey == ConsoleKey.UpArrow) currentPosition = 1;
                    else currentPosition = 5;

                    break;
            }
        } while (contin);
    }
}
