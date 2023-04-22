///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: Correct implementation of NIST's SHA256 Hashing Algorithm Using C#
//
///////////////////////////////////////////////////////////////////////////////////
using System.Numerics;

namespace SHA256_Encryption;

/// <summary>
/// The class is layed out in 11 major steps, top to bottom, in order to display 
/// the encryption process of a string input.
/// </summary>
internal class SHA256
{
    public string Input { get; private set; }
    public string Output { get; private set; }
    public char[][] MessageBlock { get; private set; } = new char[16][];
    public char[][] MessageSchedule { get; private set; } = new char[64][];

    private static uint[] H = new uint[] {
      Convert.ToUInt32("6a09e667", 16), Convert.ToUInt32("bb67ae85", 16), Convert.ToUInt32("3c6ef372", 16), Convert.ToUInt32("a54ff53a", 16),
      Convert.ToUInt32("510e527f", 16), Convert.ToUInt32("9b05688c", 16), Convert.ToUInt32("1f83d9ab", 16), Convert.ToUInt32("5be0cd19", 16)
    };
    private static uint[] K = new uint[] {
      Convert.ToUInt32("428a2f98", 16), Convert.ToUInt32("71374491", 16), Convert.ToUInt32("b5c0fbcf", 16), Convert.ToUInt32("e9b5dba5", 16), Convert.ToUInt32("3956c25b", 16), Convert.ToUInt32("59f111f1", 16), Convert.ToUInt32("923f82a4", 16), Convert.ToUInt32("ab1c5ed5", 16),
      Convert.ToUInt32("d807aa98", 16), Convert.ToUInt32("12835b01", 16), Convert.ToUInt32("243185be", 16), Convert.ToUInt32("550c7dc3", 16), Convert.ToUInt32("72be5d74", 16), Convert.ToUInt32("80deb1fe", 16), Convert.ToUInt32("9bdc06a7", 16), Convert.ToUInt32("c19bf174", 16),
      Convert.ToUInt32("e49b69c1", 16), Convert.ToUInt32("efbe4786", 16), Convert.ToUInt32("0fc19dc6", 16), Convert.ToUInt32("240ca1cc", 16), Convert.ToUInt32("2de92c6f", 16), Convert.ToUInt32("4a7484aa", 16), Convert.ToUInt32("5cb0a9dc", 16), Convert.ToUInt32("76f988da", 16),
      Convert.ToUInt32("983e5152", 16), Convert.ToUInt32("a831c66d", 16), Convert.ToUInt32("b00327c8", 16), Convert.ToUInt32("bf597fc7", 16), Convert.ToUInt32("c6e00bf3", 16), Convert.ToUInt32("d5a79147", 16), Convert.ToUInt32("06ca6351", 16), Convert.ToUInt32("14292967", 16),
      Convert.ToUInt32("27b70a85", 16), Convert.ToUInt32("2e1b2138", 16), Convert.ToUInt32("4d2c6dfc", 16), Convert.ToUInt32("53380d13", 16), Convert.ToUInt32("650a7354", 16), Convert.ToUInt32("766a0abb", 16), Convert.ToUInt32("81c2c92e", 16), Convert.ToUInt32("92722c85", 16),
      Convert.ToUInt32("a2bfe8a1", 16), Convert.ToUInt32("a81a664b", 16), Convert.ToUInt32("c24b8b70", 16), Convert.ToUInt32("c76c51a3", 16), Convert.ToUInt32("d192e819", 16), Convert.ToUInt32("d6990624", 16), Convert.ToUInt32("f40e3585", 16), Convert.ToUInt32("106aa070", 16),
      Convert.ToUInt32("19a4c116", 16), Convert.ToUInt32("1e376c08", 16), Convert.ToUInt32("2748774c", 16), Convert.ToUInt32("34b0bcb5", 16), Convert.ToUInt32("391c0cb3", 16), Convert.ToUInt32("4ed8aa4a", 16), Convert.ToUInt32("5b9cca4f", 16), Convert.ToUInt32("682e6ff3", 16),
      Convert.ToUInt32("748f82ee", 16), Convert.ToUInt32("78a5636f", 16), Convert.ToUInt32("84c87814", 16), Convert.ToUInt32("8cc70208", 16), Convert.ToUInt32("90befffa", 16), Convert.ToUInt32("a4506ceb", 16), Convert.ToUInt32("bef9a3f7", 16), Convert.ToUInt32("c67178f2", 16)
    };
    private static uint a = H[0];
    private static uint b = H[1];
    private static uint c = H[2];
    private static uint d = H[3];
    private static uint e = H[4];
    private static uint f = H[5];
    private static uint g = H[6];
    private static uint h = H[7];


