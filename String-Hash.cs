using System.Linq.Expressions;
using System.Security.Cryptography;

namespace OnlineCompiler
{
    public class PasswordValidation
    {

        public static void Main()
        {
            var input = "";
            Console.WriteLine("String To Hash:");
            try
            {
                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, That String Can Not Be Encrypted And Hashed For The Following Reason: " + e.Message + "This Application will close in 10 seconds");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }

            var empty = "";
            if (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    empty = empty + " ";
                }
            }
            else
            {
                Console.WriteLine("String Is Null, This Application will close in 5 seconds");
                Thread.Sleep(5000);
                Environment.Exit(0);

            }

            if (input != null && input != empty)
            {
                Console.WriteLine("Hashed String: " + EncryptString(input));
            }
            else
            {
                Console.WriteLine("String Is Null, This Application will close in 5 seconds");
                Thread.Sleep(5000);
                Environment.Exit(0);

            }

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
