using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double width, height, woodLength, glassArea;
            width = double.Parse(widthInput.Text);
            height = double.Parse(heightInput.Text);
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height) * 3.25;
            double quant = double.Parse(quantityNum.Text);
            string tint = ((ComboBoxItem)tintDropDown.SelectedItem).Content.ToString(); ;
            output.Text = $"Quantity: {quant}\n" +
                $"Tint: {tint}\n" +
                $"Length: {woodLength}\n" +
                $"Area: {glassArea}";
        }

        private void widthInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            string widthString = widthInput.Text;
            if (!int.TryParse(widthString, out int width))
            {
                widthInput.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                widthWarning.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                widthWarning.Text = "Width must be a number.";
            }
            else
            {
                widthInput.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
                widthWarning.Text = "";
            }
        }

        private void heightInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            string heightString = widthInput.Text;
            if (!int.TryParse(heightString, out int width))
            {
                heightInput.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                widthInput.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                heightWarning.Text = "Height must be a number.";
            }
            else
            {
                heightInput.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
                heightWarning.Text = "";
            }
        }

        private void quantitySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            //Slider slider = sender as Slider;
            //if (slider != null)
            //{
                //quantityNum.Text = quantitySlider.Value.ToString();
            //}
            quantityNum.Text = quantitySlider.Value.ToString();
        }
    }
}
