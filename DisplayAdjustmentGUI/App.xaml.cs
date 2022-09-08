using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WindowsDisplayAPI;

namespace DisplayAdjustmentGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Display[] Displays;
        public static DisplayGammaRamp[] DisplaysGammaRamps;
        public static bool CmdSuccess = false;

        protected override void OnStartup(StartupEventArgs e)
        {
            Displays = Display.GetDisplays().ToArray();
            DisplaysGammaRamps = new DisplayGammaRamp[Displays.Length];

            for (int i = 0; i < Displays.Length; i++)
                DisplaysGammaRamps[i] = Displays[i].GammaRamp;

            if (e.Args.Length >= 4)
            {
                int.TryParse(e.Args[0], out int index);
                double.TryParse(e.Args[1], out double brightness);
                double.TryParse(e.Args[2], out double contrast);
                double.TryParse(e.Args[3], out double gamma);

                try
                {
                    AdjustRamp(index, brightness, contrast, gamma);
                    CmdSuccess = true;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

                Current.Shutdown(0);
                return;
            }

            base.OnStartup(e);
        }

        public static void InitializeRamp(int displayIndex)
        {
            if (displayIndex < 0 || displayIndex >= Displays.Length)
                throw new IndexOutOfRangeException();

            Displays[displayIndex].GammaRamp = DisplaysGammaRamps[displayIndex];
        }

        public static void InitializeRamp()
        {
            for (int i = 0; i < Displays.Length; i++)
                InitializeRamp(i);
        }

        public static void AdjustRamp(int displayIndex, double brightness, double contrast, double gamma)
        {
            if (displayIndex < 0 || displayIndex >= Displays.Length)
                throw new IndexOutOfRangeException();

            if (brightness < 0 || brightness > 100 ||
                contrast < 0 || contrast > 100 ||
                gamma < 0 || gamma > 100)
                throw new Exception("밝기, 대비, 감마 수치는 0 ~ 100사이값만 전달가능합니다.");

            double brightnessDouble = brightness / 100.0;
            double contrastDouble = contrast / 100.0;
            double gammaDouble = gamma / 100.0 * 2.4 + 0.4;

            Displays[displayIndex].GammaRamp = new DisplayGammaRamp(brightnessDouble, contrastDouble, gammaDouble);
        }
    }
}
