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
using System.Windows.Threading;

namespace WpfStand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public string selBlockType = "";
        public string selBlockMaker = "";
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            string day = DateTime.Now.ToString("dddd");
            lblTime.Content = DateTime.Now.ToString("F") + ", " + day;
        }



        private void listboxZakazchik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelBlockMaker(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvItem = (TreeViewItem)sender;
            TreeViewItem BlockType = (TreeViewItem)tvItem.Parent;
            selBlockType = BlockType.Header.ToString();
            selBlockMaker = tvItem.Header.ToString();
            if (selBlockMaker == "производитель неизвестен")
            {
                textboxStatus.Text = "Оператор выбрал: " + selBlockType + " производитель неизвестен";
            }
            else
            {
                textboxStatus.Text = "Оператор выбрал: " + selBlockType + " производства " + selBlockMaker;
            }
            
        }

        private void buttonRun_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Value += 5.25;
        }
    }
}