    /// <summary>
    /// This is the ctor to encrypt any string up to 55 characters using the SHA256 Hashing Algorithm by NIST standards.
    /// </summary>
    /// <param name="input"> the string to hash </param>
    /// <exception cref="ArgumentOutOfRangeException"> If the input is over 55 chars, throw exc. </exception>
    public SHA256(string input)
    {
        if (input.Length > 55)
        {
            Console.WriteLine("Cannot have a password over 55 characters.");
            throw new ArgumentOutOfRangeException();
        }

        Input = input;

        for (int i = 0; i < MessageBlock.Length; i++)
        {
            MessageBlock[i] = new char[32];
        }
        MessageBlock = Create512BitMessageBlock(input);

        for (int i = 0; i < MessageSchedule.Length; i++)
        {
            MessageSchedule[i] = new char[32];
        }
        MessageSchedule = Create64EntryMessageSchedule(MessageBlock);

        Output = UpdateWorkingVariablesAndReturnHash();
    }

    /// <summary>
    /// In SHA256, a 512 bit message block is created. This method creates this message block
    /// by using a char Jagged Array and fills the associated indexes with the correct binary bit character.
    /// </summary>
    /// <param name="input"> the string input the user wants to encrypt </param>
    /// <returns> a char jagged array message block </returns>
    public char[][] Create512BitMessageBlock(string input)
    {
        // 1.Encode the input to binary using UTF-8 and append a single '1' to it.
        string binaryInput = StringToBinary(input);
        int originalMessageLength = binaryInput.Length;
        binaryInput += "1";

        // 2. Prepend binaryInput to and append 0's until there are 448 bits.
        for (int i = binaryInput.Length; i < 448; i++)
        {
            binaryInput += "0";
        }

        // 3. Append the original message length (in decimal) at the end of the message block as a 64-bit big-endian integer.
        binaryInput += IntToBinary(originalMessageLength);

        // 4. Original Message Length bits + 1 bit + (448 '0 bits' - 1 bit - Original Message Length bits - ) + 64bit big-endian bits = 512 bits
        int row = 0; int col = 0; int idx = 0;
        while (idx < binaryInput.Length)
        {
            if (col < 32) MessageBlock[row][col++] = binaryInput[idx++];
            else
            {
                row++;
                col = 0;
            }
        }

        return MessageBlock;
    }
    /// <summary>
    /// This method's purpose is to convert the user input string to binary.
    /// </summary>
    /// <param name="str"> the input string </param>
    /// <returns> a binary string representation of the input message </returns>
    private string StringToBinary(string str)
    {
        string s = string.Empty;
        foreach (char c in str)
        {
            s += Convert.ToString((int)c, 2).PadLeft(8, '0');
        }
        return s;
    }
    /// <summary>
    /// This method is used to return the original message's length in a binary string representation.
    /// </summary>
    /// <param name="originalMessageLength"> the length of the original input string </param>
    /// <returns> a binary representation of the input length </returns>
    private string IntToBinary(int originalMessageLength)
    {
        string s = Convert.ToString(originalMessageLength, 2).PadLeft(64, '0');
        return s;
    }

