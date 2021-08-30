using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IStockPriceService _stockPriceService;
        public Worker(ILogger<Worker> logger, IStockPriceService stockPriceService)
        {
            _logger = logger;
            _stockPriceService = stockPriceService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");
                var nodes = document.DocumentNode.SelectSingleNode("//div[@class='table-responsive inner-scroll']/table[contains(@class, " +
                    "'table table-bordered background-white shares-table fixedHeader')]").ChildNodes;

                foreach (var node in nodes)
                {
                    var id = node.SelectSingleNode("td[1]") == null ? "" : node.SelectSingleNode("td[1]").InnerText;

                    var tradingcode = node.SelectSingleNode("td[2]") == null ? "" : node.SelectSingleNode("td[2]").InnerText;

                    var LTP = node.SelectSingleNode("td[3]") == null ? "" : node.SelectSingleNode("td[3]").InnerText;

                    var high = node.SelectSingleNode("td[4]") == null ? "" : node.SelectSingleNode("td[4]").InnerText;

                    var Low = node.SelectSingleNode("td[5]") == null ? "" : node.SelectSingleNode("td[5]").InnerText;

                    var Closep = node.SelectSingleNode("td[6]") == null ? "" : node.SelectSingleNode("td[6]").InnerText;

                    var YCP = node.SelectSingleNode("td[7]") == null ? "" : node.SelectSingleNode("td[7]").InnerText;

                    var CHANGE = node.SelectSingleNode("td[8]") == null ? "" : node.SelectSingleNode("td[8]").InnerText;

                    var TRADE = node.SelectSingleNode("td[9]") == null ? "" : node.SelectSingleNode("td[9]").InnerText;


                    var Value = node.SelectSingleNode("td[10]") == null ? "" : node.SelectSingleNode("td[10]").InnerText;

                    var Volume = node.SelectSingleNode("td[11]") == null ? "" : node.SelectSingleNode("td[11]").InnerText;
                    var stockPrice = new StockPrice()
                    {
                        LastTradingPrice = Convert.ToDouble(LTP),
                        High = Convert.ToDouble(high),
                        Low = Convert.ToDouble(Low),
                        ClosePrice=Convert.ToDouble(Closep),
                        YesterdayClosePrice = Convert.ToDouble(YCP),
                        Change = Convert.ToDouble(CHANGE),
                        Trade = Convert.ToDouble(TRADE),
                        Value = Convert.ToDouble(Value),
                        Volume = Convert.ToInt32(Volume)


                    };
                    _stockPriceService.Create(stockPrice);
                }
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken); //time duration koto time por por eta run hobe 
            }
        }
    }
}
