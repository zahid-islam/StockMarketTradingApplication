using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace KaziEquitiesWebSite
{
    static public class Ticker
    {
        static DateTime newsTime;
        static string newsData = "";

        public static DateTime NewsTime
        {
            get { return Ticker.newsTime; }
            set { Ticker.newsTime = value; }
        }
        
        public static string NewsData
        {
            get { return Ticker.newsData; }
            set { Ticker.newsData = value; }
        }

        public static void UpdateTicker()
        {
            Ticker.NewsTime = DateTime.Now;
            Ticker.NewsData = Ticker.Check();
        }
        static string Check()
        {
            try
            {
                string str = "";

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.dsebd.org/");

                string html = (new StreamReader(wr.GetResponse().GetResponseStream())).ReadToEnd();

                HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();
                HD.LoadHtml(html);

                //var NoAltElements = HD.DocumentNode.SelectNodes("//marquee [(@id)]");

                var NoAltElements = HD.DocumentNode.Descendants("marquee");

                if (NoAltElements != null)
                {
                    foreach (HtmlNode HN in NoAltElements)
                    {
                        //HN.Attributes.Append("alt", "no alt image");
                        str += HN.InnerHtml;
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
