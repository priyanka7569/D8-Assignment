using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace D8_Assignment
{
    public class Count
    {
        public int Wordcount(string p)
        {
            int n = Regex.Matches(p, @"\b\w+\b").Count;
            return n;

        }
        public MatchCollection Email(string p)
        {
            MatchCollection match = Regex.Matches(p, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");

            if (match.Count > 0)
            {
                foreach (Match m in match)
                {
                    Console.WriteLine("Valid email address: " + m.Value);
                }
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            return match;
        }

        public string[] Mobile(string p)
        {
            string[] mob = new string[10];
            int i = 0;
            MatchCollection match = Regex.Matches(p, @"\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}");
            foreach (Match m in match)
            {
                if (i < mob.Length)
                {
                    mob[i] = m.Value;
                    i++;
                }
                else
                {
                    break;
                }
            }
            return mob;

        }

        public void Custom(string p, string customRegex)
        {
            Console.WriteLine("Custom Regex Search Results:");

            try
            {

                MatchCollection matches = Regex.Matches(p, customRegex);


                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error in custom regex: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Paragraph");
            string para = Console.ReadLine();
            Count count = new Count();
            int a = count.Wordcount(para);
            Console.WriteLine("The total number of words in the Paragraph is: " + a);
            MatchCollection s = count.Email(para);
            String[] s1 = new String[10];
            s1 = count.Mobile(para);
            for (int i = 0; i < s1.Length; i++)
            {
                if (!string.IsNullOrEmpty(s1[i]))
                {
                    Console.WriteLine("Valid Mobile Number: " + s1[i]);
                }
            }
            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();
            count.Custom(para, customRegex);
            Console.ReadKey();


        }
    }
}