using System;
using System.Collections.Generic;
using System.Linq;

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
            return string.Join(Environment.NewLine + Environment.NewLine, entries.Select(entry =>
            {
                return string.Join(Environment.NewLine, entry.Select(kv => $"{kv.Key}: {kv.Value}"));
            }));
        }

        public List<Dictionary<string, string>> ParseLines(string content)
        {
            List<Dictionary<string, string>> entries = new List<Dictionary<string, string>>();

            string[] dataParts = content.Split(new string[] { "<zs>col_09<zs><zs>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in dataParts)
            {
                Dictionary<string, string> entry = ParsePart(part);
                entries.Add(entry);
            }

            return entries;
        }

        private Dictionary<string, string> ParsePart(string part)
        {
            Dictionary<string, string> entry = new Dictionary<string, string>();

            string[] tokens = part.Split(new string[] { "<zs>col_01<zs>" }, StringSplitOptions.RemoveEmptyEntries);

            string[] firstTokenKeyValue = tokens[0].Split(new string[] { "<zs>," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string keyValue in firstTokenKeyValue)
            {
                string[] pair = keyValue.Split(new string[] { "<zs>" }, StringSplitOptions.RemoveEmptyEntries);
                if (pair.Length == 2)
                {
                    string key = pair[0].Trim();
                    string value = pair[1].Trim();
                    entry[key] = value;
                }
            }

            for (int i = 1; i < tokens.Length; i++)
            {
                string[] keyValuePairs = tokens[i].Split(new string[] { "<zs>," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string pair in keyValuePairs)
                {
                    string[] pairValues = pair.Split(new string[] { "<zs>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (pairValues.Length == 2)
                    {
                        string key = pairValues[0].Trim();
                        string value = pairValues[1].Trim();
                        entry[key] = value;
                    }
                }
            }

            return entry;
        }
    }
}
