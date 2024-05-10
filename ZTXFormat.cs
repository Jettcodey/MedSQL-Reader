using System;
using System.Collections.Generic;
using System.Text;

namespace MedSQL_Reader
{
    public class ZTXFormat
    {
        public bool IsValidZTX(string content)
        {
            return content.Contains("col_01") && content.Contains("<zs>");
        }

        public string FormatContent(List<Dictionary<string, string>> entries)
        {
            StringBuilder formattedContent = new StringBuilder();

            foreach (var entry in entries)
            {
                foreach (var keyValue in entry)
                {
                    formattedContent.AppendLine($"{keyValue.Key}: {keyValue.Value}");
                }
                formattedContent.AppendLine(); // Add a blank line between entries
            }

            return formattedContent.ToString();
        }

        public List<Dictionary<string, string>> ParseLines(string content)
        {
            string[] lines = content.Split(new string[] { "<zs>;" }, StringSplitOptions.RemoveEmptyEntries);

            List<Dictionary<string, string>> entries = new List<Dictionary<string, string>>();

            foreach (string line in lines)
            {
                Dictionary<string, string> entry = ParseLine(line);
                entries.Add(entry);
            }

            return entries;
        }

        private Dictionary<string, string> ParseLine(string line)
        {
            string[] tokens = line.Split(new string[] { "<zs>," }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> entry = new Dictionary<string, string>();

            foreach (string token in tokens)
            {
                string[] keyValue = token.Split(new string[] { "<zs>" }, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 2) // Ensure keyValue has exactly 2 elements
                {
                    entry[keyValue[0]] = keyValue[1];
                }
            }

            return entry;
        }

    }
}