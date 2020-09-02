using CsvHelper;
using HtmlAgilityPack;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GCFriendScoreV3_testes
{
    public class Scraper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public void ScrapeData(IWebDriver driver, string[] Ids)
        {
            int n = 0;
            var doc = new HtmlDocument();
            foreach (var Id in Ids)
            {
                driver.Navigate().GoToUrl("https://gamersclub.com.br/jogador/" + Id);
                Thread.Sleep(10000);

                doc.LoadHtml(driver.PageSource);
                var dados = doc.DocumentNode.SelectNodes("//*[@class='StatsBoxPlayerInfo']");

                while (dados == null && n < 15)
                {
                    doc.LoadHtml(driver.PageSource);
                    dados = doc.DocumentNode.SelectNodes("//*[@class='StatsBoxPlayerInfo']");
                    n++;
                    Thread.Sleep(500);
                }

                foreach (var dado in dados)
                {
                    var TituloSite = HttpUtility.HtmlDecode(dado.SelectSingleNode(".//div[@class='StatsBoxPlayerInfoItem__name']").InnerText);
                    var DescricaoSite = HttpUtility.HtmlDecode(dado.SelectSingleNode(".//div[@class='StatsBoxPlayerInfoItem__value']").InnerText);

                    _entries.Add(new EntryModel { TituloEntry = TituloSite, DescricaoEntry = DescricaoSite });
                }
            }

            driver.Quit();
        }

        public void Export()
        {
            using (TextWriter tw = File.CreateText("SampleData.csv"))
            
                using (var cw = new CsvWriter(tw, CultureInfo.InvariantCulture))
                {
                    foreach (var entrie in Entries)
                    {
                        cw.WriteRecord(entrie);
                        cw.NextRecord();
                    }
                }
        }
    }
}
