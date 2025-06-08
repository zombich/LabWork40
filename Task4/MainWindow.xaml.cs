using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] Tags = ["enemy", "hero", "treasure"];
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos = Mouse.GetPosition(CirclesCanvas);

            var random = new Random();
            var height = random.Next(10, 150);
            var width = random.Next(10, 150);

            byte r = (byte)random.Next(255);
            byte g = (byte)random.Next(255);
            byte b = (byte)random.Next(255);

            Color color = Color.FromRgb(r, g, b);

            SolidColorBrush brush = new(color);
            Ellipse ellipse = new()
            {
                Fill = brush,
                Width = width,
                Height = height,
                Tag = Tags[random.Next(Tags.Length)],
            };
            ellipse.MouseDown += Ellipse_MouseDown;

            Canvas.SetTop(ellipse, pos.Y - height / 2);
            Canvas.SetLeft(ellipse, pos.X - width / 2);

            CirclesCanvas.Children.Add(ellipse);
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as Ellipse).Tag.ToString());
        }
    }
}