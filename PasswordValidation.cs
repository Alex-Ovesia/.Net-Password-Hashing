using System.Security.Cryptography;
namespace PasswordValidation
{
    public class PasswordValidation
    {

        public static void Main()
        {
            try
            {
                Console.WriteLine("Username:");
                var user = Console.ReadLine();
                Console.WriteLine("Password:");
                var pass = Console.ReadLine();

                if(user != null && pass != null && login(user, pass))
                {
                    Console.WriteLine("Your Input Matches The Registered Password");
                }
                else
                {
                    Console.WriteLine("Your Input Does Not Match The Registered Password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        
        public static bool login(string username, string password)
        {
            string encryptuser = EncryptString(username);
            string encryptpass = EncryptString(password);
            if (validate(encryptuser, encryptpass))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        static bool validate(string user, string pass)
        {
            //checks if input matches user and pass
            string[] lines = File.ReadAllLines("Login.txt");
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
        
        static string EncryptString(string inputString)
        {
            // Convert the input string to a byte array and hash it
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);

            // Convert the hashed bytes back to a string and return it
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
