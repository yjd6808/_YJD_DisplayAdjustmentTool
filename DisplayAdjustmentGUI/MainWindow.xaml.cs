using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using WindowsDisplayAPI;

namespace DisplayAdjustmentGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _loaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnClosing(object? sender, CancelEventArgs e)
        {
            if (!App.CmdSuccess)
                App.InitializeRamp();
        }

       

        private void SliderValue_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_loaded)
            {
                App.AdjustRamp(_displayComboBox.SelectedIndex, 
                    _brightnessSlider.Value, 
                    _contrastSlider.Value,
                    _gammaSlider.Value);

                _brightnessLabel.Content = $"{_brightnessSlider.Value:0.00}";
                _contrastLabel.Content = $"{_contrastSlider.Value:0.00}";
                _gammaLabel.Content = $"{_gammaSlider.Value:0.00}";
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < App.Displays.Length; i++)
                _displayComboBox.Items.Add(App.Displays[i].DisplayName);

            _displayComboBox.SelectedIndex = 0;
            _loaded = true;
        }

        private void _saveGammaRampButtn_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void _initBtn_Click(object sender, RoutedEventArgs e)
        {
            App.InitializeRamp();
        }
    }
}
