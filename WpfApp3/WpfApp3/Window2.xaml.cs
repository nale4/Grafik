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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public SeriesCollection _seriesCollection { get; set; }
        public ChartValues<double> Val { get; set; }
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set { _seriesCollection = value; }
        }
        public Window2()
        {
            InitializeComponent();

            startgraf();

        }

        async private void startgraf()
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                var temp = db.Temperature.ToList();
                var count = new ChartValues<double>();

                foreach (var item in temp)
                {
                    count.Add((double)item.count);
                }
                _seriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "temperature",
                        Values = count
                    },
                };
                DataContext = this;
            }
                
            Thread sg = new Thread(() => showgraf());

            Task ts_new_graf = new Task(() => sg.Start());
            ts_new_graf.Start();
        }

        public void showgraf()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                while(true)
                {
                    var temp = db.Temperature.ToList();
                    var count = new ChartValues<double>();

                    foreach (var item in temp)
                    {
                        count.Add((double)item.count);
                    }
                    Dispatcher.Invoke(() =>
                    {
                        (_seriesCollection[0] as LineSeries).Values = count;
                    });
                    Thread.Sleep(1000);
                }
            }
            
        }
    }
}
