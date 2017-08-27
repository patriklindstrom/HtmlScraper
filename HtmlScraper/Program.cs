using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HtmlScraper
{
    class Program
    {
        
        // http://html-agility-pack.net/?z=codeplex
        static void Main(string[] args)
        {
            // From Web

            //$menu = $(Invoke-WebRequest "https://www.sabis.se/skandia/dagens-lunch/").AllElements | 
            // Where Class -eq "lunch-day-container" | Select - ExpandProperty innerText
            var url = "https://www.sabis.se/skandia/dagens-lunch/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, \'lunch-day-container\')]");
            Debug.Assert(nodes != null, "nodes != null");
            Dictionary<DayOfWeek, String> weekMenu = new Dictionary<DayOfWeek, string>
            {
                [DayOfWeek.Monday] = nodes[0].InnerText,
                [DayOfWeek.Tuesday] = nodes[1].InnerText,
                [DayOfWeek.Wednesday] = nodes[2].InnerText,
                [DayOfWeek.Thursday] = nodes[3].InnerText,
                [DayOfWeek.Friday] = nodes[4].InnerText
            };
            foreach (var lunch in weekMenu)
            {
                Console.WriteLine(lunch.Value);
                Console.WriteLine("");
            }
            Console.ForegroundColor=ConsoleColor.DarkRed;
         Console.WriteLine("Hit any key to exit");
            Console.ReadKey();
        }
    }
}
//  .Where(x => x.Attributes["class"].Value == "box"))