using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NielsenTag
{
    class Program
    {
        static void Main(String []args)//TODO: use commandline to get website
        {
            Console.WriteLine("Hello World\n");
            String website = "http://www.nielsen.com/us/en.html";
            //"http://secure-us.imrworldwide.com/cgi-bin/m?ci=us-801796h&amp;cg=0&amp;cc=1&amp;si=http://www.foxnews.com/&amp;ts=noscript&amp;rnd=1316607490"
            Match m;//"http://<domain>/[priv|cgi]-bin/[m|k|g|j|i|w|a|b|s|o]?<query_string>";
            //m=Regex.Matches(WebFetch.PageSource(website),"((?::\\/{2}[\\w]+)(?:[\\/|\\.]?)(?:[^\\s\"]*))",RegexOptions.Multiline);
            m = Regex.Match(WebFetch.PageSource(website), @"(\S*)/([m|k|g|j|i|w|a|b|s|o])/(\S*)");
            //Console.WriteLine(WebFetch.HeaderInfo(website));
           /* if (m.Success)
            {*/
                /*foreach (Match g in m)
                {
                    Console.WriteLine(g.Groups[1].Value);
                }
           /* }
            else
                Console.WriteLine("Fail!!");*/
            if (m.Success)
                Console.WriteLine(m.Groups[1].Value);
            else
                Console.WriteLine("Failed!");
            Console.WriteLine("Program End!");
            Console.ReadLine();
        }
    }
}
