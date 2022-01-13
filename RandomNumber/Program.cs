using System;
using System.Security.Cryptography;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            NotSoRandomNumber();
            //SecureRandomNumber();
        }

        #region *** Not so Random Numbers with Random-class ***
        static void NotSoRandomNumber()
        {
            Random rnd = new Random(250);

            for (int ctr = 0; ctr < 10; ctr++)
            {
                Console.Write("{0,3} ", rnd.Next(-10, 11));
            }

            Console.WriteLine("\n\n*** Run again with same Seed value ***");
            rnd = new Random(250);
            for (int ctr = 0; ctr < 10; ctr++)
            {
                Console.Write("{0,3} ", rnd.Next(-10, 11));
            }

            Console.WriteLine("\n\n*** Run again with same Random object ***");
            for (int ctr = 0; ctr < 10; ctr++)
            {
                Console.Write("{0,3} ", rnd.Next(-10, 11));
            }
        }
        #endregion

        #region *** Much more Random Numbers with RNGCryptoServiceProvider ***
        static void SecureRandomNumber()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random Number {i}: {Convert.ToBase64String(SecureRandom.GenerateRandomNumber(32))}");
            }
        }
        #endregion
    }

    #region ***SecureRandom class ***
    class SecureRandom
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }
    #endregion
}