using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor, informe a mensagem que deseja criptografar.");
            InputData();
        }

        static void InputData()
        {
            string data = Console.ReadLine();
            Console.WriteLine($"Input: {data}");

            string hashedData = ComputeSha256Hash(data);
            Console.WriteLine($"Hash: {hashedData}");

            Console.WriteLine("Deseja continuar? S/N");
            string wannaContinue = Console.ReadLine();

            if (wannaContinue.ToUpper() == "S")
                InputData();
        }

        static string ComputeSha256Hash(string rawData)
        {
            using var sha256Hash = HashAlgorithm.Create("SHA256");

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
  
            var builder = new StringBuilder();

            foreach (var item in bytes)
                builder.Append(item.ToString("x2"));

            return builder.ToString();
        }
    }
}