    /// <summary>
    /// This method is used to create a MessageSchedule where many bitwise operations will occur using
    /// the SHA256 constants and the finished message block.
    /// </summary>
    /// <param name="messageBlock"> the finished message block </param>
    /// <returns> a jagged array representing the message schedule </returns>
    public char[][] Create64EntryMessageSchedule(char[][] messageBlock)
    {
        // 5. Copy 1st chunk into 1st 16 words w[0..15] of the message schedule array.
        for (int i = 0; i < messageBlock.Length; i++)
        {
            MessageSchedule[i] = messageBlock[i];
        }

        for (int i = messageBlock.Length; i < MessageSchedule.Length; i++)
        {
            string bin = "00000000000000000000000000000000";
            MessageSchedule[i] = bin.ToCharArray();
        }

        for (int i = 0; i < MessageSchedule.Length; i++)
        {
            if (i + 16 < MessageSchedule.Length)
            {
                // 6. Calculate σ0 = (w1 rightrotate 7) xor (w1 rightrotate 18) xor (w1 rightshift 3)
                uint num0 = Convert.ToUInt32(new string(MessageSchedule[i + 1]), 2);
                long lowerSigma0 = BitOperations.RotateRight(num0, 7) ^ BitOperations.RotateRight(num0, 18) ^ num0 >> 3;

                // 7. Calculate σ1 = (w14 rightrotate 17) xor (w14 rightrotate 19) xor (w14 rightshift 10)
                uint num1 = Convert.ToUInt32(new string(MessageSchedule[i + 14]), 2);
                long lowerSigma1 = BitOperations.RotateRight(num1, 17) ^ BitOperations.RotateRight(num1, 19) ^ num1 >> 10;

                // 8. Calculate w16 = w0 + σ0 + w9 + σ1
                uint w = (uint)(Convert.ToUInt32(new string(MessageSchedule[i]), 2) + lowerSigma0 + Convert.ToUInt32(new string(MessageSchedule[i + 9]), 2) + lowerSigma1);

                MessageSchedule[i + 16] = Convert.ToString(w, 2).PadLeft(32, '0').ToCharArray();
            }
        }

        return MessageSchedule;
    }

    /// <summary>
    /// This is the major last method to update the SHA256 constants and to output
    /// a final hash string.
    /// </summary>
    /// <returns> the hashed output from the input </returns>
    public string UpdateWorkingVariablesAndReturnHash()
    {
        for (int i = 0; i < MessageSchedule.Length; i++)
        {
            long upperSigma1 = BitOperations.RotateRight(e, 6) ^ BitOperations.RotateRight(e, 11) ^ BitOperations.RotateRight(e, 25);
            long choice = (e & f) ^ ((~e) & g);
            long upperSigma0 = BitOperations.RotateRight(a, 2) ^ BitOperations.RotateRight(a, 13) ^ BitOperations.RotateRight(a, 22);
            long majority = (a & b) ^ (a & c) ^ (b & c);
            long word = Convert.ToUInt32(new string(MessageSchedule[i]).PadLeft(32, '0'), 2);

            long temp1 = h + upperSigma1 + choice + K[i] + word;
            string tmp1 = Convert.ToString(temp1, 2);
            if (tmp1.Length > 32)
            {
                int deletes = tmp1.Length - 32;
                char[] t = tmp1.ToCharArray();
                string newString = String.Empty;
                for (int j = 0; j < t.Length - deletes; j++)
                {
                    newString += t[j + deletes];
                }

                temp1 = Convert.ToUInt32(new string(newString).PadLeft(32, '0'), 2);
            }

            long temp2 = upperSigma0 + majority;
            string tmp2 = Convert.ToString(temp2, 2);
            if (tmp2.Length > 32)
            {
                int deletes = tmp2.Length - 32;
                char[] t = tmp2.ToCharArray();
                string newString = String.Empty;
                for (int j = 0; j < t.Length - deletes; j++)
                {
                    newString += t[j + deletes];
                }

                temp2 = Convert.ToUInt32(new string(newString).PadLeft(32, '0'), 2);
            }

            // 9. Update working variables every iteration
            h = g;
            g = f;
            f = e;
            e = (uint)(d + temp1);
            d = c;
            c = b;
            b = a;
            a = (uint)(temp1 + temp2);
        }

        // 10. Add the working variables to the current hash value:
        H[0] += a;
        H[1] += b;
        H[2] += c;
        H[3] += d;
        H[4] += e;
        H[5] += f;
        H[6] += g;
        H[7] += h;

        string rtrn = String.Empty;
        for (int i = 0; i < H.Length; i++)
        {
            rtrn += H[i].ToString("X").PadLeft(8, '0');
        }
        // 11. Append hash values to get final digest: Sha256 = h0 h1 h2 h3 h4 h5 h6 h7
        return rtrn;
    }
}