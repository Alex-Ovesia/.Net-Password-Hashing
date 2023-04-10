using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace String.Hash
{
    public class Hash
    {
        public static bool setup = false;
        public static string? FilePath;
        public static void Setup(string path)
        {
            FilePath = path;
            setup = true;
        }
        public static bool Login(string username, string password)
        {
            Hash inst = new Hash();
            if (setup == true)
            {
                string encryptuser = HashString(username);
                string encryptpass = HashString(password);
                if (Validate(encryptuser, encryptpass))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool Validate(string user, string pass)
        {
            //checks if input matches user and pass
            Hash inst = new Hash();
            if (setup == true)
            {
                string[] lines = System.IO.File.ReadAllLines(FilePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if ((i == 0 || i % 2 != 0) && (i != lines.Length - 2 || i != lines.Length - 1))
                    {
                        if (lines[i] == user && lines[i + 1] == pass)
                            return true;
                    }
                    else if ((i == 0 || i % 2 != 0) && i == lines.Length - 2)
                    {
                        if (lines[i] == user && lines[i + 1] == pass)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                return false;
            }
            return false;
        }
        public static string HashString(string inputString)
        {
            // Convert the input string to a byte array and hash it
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);
            // Convert the hashed bytes back to a string and return it
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
