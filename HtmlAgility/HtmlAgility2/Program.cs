using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HtmlAgility2
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");

            var nodes = document.DocumentNode.SelectNodes("//div[@class='table-responsive inner-scroll']/table[contains(@class, " +
                "'table table-bordered background-white shares-table fixedHeader')]");

            var item = nodes.FirstOrDefault().SelectSingleNode("//span/span").InnerText;
            Console.WriteLine(item);


        }
    }
}
