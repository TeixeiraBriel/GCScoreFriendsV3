using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ScrapeData(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            //ta parando na tela de login
            var dados = doc.DocumentNode.SelectNodes("//*[@class='btn-create-account']");
            
            

        }
    }
}
