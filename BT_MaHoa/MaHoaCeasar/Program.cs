using System;
using System.IO;

namespace MaHoaCeasar
{
    class Program
    {
        static string CeasarCipher(string plainText, int key)
        {
            int n = plainText.Length;
            string cipherText = "";
            int root;

            for (int i = 0; i < n; i++)
            {
                if (plainText[i] >= 'a' && plainText[i] <= 'z')
                    root = 'a';
                else if (plainText[i] >= 'A' && plainText[i] <= 'Z')
                    root = 'A';
                else
                    root = 0;

                if (root != 0)
                {
                    int asc = plainText[i] - root;
                    asc = (26 + asc + key) % 26;
                    cipherText += (char)(asc + root);
                }
                else
                {
                    cipherText += plainText[i];
                }
            }

            return cipherText;
        }

        static void Main(string[] args)
        {
            char type = args[0][0];
            int key = int.Parse(args[1]);
            string srcfile = args[2];
            string destfile = args[3];

            Console.WriteLine("CEASAR FILE ENCRYPTION & DECRYPTION ");
            Console.WriteLine("Type: " + type);
            Console.WriteLine("Key: " + key);
            Console.WriteLine("Source file: " + srcfile);
            Console.WriteLine("Destination file: " + destfile);

            using (StreamReader inp = new StreamReader(srcfile))
            using (StreamWriter outp = new StreamWriter(destfile))
            {
                string s, t;
                while ((s = inp.ReadLine()) != null)
                {
                    if (type == 'e')
                        t = CeasarCipher(s, key);
                    else
                        t = CeasarCipher(s, -key);

                    outp.WriteLine(t);
                }
            }

            Console.WriteLine();
            if (type == 'e')
                Console.WriteLine("Encryption successful.");
            else
                Console.WriteLine("Decryption successful.");
        }
    }

}