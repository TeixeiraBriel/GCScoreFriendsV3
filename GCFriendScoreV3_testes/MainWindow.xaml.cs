using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GCFriendScoreV3_testes
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Scraper scraper;
        Login login;
        public MainWindow()
        { 
            InitializeComponent();
            scraper = new Scraper();
            login = new Login();
            DataContext = scraper;

            //feito em um bodao
            string[] Ids = new string[] { "1536302", "1536315" };
            scraper.ScrapeData(login.Logar(), Ids);
            scraper.Export();
        }
        
    }
}
