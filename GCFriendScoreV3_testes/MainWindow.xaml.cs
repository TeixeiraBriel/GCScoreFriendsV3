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
        public MainWindow()
        { 
            InitializeComponent();
            scraper = new Scraper();
            DataContext = scraper;

            //feito em um bodao
            scraper.ScrapeData("https://gamersclub.com.br/jogador/1536302");
        }
        
    }
}
