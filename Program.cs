///////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: Designed to show how a modern Hashing algorithm is not able to
// be reverse-engineered. 
//
// To create a new hash, simply create a new instance of the SHA256 class and 
// insert the string input you would like to have hashed. The Output property
// displays the hashed output.
//
///////////////////////////////////////////////////////////////////////////////
namespace SHA256_Encryption;

internal class Program
{
    static void Main(string[] args)
    {
        SHA256 hash = new("Andrew123");

        Console.WriteLine(hash.Output);
    }
}