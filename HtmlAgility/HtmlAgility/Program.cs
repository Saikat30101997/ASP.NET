using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HtmlAgility
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");
            var nodes = document.DocumentNode.SelectSingleNode("//div[@class='table-responsive inner-scroll']/table[contains(@class, " +
                "'table table-bordered background-white shares-table fixedHeader')]").ChildNodes;
         
            foreach (var node in nodes)
            {
                var id= node.SelectSingleNode("td[1]") == null ? "" : node.SelectSingleNode("td[1]").InnerText;
                
                var tradingcode = node.SelectSingleNode("td[2]") == null ? "" : node.SelectSingleNode("td[2]").InnerText;
       
                var LTP = node.SelectSingleNode("td[3]") == null ? "" : node.SelectSingleNode("td[3]").InnerText;
               
                var high = node.SelectSingleNode("td[4]") == null ? "" : node.SelectSingleNode("td[4]").InnerText;
               
                var Low = node.SelectSingleNode("td[5]") == null ? "" : node.SelectSingleNode("td[5]").InnerText;
              
                var Closep = node.SelectSingleNode("td[6]") == null ? "" : node.SelectSingleNode("td[6]").InnerText;
   
                var YCP = node.SelectSingleNode("td[7]") == null ? "" : node.SelectSingleNode("td[7]").InnerText;
               
                var CHANGE  = node.SelectSingleNode("td[8]") == null ? "" : node.SelectSingleNode("td[8]").InnerText;

                var TRADE = node.SelectSingleNode("td[9]") == null ? "" : node.SelectSingleNode("td[9]").InnerText;
              
             
                var Value = node.SelectSingleNode("td[10]") == null ? "" : node.SelectSingleNode("td[10]").InnerText;
              
                var Volume = node.SelectSingleNode("td[11]") == null ? "" : node.SelectSingleNode("td[11]").InnerText;

                //Regex regex = new Regex(@"/^[a - zA - Z]{ 3,}$/");
                //Match match = regex.Match(tradingcode);
                //if (match.Success)
                //{
                //    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", id,
                //    tradingcode, LTP, high, Low, Closep, YCP, CHANGE, TRADE, Value, Volume);
                //}

                // Console.WriteLine("{0} {1}",id,tradingcode);
                //if (id!=string.Empty && tradingcode!=string.Empty)
                //{
                //    Console.WriteLine("Id={0} TradingCode={1} LTP={2} High={3} Low={4} CLOsep={5} YCP={6} Change={7} Trade={8} Value={9} Volume{10}", id,tradingcode, LTP, high, Low, Closep, YCP, CHANGE, TRADE, Value, Volume);
                //}
                Console.WriteLine(tradingcode);
            //    Console.WriteLine(node.InnerText);
                
            }


        }

        }

        //public static void Main(string[] args)
        //{
        //    HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.dse.com.bd/latest_share_price_scroll_l.php");
        //        request.Method = "GET";
        //        request.ContentType = "text/html;charset=utf-8";

        //        using (var response = (HttpWebResponse)request.GetResponse())
        //        {
        //            using (var stream = response.GetResponseStream())
        //            {
        //                doc.Load(stream, Encoding.GetEncoding("utf-8"));
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    //Works fine
        //    HtmlNode tablebody = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/section/div/div[3]/div[1]/div[2]/div[1]/div[2]");
        //    foreach (HtmlNode tr in tablebody.SelectNodes("./tr"))
        //    {
        //        Console.WriteLine("\nTableRow: ");
        //        foreach (HtmlNode td in tr.SelectNodes("./td"))
        //        {
        //            if (td.GetAttributeValue("class", "null") == "col1")
        //            {
        //                Console.Write("\t " + td.InnerText);
        //            }
        //            else
        //            {
        //                HtmlNode temp = td.SelectSingleNode(".//div[@class='catel']/a");
        //                if (temp != null)
        //                {
        //                    Console.Write("\t " + temp.GetAttributeValue("href", "no url"));
        //                }
        //            }


        //        }
        //    }
        //    Console.ReadKey();
        //}

        //foreach (HtmlNode node in mainNode.SelectNodes("//tr"))
        //        {
        //            var latestPrice = node.SelectSingleNode("td[2]") == null ? "" : node.SelectSingleNode("td[2]").InnerText;
        //var highestPrice = node.SelectSingleNode("td[3]") == null ? "" : node.SelectSingleNode("td[3]").InnerText;
        //var closingPrice = node.SelectSingleNode("td[4]") == null ? "" : node.SelectSingleNode("td[4]").InnerText;
        //var yesterdayPrice = node.SelectSingleNode("td[5]") == null ? "" : node.SelectSingleNode("td[5]").InnerText;
        //var change = node.SelectSingleNode("td[6]") == null ? "" : node.SelectSingleNode("td[6]").InnerText;
        //var trade = node.SelectSingleNode("td[7]") == null ? "" : node.SelectSingleNode("td[7]").InnerText;
        //var value = node.SelectSingleNode("td[8]") == null ? "" : node.SelectSingleNode("td[8]").InnerText;
        //var volume = node.SelectSingleNode("td[9]") == null ? "" : node.SelectSingleNode("td[9]").InnerText;

        //Regex regex = new Regex(@"^[a - zA - Z]{ 3,}$/");

        //Match match = regex.Match(latestPrice);

        //            if (match.Success) { Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", latestPrice, highestPrice, closingPrice, yesterdayPrice, change, trade, value, volume); }
        //            continue;
                    
        //
              // }
   // }
}
