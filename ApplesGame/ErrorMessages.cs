using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame
{
    public static class ErrorMessages
    {
        private static readonly Dictionary<string, string> messages = new();

        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Error messages file not found: {filePath}");

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=');
                if (parts.Length == 2)
                    messages[parts[0]] = parts[1];
            }
        }

        public static string Get(string key)
        {
            return messages.TryGetValue(key, out var message) ? message : "Unknown error.";
        }
    }
}
