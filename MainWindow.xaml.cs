using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Defaults;
using System.Windows.Threading;

namespace PPMAC_HMI
{
 public partial class MainWindow : Window
 {
 ChartValues<ObservableValue> PosValues;
 DispatcherTimer timer;
 PPMAC ppmac;

 public MainWindow()
 {
 InitializeComponent();
 ppmac = new PPMAC();
 ppmac.Connect("192.168.0.200");
 InitChart();
 }

 void InitChart()
 {
 PosValues = new ChartValues<ObservableValue>();
 Chart.Series[0].Values = PosValues;

 timer = new DispatcherTimer();
 timer.Interval = TimeSpan.FromMilliseconds(200);
 timer.Tick += (s,e)=>
 {
 double pos = GetPos();
 PosValues.Add(new ObservableValue(pos));
 if (PosValues.Count > 100) PosValues.RemoveAt(0);
 };
 timer.Start();
 }

 double GetPos()
 {
 ppmac.Write("Motor[1].ActPos");
 return Convert.ToDouble(ppmac.Read());
 }

 private void Apply_Click(object sender, RoutedEventArgs e)
 {
 ppmac.Write($"StepAngle={txtStepAngle.Text}");
 ppmac.Write($"Backlash={txtBacklash.Text}");
 ppmac.Write($"StepCount={txtStepCount.Text}");
 ppmac.Write($"LapCount={txtLapCount.Text}");
 ppmac.Write($"Speed={txtSpeed.Text}");
 }

 private void Start_Click(object sender, RoutedEventArgs e)
 {
 ppmac.Write("StartFlag=1");
 }

 private void Stop_Click(object sender, RoutedEventArgs e)
 {
 ppmac.Write("StopFlag=1");
 }
 }
}
