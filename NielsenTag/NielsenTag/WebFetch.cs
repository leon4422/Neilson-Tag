using System;
using System.IO;
using System.Net;
using System.Text;


/// <summary>
/// Fetches a Web Page
/// </summary>
class WebFetch
{
    public static String PageSource(String str)
    {
		
        // used to build entire input
        StringBuilder sb = new StringBuilder();

        // used on each read operation
        byte[] buf = new byte[8192];

        // prepare the web page we will be asking for
        HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(str);

        // execute the request
        HttpWebResponse response = (HttpWebResponse)
            request.GetResponse();

        // we will read data via the response stream
        Stream resStream = response.GetResponseStream();

        string tempString = null;
        int count = 0;

        do
        {
            // fill the buffer with data
            count = resStream.Read(buf, 0, buf.Length);

            // make sure we read some data
            if (count != 0)
            {
                // translate from bytes to ASCII text
                tempString = Encoding.ASCII.GetString(buf, 0, count);

                // continue building the string
                sb.Append(tempString);
            }
        }
        while (count > 0); // any more data to read?

        // print out page source
        //Console.WriteLine(sb.ToString());
        return sb.ToString();
    }
    public static CookieCollection CookieInfo(String str)
    {
        CookieContainer CC = new CookieContainer();
        HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(str);
        Req.Proxy = null;
        Req.UseDefaultCredentials = true;
        //YOU MUST ASSIGN A COOKIE CONTAINER FOR THE REQUEST TO PULL THE COOKIES
        Req.CookieContainer = CC;
        HttpWebResponse Res = (HttpWebResponse)Req.GetResponse();
        //DUMP THE COOKIES
        Console.WriteLine("----- COOKIES -----");   
        if(Res.Cookies != null &&  Res.Cookies.Count != 0)
        {
	        foreach(Cookie c in Res.Cookies)
	        {
	         Console.WriteLine("\t" + c.ToString());
	        }
        }
        else
        {
	        Console.WriteLine("No Cookies");
        }
        return Res.Cookies;
    }
    public static WebHeaderCollection HeaderInfo(String str)
    {
        WebHeaderCollection CC = new WebHeaderCollection();
        HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(str);
        Req.Proxy = null;
        Req.UseDefaultCredentials = true;
        //YOU MUST ASSIGN A COOKIE CONTAINER FOR THE REQUEST TO PULL THE COOKIES
        //Req.Headers = CC;
        HttpWebResponse Res = (HttpWebResponse)Req.GetResponse();
        //DUMP THE COOKIES
        Console.WriteLine("----- HEADERS -----");   
        if(Res.Headers != null &&  Res.Headers.Count != 0)
        {
 
            foreach (string key in Res.Headers)
	        {
                Console.WriteLine("\t" + key.ToString() + "\t" + Res.Headers[key]);
	        }
        }
        else
        {
	        Console.WriteLine("No Headers");
        }
        return Res.Headers;
    }
}