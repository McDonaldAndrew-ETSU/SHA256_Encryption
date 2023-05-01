///////////////////////////////////////////////////////////////////////////////////
//
// Author: Andrew McDonald, mcdonaldai@etsu.edu
// Last Edited: 4/21/2023
// Description: This class handles everything that has to do with the Binary files
// including reading, writing, converting them into dictionaries, and converting 
// dictionaries to binary files
//
///////////////////////////////////////////////////////////////////////////////////
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SHA256_Encryption.binfiles;

/// <summary>
/// The bin handler constructor automatically creates new files in case none are in the directory
/// </summary>
internal class BinHandler
{
    public MemoryStream MemStream { get; private set; }
    public BinaryFormatter BinFormatter { get; private set; }
    public Dictionary<int, string> FilePaths { get; private set; }

    /// <summary>
    /// The ctor that sets all the properties.
    /// </summary>
    public BinHandler()
    {
        FileStream c = new("..\\..\\..\\binfiles\\CrackedEntries.bin", FileMode.OpenOrCreate);
        c.Close();
        FileStream r = new("..\\..\\..\\binfiles\\RainbowTable0.bin", FileMode.OpenOrCreate);
        r.Close();
        FilePaths = new Dictionary<int, string>();
        FindAnyFilePaths();

        MemStream = new();
        BinFormatter = new();
    }

    /// <summary>
    /// Method to figure out at any time how many RainbowTable files exist. It also sets the filepath dictionary each time is called
    /// </summary>
    /// <returns> the number of paths </returns>
    public void FindAnyFilePaths()
    {
        int i = 0;
        string path = $"..\\..\\..\\binfiles\\RainbowTable{i}.bin";
        while (File.Exists(path))
        {
            FilePaths[i] = path;
            ++i;
            path = $"..\\..\\..\\binfiles\\RainbowTable{i}.bin";
        }
    }


    /// <summary>
    /// Reads in an organized binary file and converts it to a dictionary.
    /// </summary>
    /// <param name="filePath"> the filepath of the bin file </param>
    /// <returns> a dictionary object </returns>
    public Dictionary<string, string> ConvertBinFileToDictonary(string filePath)
    {
        byte[] encodedDictionary = null;
        using (BinaryReader br = new BinaryReader(new FileStream(filePath, FileMode.Open)))
        {
            try { encodedDictionary = br.ReadBytes((int)br.BaseStream.Length); }
            catch (IOException) { }
        };

        MemStream = new();
        BinFormatter = new();

        MemStream.Write(encodedDictionary, 0, encodedDictionary.Length);
        MemStream.Position = 0;

        Dictionary<string, string> newD;
        //SortedDictionary<string, string> newS;
        try
        {
            newD = (Dictionary<string, string>)BinFormatter.Deserialize(MemStream);
            //newS = new SortedDictionary<string, string>(newD);
        }
        catch (SerializationException) { newD = new(); }// newS = new(); 

        return newD;
    }


    /// <summary>
    /// Pretty much used to clean up the CrackedEntries.bin file, as it will most likely
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public Dictionary<string, string> ConvertEntriesToDictionary(string filePath)
    {
        Dictionary<string, string> newer = new();
        string hash = string.Empty;
        string pswd = string.Empty;

        using (BinaryReader br = new BinaryReader(new FileStream(filePath, FileMode.Open)))
        {
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                try
                {
                    hash = br.ReadString();
                    pswd = br.ReadString();
                }
                catch (IOException) { }

                newer[hash] = pswd;
            }
        };

        return newer;
    }

    /// <summary>
    /// Writes entire dictionary object to a bin file for easy transportation.
    /// </summary>
    /// <param name="dictionary"> dictionary<string, string> object </string></param>
    /// <param name="filePath"> the file we will Write to </param>
    public void WriteDictionaryObjectToBinFile(Dictionary<string, string> dictionary, string filePath)
    {
        BinFormatter = new();
        MemStream = new();
        BinFormatter.Serialize(MemStream, dictionary);

        byte[] encoded = MemStream.ToArray();
        using (BinaryWriter writer = new(new FileStream(filePath, FileMode.Create)))
        {
            writer.Write(encoded);
        };
    }


    /// <summary>
    /// If a filePath is found, return filePath, if not, return a new filePath.
    /// </summary>
    /// <param name="filePath"> a file path </param>
    /// <returns> returns a string file path </returns>
    public string SelectFile(string filePath)
    {
        if (File.Exists(filePath)) return filePath;
        else
        {
            string newPath = $"..\\..\\..\\binfiles\\RainbowTable{FilePaths.Count}.bin";
            FileStream fS = File.Create(newPath);
            fS.Close();
            FilePaths[FilePaths.Count] = newPath;

            int idx = FilePaths.Count - 1;
            return FilePaths[idx];
        }
    }

    /// <summary>
    /// If the filePath returns a less than 866495 entry dictionary, return false, as the dictionary does not have enough entries.
    /// Else return true, as the dictionary has enough entries
    /// </summary>
    /// <param name="existingFilePath"> a file path that exists </param>
    /// <returns> true or false </returns>
    public bool IsFileFilled(string existingFilePath)
    {
        int count = ConvertBinFileToDictonary(existingFilePath).Count;
        if (count < 866495) return false;
        else return true;
    }
}
