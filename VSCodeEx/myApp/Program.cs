using System;
using System.Security.Cryptography;
using static System.Console;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //encryptdecrypt();
            //hashingSHA256();
            //signingData();
            randomizing();
        }

        private static void randomizing()
        {
            Write("How big do you want the key (in bytes): ");
            string size = ReadLine();
            byte[] key = Protector.GetRandomKeyOrIV(int.Parse(size));
            WriteLine($"Key as byte array:");
            for (int b = 0; b < key.Length; b++)
            {
                Write($"{key[b]:x2} ");
                if (((b + 1) % 16) == 0) WriteLine();
            }
            WriteLine();
        }

        private static void signingData()
        {
            Write("Enter some text to sign: ");
            string data = ReadLine();
            var signature = Protector.GenerateSignature(data);
            WriteLine($"Signature: {signature}");
            WriteLine("Public key used to check signature:");
            WriteLine(Protector.PublicKey);
            if (Protector.ValidateSignature(data, signature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine("Invalid signature.");
            }
            // simulate a fake signature by replacing the
            // first character with an X
            var fakeSignature = signature.Replace(signature[0], 'X');
            if (Protector.ValidateSignature(data, fakeSignature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine($"Invalid signature: {fakeSignature}");
            }

        }

        static void hashingSHA256()
        {
            WriteLine("Registering Alice with Pa$$w0rd.");
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine("Password (salted and hashed): {0}", arg0: alice.SaltedHashedPassword);
            WriteLine();
            Write("Enter a new user to register: ");
            string username = ReadLine();
            Write($"Enter a password for {username}: ");
            string password = ReadLine();
            var user = Protector.Register(username, password);
            WriteLine($"Name: {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine("Password (salted and hashed): {0}", arg0: user.SaltedHashedPassword);
            WriteLine();
            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a username to log in: ");
                string loginUsername = ReadLine();
                Write("Enter a password to log in: ");
                string loginPassword = ReadLine();
                correctPassword = Protector.CheckPassword(loginUsername, loginPassword);
                if (correctPassword)
                {
                    WriteLine($"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    WriteLine("Invalid username or password. Try again.");
                }
            }
        }

        private static void encryptdecrypt()
        {
            Console.Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();
            Write("Enter a password: ");
            string password = ReadLine();
            string cryptoText = Protector.Encrypt(message, password);
            WriteLine($"Encrypted text: {cryptoText}");
            Write("Enter the password: ");
            string password2 = ReadLine();
            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text: {clearText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine("{0}\nMore details: {1}",
                  arg0: "You entered the wrong password!",
                  arg1: ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine("Non-cryptographic exception: {0}, {1}",
                  arg0: ex.GetType().Name,
                  arg1: ex.Message);
            }
        }

    }
}
