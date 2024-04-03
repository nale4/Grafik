using System.Configuration;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread th1 = new Thread(() => addCount());
            try
            {
                Task task = new Task (() => th1.Start());
                task.Start ();
            }
            catch
            {
                MessageBox.Show("ошибка подключения");
            }
        }

        public void addCount()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                while(true)
                {
                    List<Temperature> temp = db.Temperature.ToList();

                    Dispatcher.Invoke(() =>
                    {
                        data.ItemsSource = temp;
                    });

                    Thread.Sleep(1000);
                }
            }
        }
        

        async private void Button_Click_New_Window(object sender, RoutedEventArgs e)
        {
            Thread th2 = new Thread(() => newWindow());

            Task ts_new_windo = new Task(() => th2.Start());
            ts_new_windo.Start();
        }

        public void newWindow()
        {
            
            Dispatcher.Invoke(() => {
                Window2 win1 = new Window2();
                win1.Show(); 
            });
            
        }
    }
}