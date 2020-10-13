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

namespace Övning_14_2
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

        private void setBlueWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {                
                blueRectangle.Width = int.Parse(textBox1.Text);
            }
            catch
            {

            }
        }

        private void setRedWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                redRectangle.Width = int.Parse(textBox2.Text);
            }
            catch
            {

            }
        }

        private void setYellowWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                yellowRectangle.Width = int.Parse(textBox3.Text);
            }
            catch
            {

            }
        }

        private void slideBlueWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            blueRectangle.Width = blueSlider.Value;
        }

        private void slideRedWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            redRectangle.Width = redSlider.Value;
        }

        private void slideYellowWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            yellowRectangle.Width = yellowSlider.Value;
        }
    }
}
