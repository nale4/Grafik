using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            LoadChart();
        }

        private void LoadChart()
        {
            // Создаем новую диаграмму
            Chart chart = new Chart();

            // Создаем новую серию данных (линию)
            LineSeries lineSeries = new LineSeries();
            lineSeries.Title = "Пример графика";

            // Добавляем точки на графике (используем double вместо int)
            lineSeries.ItemsSource = new[]
            {
                new KeyValuePair<double, double>(1, 100),
                new KeyValuePair<double, double>(2, 150),
                new KeyValuePair<double, double>(3, 120),
                new KeyValuePair<double, double>(4, 200),
                new KeyValuePair<double, double>(5, 180)
            };

            // Добавляем серию к диаграмме
            chart.Series.Add(lineSeries);

            // Создаем ось X
            LinearAxis horizontalAxis = new LinearAxis();
            horizontalAxis.Orientation = AxisOrientation.X;
            horizontalAxis.Title = "Ось X";
            chart.Axes.Add(horizontalAxis);

            // Создаем ось Y
            LinearAxis verticalAxis = new LinearAxis();
            verticalAxis.Orientation = AxisOrientation.Y;
            verticalAxis.Title = "Ось Y";
            chart.Axes.Add(verticalAxis);

            // Добавляем диаграмму в содержимое окна
            mainGrid.Children.Add(chart);
        }
    }
}
