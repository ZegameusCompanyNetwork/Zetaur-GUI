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
            string dtStr = dt.ToString(@"dd/MM/yyyy");
            fecha_lb.Content = dtStr;
        }
        
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            hora_lb.Content = DateTime.Now.ToLongTimeString();
        }
        CultureInfo culture = CultureInfo.InvariantCulture;
        public double i;
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
            #region Temperatura
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
            #endregion
            #region Longitud
            else if (magnitud.Text == "Longitud")
            {
                if (MS_check.IsChecked == true)
                {
                    if (unidad.Text == "Kilómetros (km)")
                    {
                        double m = i * 1000, cm = m * 100, mm = cm * 10, micra = mm * 1000, nm = micra * 1000;
                        outtxt.Text = $"{i} Kilómetros son:\n\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(micra, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Metros (m)")
                    {
                        double km = i / 1000, cm = i * 100, mm = cm * 10, micra = mm * 1000, nm = micra * 1000;
                        outtxt.Text = $"{i} metros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(micra, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Centímetros (cm)")
                    {
                        double km = i / Math.Pow(10, 5), m = i / 100, mm = i * 10, micra = mm * 1000, nm = micra * 1000;
                        outtxt.Text = $"{i} centímetros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(micra, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Milímetros (mm)")
                    {
                        double km = i / Math.Pow(10, 6), m = i / 1000, cm = i / 10, micra = i * 1000, nm = micra * 1000;

                        outtxt.Text = $"{i} milímetros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(micra, 4):E} micrómetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Micrómteros (µm)")
                    {
                        double km = i / Math.Pow(10, 9), m = i / Math.Pow(10, 6), cm = i / Math.Pow(10, 4), mm = i / 1000, nm = i * 1000;
                        outtxt.Text = $"{i} micras son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Nanómetros (nm)")
                    {
                        double km = i / Math.Pow(10, 12), m = i / Math.Pow(10, 9), cm = i / Math.Pow(10, 7), mm = i / Math.Pow(10, 6), micra = i / 1000;
                        outtxt.Text = $"{i} nanómetros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n\n{Math.Round(mm, 4):E} milímetros.{Math.Round(micra, 4):E} micrómetros.\n";
                    }
                    else { MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else
                {

                }
            }
            #endregion
            else if (magnitud.Text == "Masa")
            {
                if (MS_check.IsChecked == true)
                {

                }
                else
                {

                }
            }
            else if (magnitud.Text == "Presión")
            {
                if (MS_check.IsChecked == true)
                {

                }
                else
                {

                }
            }
            else { MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public readonly string[] temps = new string[] { "Celsius (ºC)", "Farenheit (ºF)", "Kelvin (K)" };
        public readonly string[] long_ms = new string[] { "Kilómetros (km)", "Metros (m)", "Centímetros (cm)", "Milímetros (mm)", "Micrómetros (µm)", "Nanómetros (nm)" };
        public readonly string[] long_all = new string[] { "Kilómetros (km)", "Metros (m)", "Millas (Mi)", "Millas Náuticas (Nmi)", "Pulgadas (in)", "Yardas (Yd)", "Pies (ft)" };
        public readonly string[] masa = new string[] { };

        /// <summary>
        /// Comprobar y cambiar los objetos desplegados en el menú de unidades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Magnitud_DropDownClosed(object sender, EventArgs e)
        {
            if (magnitud.SelectedIndex == 0)//Temperaturas
            {
                unidad.Items.Clear();//Limpiamos lo que pueda haber en el ComboBox
                foreach (string s in temps)//Buscamos en el arreglo temps todos las strings y las añadimos al ComboBox
                {
                    unidad.Items.Add(s);
                }
                unidad.SelectedIndex = 0;//Selecionamos el primer objeto de la lista

            }
            else if (magnitud.SelectedIndex == 1)//Longitud
            {
                unidad.Items.Clear();
                if (MS_check.IsChecked == true) //Comprobamos si el CheckBox esta pulsado o no
                {

                    foreach (string s in long_ms)
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 1;
                }
                else
                {
                    foreach (string s in long_all)
                    {
                        unidad.Items.Add(s);
                    }
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
        /// <summary>
        /// Borramos el texto de salida del OutTextBox anterior al cambiar la entrada del TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inputtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            outtxt.Text = "";
        }
        /// <summary>
        /// Ejecuta este fragmento al presionar Enter en cuadro de texto de entrada de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inputtext_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }
        }
    }
}
