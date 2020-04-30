using System;
using System.IO;
using SubLangEncoder;

namespace ClientApplication
{
    public class Program
    {
        private const string Lang = ".pt";

        public static void Main()
        {
            var path = GetPath();
            var encoder = new SubEncoder(path, Lang);
            encoder.Encode();
            Console.WriteLine($"All subtitle files within the path were coded to {Lang} language");
        }

        private static string GetPath()
        {
            string path;
            do
            {
                Console.Write("Path: ");
                path = Console.ReadLine();
                if (!Directory.Exists(path))
                {
                    Console.WriteLine($"Error: Path \"{path}\" doesn't exist!\n");
                }
                else
                {
                    break;
                }
            } while (true);

            return path;
        }
    }
}