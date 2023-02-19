using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Histogram;

static class Program
{
    public static void Main()
    {
        var inputText = File.ReadAllText("input.txt");
        var data = new Dictionary<char, int>();
        foreach (char c in inputText)
        {
            if (c != ' ' & c != '\r' & c != '\n')
            {
                if (!data.ContainsKey(c))
                {
                    data.Add(c, 1);
                }
                else
                {
                    data[c]++;
                }
            }
        }
        var maxValue = data.Values.Max();
        var result = new char[maxValue + 1,data.Count];
        var allKeys = data.Select(d => d.Key).OrderBy(x=>x).ToArray();
        
        //Add count visualaze to array
        for (var i = 0; i < allKeys.Length; i++)
        {
            //Add words to array
            result[maxValue, i] = allKeys[i];
            int countWord = data[allKeys[i]];
            for (var j = countWord; j > 0; j--)
            {
                result[maxValue - j, i] = '#';
            }
            
        }

        using var filestream = new StreamWriter("output.txt");
        {
            for (var i = 0; i < maxValue + 1; i++)
            {
                for (var j = 0; j < data.Count; j++)
                {
                    //Fill \0 symbol with whitespace characters
                    if (result[i, j] == '\0')
                    {
                        result[i, j] = ' ';
                    }
                    filestream.Write(result[i, j]);
                }

                filestream.WriteLine();
            }
        }
    }
}