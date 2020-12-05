using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Zetaur_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            unidad.SelectedIndex = 0;
            hora_lb.Content = DateTime.Now.ToLongTimeString();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            DateTime dt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            string dtStr = dt.ToString(@"M/d/yyyy");
            fecha_lb.Content = dtStr;
        }
        public double i;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            hora_lb.Content = DateTime.Now.ToLongTimeString();
        }
        CultureInfo culture = CultureInfo.InvariantCulture;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputxt = inputtext.Text;

            try
            {
                i = double.Parse(Regex.Replace(inputxt, "[.,']", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }
            catch (Exception er) when (er.GetType() != typeof(FormatException))
            {

                MessageBox.Show($"El valor introducido no funciona:{er.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException er)
            {
                MessageBox.Show($"El valor introducido no es un número: {er.Message}", "Error en el formato", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //MessageBox.Show($"Has introducido el valor: {i}", "Valor introducido");
            if (magnitud.Text == "Temperatura")
            {
                if (unidad.Text == "Celsius (ºC)")
                {
                    double fahr = (i * 9 / 5) + 32, kel = i + 273.15;
                    outtxt.Text = $"{Math.Round(i, 4)} ºC son: \n{Math.Round(fahr, 4)} Grados Farenheit (ºF).\n{Math.Round(kel, 4)} Kelvins";
                }
                else if (unidad.Text == "Farenheit (ºF)")
                {
                    double cels = (i - 32) * 5 / 9, kel = (i - 32) * 5 / 9 + 273.15;
                    outtxt.Text = $"{Math.Round(i, 4)} ºF son:\n{Math.Round(cels, 4)} Grados Centigrados (ºC).\n{Math.Round(kel, 4)} Kelvins.";
                }
                else
                {
                    double cels = i - 273.15, fahr = (i - 273.15) * 5 / 9 + 32;
                    outtxt.Text = $"{Math.Round(i, 4)} Kelvins son:\n{Math.Round(cels, 4)} Grados Centigrados (ºC).\n{Math.Round(fahr, 4)} Grados Farenheit (ºF).";
                }
            }
            else if (magnitud.Text == "Longitud")
            {
                if (MS_check.IsChecked == true)
                {
                    if (unidad.Text == "Kilometros (km)")
                    {
                        double m=i*1000, cm= m*100, mm=cm*10, microm=mm*1000, nm=microm*1000;
                        outtxt.Text = $"{i} Kilómetros son:\n\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(microm, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Metros (m)")
                    {
                        double km = i / 1000, cm = i * 100, mm = cm * 10, microm = mm * 1000, nm = microm * 1000;
                        outtxt.Text = $"{i} metros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(microm, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Centímetros (cm)")
                    {

                    }
                    else if (unidad.Text == "Milímetros (mm)")
                    {

                    }
                    else if (unidad.Text == "Micrómteros (µm)")
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else if (magnitud.Text == "Masa")
            {
                if (MS_check.IsChecked == true)
                {

                }
                else
                {

                }
            }
            else
            {

            }

        }


        /// <summary>
        /// Comprobar y cambiar los objetos desplegados en el menú de unidades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magnitud_DropDownClosed(object sender, EventArgs e)
        {
            if (magnitud.SelectedIndex == 0)//Temperaturas
            {
                unidad.Items.Clear();
                string[] str = new string[] { "Celsius (ºC)", "Farenheit (ºF)", "Kelvin (K)" };
                foreach (string s in str)
                    unidad.Items.Add(s);
                unidad.SelectedIndex = 0;

            }
            else if (magnitud.SelectedIndex == 1)//Longitud
            {

                unidad.Items.Clear();
                if (MS_check.IsChecked == true)
                {
                    string[] str = new string[] { "Kilometros (km)", "Metros (m)", "Centímetros (cm)", "Milímetros (mm)", "Micrómetros (µm)", "Nanómetros (nm)" };
                    foreach (string s in str)
                    {
                        unidad.Items.Add(s);
                    }

                    unidad.SelectedIndex = 1;
                }
                else
                {
                    unidad.Items.Insert(0, "Kilometros (km)");
                    unidad.Items.Insert(1, "Metros (m)");
                    unidad.Items.Insert(2, "Millas (Mi)");
                    unidad.Items.Insert(3, "Millas Náuticas (Nmi)");
                    unidad.Items.Insert(4, "Pulgadas (in)");
                    unidad.Items.Insert(5, "Yardas (Yd)");
                    unidad.Items.Insert(6, "Pies (ft)");
                    unidad.SelectedIndex = 0;
                }
            }
            else if (magnitud.SelectedIndex == 2)//Masa
            {
                unidad.Items.Clear();

            }
            else//Presión
            {
                unidad.Items.Clear();

            }
        }
        /// <summary>
        /// Permite mover la ventanta clicando en cualquier control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void Inputtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            outtxt.Text = "";
        }

        private void inputtext_Enter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }
        }
    }
}
