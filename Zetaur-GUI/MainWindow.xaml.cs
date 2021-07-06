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
using Zetaur_GUI;

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
        }
        public static readonly string[] temps = new string[] { "Celsius (ºC)", "Fahrenheit (ºF)", "Kelvin (K)" };
        public static readonly string[] a_temps = new string[] { "Celsius (ºC)", "Fahrenheit (ºF)", "Kelvin (K)", "Rankine (ºR)", "Réaumur (ºRe)" };
        public static readonly string[] long_ms = new string[] { "Kilómetros (km)", "Metros (m)", "Centímetros (cm)", "Milímetros (mm)", "Micrómetros (µm)", "Nanómetros (nm)" };
        public static readonly string[] long_all = new string[] { "Kilómetros (km)", "Metros (m)", "Millas (Mi)", "Millas Náuticas (Nmi)", "Pulgadas (in)", "Yardas (Yd)", "Pies (ft)" };
        /// <summary>
        /// <list type="table">
        /// <listheader>
        ///     <term>Número</term>
        ///     <description>Unidad</description>
        /// </listheader>
        /// <item>
        ///     <term>0</term>
        ///     <description>Kilogramos</description>
        /// </item>
        /// <item>
        ///     <term>1</term>
        ///     <description>Gramos</description>
        /// </item>
        /// <item>
        ///     <term>2</term>
        ///     <description>Tonelada Métrica</description>
        /// </item>
        /// <item>
        ///     <term>3</term>
        ///     <description>Tonelada Corta (US t)</description>
        /// </item>
        /// <item>
        ///     <term>4</term>
        ///     <description>Tonelada Larga (UK t)</description>
        /// </item>
        /// <item>
        ///     <term>5</term>
        ///     <description>Onzas</description>
        /// </item>
        /// <item>
        ///     <term>6</term>
        ///     <description>Libras</description>
        /// </item>
        /// <item>
        ///     <term>7</term>
        ///     <description>Stones</description>
        /// </item>
        /// </list>
        /// </summary>
        public static readonly string[] masa = new string[] { "Kilogramos (Kg)", "Gramos (g)", "Toneladas (t)", "Tonelada Corta (US t)", "Tonelada larga (UK t)", "Onzas (Oz)", "Libras (lb)", "Stones (st)" };
        public static readonly string[] ms_masa = new string[] { "Toneladas (t)", "Kilogramos (Kg)", "Gramos (g)", "Miligramos (mg)" };
        /// <summary>
        /// <list type="table">
        /// <listheader>
        ///     <term>Número</term>
        ///     <description>Unidad</description>
        /// </listheader>
        /// <item>
        ///     <term>0</term>
        ///     <description>Atmósferas (atm)</description>
        /// </item>
        /// <item>
        ///     <term>1</term>
        ///     <description>Bares</description>
        /// </item>
        /// <item>
        ///     <term>2</term>
        ///     <description>Milibares</description>
        /// </item>
        /// <item>
        ///     <term>3</term>
        ///     <description>PSI</description>
        /// </item>
        /// <item>
        ///     <term>4</term>
        ///     <description>Pascales</description>
        /// </item>
        /// <item>
        ///     <term>5</term>
        ///     <description>Hectopascales</description>
        /// </item>
        /// <item>
        ///     <term>6</term>
        ///     <description>Mílimetros de Mercurio</description>
        /// </item>
        /// <item>
        ///     <term>7</term>
        ///     <description>Torr</description>
        /// </item>
        /// <item>
        ///     <term>8</term>
        ///     <description>Kp/cm^2</description>
        /// </item>
        /// </list>
        /// </summary>
        public static readonly string[] presion = new string[] { "Atmósferas (atm)", "Bares (bar)", "Milibares (mbar)", "Libra por pulgada cuadrada (PSI)", "Pascales (Pa)", "Hectopascales (hPa)", "Milímetros de Mercurio (mmHg)", "Torr (torr)", "Kilopondio por centímetro cuadrado" };
        /// <summary>
        /// 0 = Pascal, 1 = Kilopascal, 2 = Hectopascal, 3 = Megapascal
        /// </summary>
        public static readonly string[] ms_presion = new string[] { "Pascal (Pa)", "Kilopascal (kPa)", "Hectopascal (hPa)", "Megapascal (MPa)" };

        public double i;//Entrada numerica
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputxt = inputtext.Text;
            //Convertimos la entrada de tipo cadena a double (si se puede)
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
                if (MS_check.IsChecked == true)
                {
                    if (unidad.Text == a_temps[0])
                    {
                        double[] o = Temp.Celsius(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{Math.Round(i, 4)} {a_temps[0]} son: \n{Math.Round(o[0], 4)} {a_temps[1]}.\n{Math.Round(o[1], 4)} {a_temps[2]}." +
                            $"\n{Math.Round(o[2], 4)} {a_temps[3]}.\n{Math.Round(o[3], 4)} {a_temps[4]}.\n";
                    }
                    else if (unidad.Text == a_temps[1])
                    {
                        double[] o = Temp.Fahr(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{Math.Round(i, 4)} {a_temps[1]} son:\n{Math.Round(o[0], 4)} {a_temps[0]}.\n{Math.Round(o[1], 4)} {a_temps[2]}." +
                            $"\n{Math.Round(o[2],4)} {a_temps[3]}.\n{Math.Round(o[3],4)} {a_temps[4]}";
                    }
                    else if (unidad.Text == a_temps[2])
                    {
                        double[] o = Temp.Kelvin(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{Math.Round(i, 4)} {a_temps[2]} son:\n{Math.Round(o[0], 4)} {a_temps[0]}.\n{Math.Round(o[1], 4)} {a_temps[1]}." +
                            $"\n{Math.Round(o[2], 4)} {a_temps[3]}.\n{Math.Round(o[3], 4)} {a_temps[4]}";
                    }
                    else if (unidad.Text == a_temps[3])
                    {
                        double[] o = Temp.Rankine(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{Math.Round(i, 4)} {a_temps[3]} son:\n{Math.Round(o[0], 4)} {a_temps[0]}.\n{Math.Round(o[1], 4)} {a_temps[1]}." +
                            $"\n{Math.Round(o[2], 4)} {a_temps[2]}.\n{Math.Round(o[3], 4)} {a_temps[4]}";
                    }
                    else if (unidad.Text == a_temps[4])
                    {
                        double[] o = Temp.Reaumur(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{Math.Round(i, 4)} {a_temps[4]} son:\n{Math.Round(o[0], 4)} {a_temps[0]}.\n{Math.Round(o[1], 4)} {a_temps[1]}." +
                            $"\n{Math.Round(o[2], 4)} {a_temps[2]}.\n{Math.Round(o[3], 4)} {a_temps[3]}";
                    }
                    else { MessageBox.Show("Esto no debería aparecerte", "Error al seleccionar Unidad",MessageBoxButton.OK,MessageBoxImage.Error); }
                }
                else if (MS_check.IsChecked == false)
                {
                    if (unidad.Text == temps[0])
                    {
                        double[] o = Temp.Celsius(i);
                        string[] s = new string[4];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{Math.Round(i, 4)} ºC son: \n{Math.Round(o[1], 4)} {a_temps[1]}.\n{Math.Round(o[2], 4)} {a_temps[2]}.";
                    }
                    else if (unidad.Text == temps[1])
                    {
                        double cels = (i - 32) * 5 / 9, kel = (i - 32) * 5 / 9 + 273.15;
                        outtxt.Text = $"{Math.Round(i, 4)} ºF son:\n{Math.Round(cels, 4)} Grados Centigrados (ºC).\n{Math.Round(kel, 4)} Kelvins.";
                    }
                    else if (unidad.Text == temps[2])
                    {
                        double cels = i - 273.15, fahr = (i - 273.15) * 5 / 9 + 32;
                        outtxt.Text = $"{Math.Round(i, 4)} Kelvins son:\n{Math.Round(cels, 4)} Grados Centigrados (ºC).\n{Math.Round(fahr, 4)} Grados Farenheit (ºF).";
                    }
                    else { MessageBox.Show("Esto no debería aparecerte", "Error al seleccionar Unidad", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else { MessageBox.Show("Esto no debería aparecerte", "Error en la ejecución del programa", MessageBoxButton.OK, MessageBoxImage.Error); }
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
                    else if (unidad.Text == "Micrómetros (µm)")
                    {
                        double km = i / Math.Pow(10, 9), m = i / Math.Pow(10, 6), cm = i / Math.Pow(10, 4), mm = i / 1000, nm = i * 1000;
                        outtxt.Text = $"{i} micras son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(nm, 4):E} nanómetros.\n";
                    }
                    else if (unidad.Text == "Nanómetros (nm)")
                    {
                        double km = i / Math.Pow(10, 12), m = i / Math.Pow(10, 9), cm = i / Math.Pow(10, 7), mm = i / Math.Pow(10, 6), micra = i / 1000;
                        outtxt.Text = $"{i} nanómetros son:\n\n{Math.Round(km, 4):E} kilómetros.\n{Math.Round(m, 4):E} metros.\n{Math.Round(cm, 4):E} centímetros.\n{Math.Round(mm, 4):E} milímetros.\n{Math.Round(micra, 4):E} micrómetros.\n";
                    }
                    else { MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else if (MS_check.IsChecked == false)
                {
                    if (unidad.Text == "Kilómetros (km)")
                    {
                        double m = i * 1000, mi = i / 1.609, nmi = i / 1.852, inc = i * 39370, yd = m * 1093.613, ft = 3.281;
                        outtxt.Text = $"{i} Kilómetros son:\n{Math.Round(m, 4):E} metros.\n{mi} Millas.\n{nmi} Millas Náuticas.\n{inc} Pulgadas.\n{yd} Yardas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Metros (m)")
                    {
                        double km = i / 1000, mi = km / 1.609, nmi = km / 1.852, inc = i * 39.97, yd = km * 1093.613, ft = i * 3.281;
                        outtxt.Text = $"{i} metros son:\n{km} Kilómetros.\n{mi} Millas.\n{nmi} Millas Náuticas.\n{inc} Pulgadas.\n{yd} Yardas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Millas (Mi)")
                    {
                        double m = i * 1609, km = i * 1.609, inc = i * 63360, nmi = i / 1.151, yd = i * 1760, ft = i * 5280;
                        outtxt.Text = $"{i} Millas son:\n{m} metros.\n{km} Kilómetros.\n{nmi} Millas Náuticas.\n{inc} Pulgadas.\n{yd} Yardas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Millas Náuticas (Nmi)")
                    {
                        double m = i * 1852, km = i * 1.852, inc = i * 72913, mi = i * 1.151, yd = i * 2025.37, ft = i * 6076.12;
                        outtxt.Text = $"{i} Millas Náuticas son:\n{m} metros.\n{km} Kilómetros.\n{mi} Millas.\n{inc} Pulgadas.\n{yd} Yardas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Pulgadas (in)")
                    {
                        double m = i / 39.97, km = i / 39970, mi = i / 63360, nmi = i / 72913, yd = 36, ft = i / 12;
                        outtxt.Text = $"{i} Pulgads son:\n{m} metros.\n{km} Kilómetros.\n{mi} Millas.\n{nmi} Millas Náuticas.\n{yd} Yardas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Yardas (Yd)")
                    {
                        double m = i / 1.094, km = m / 1000, mi = i / 1760, nmi = i / 2025, inc = i * 36, ft = i * 3;
                        outtxt.Text = $"{i} Yardas son:\n{m} metros.\n{km} Kilómetros.\n{mi} Millas.\n{nmi} Millas Náuticas.\n{inc} Pulgadas.\n{ft} Pies.";
                    }
                    else if (unidad.Text == "Pies(ft)")
                    {
                        double m = i / 3.281, km = m / 1000, mi = i / 5280, nmi = i / 6076, inc = i * 12, yd = i / 3;
                        outtxt.Text = $"{i} Pies son:\n{m} metros.\n{km} Kilómetros.\n{mi} Millas.\n{nmi} Millas Náuticas.\n{inc} Pulgadas.\n{yd} Yardas.";
                    }
                    else
                    {
                        MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            #endregion
            #region Masa
            else if (magnitud.Text == "Masa")
            {
                if (MS_check.IsChecked == true)
                {
                    if (unidad.Text == ms_masa[0])//Toneladas
                    {
                        double kg = i * 1000, g = i * 1000, mg = g * 1000;
                        outtxt.Text = $"{i} toneladas son:\n{kg} Kilogramos.\n{g} Gramos.\n{mg} Miligramos.";
                    }
                    else if (unidad.Text == ms_masa[1])//Kilogramos
                    {
                        double T = i / 1000, g = i * 1000, mg = g * 1000;
                        outtxt.Text = $"{i} kilogramos son:\n{T} toneladas.\n{g} Gramos.\n{mg} Miligramos.";
                    }
                    else if (unidad.Text == ms_masa[2])//Gramos
                    {
                        double kg = i / 1000, T = kg / 1000, mg = i * 1000;
                        outtxt.Text = $"{i} Gramos son:\n{T} toneladas.\n{kg} Kilogramos.\n{mg} Miligramos.";
                    }
                    else if (unidad.Text == ms_masa[3])//Miligramos
                    {
                        double g = i / 1000, kg = g / 1000, T = i / 1000;
                        outtxt.Text = $"{i} miligramos son:\n{T} toneladas.\n{kg} Kilogramos.\n{g} Gramos.";
                    }
                    else
                    {
                        MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (MS_check.IsChecked == false)
                {

                    if (unidad.Text == masa[0])//Kilogramos
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[1])//gramos
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[2])//Toneladas Métricas
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";

                    }
                    else if (unidad.Text == masa[3])//Tonelada Corta (US t)
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[4])//Tonelada Larga (UK t)
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[5])//Onzas (Oz)
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[6])//Libras (lb)
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else if (unidad.Text == masa[7])//Stones (st)
                    {
                        double g = i * 1000, T = i / 1000, UsT = i / 907.185, UkT = i / 1016, Oz = i * 32.274, Lb = i * 2.20462, St = i / 6.35;
                        outtxt.Text = $"{i} {masa[0]} son:\n{g} {masa[1]}.\n{T} {masa[2]}, {UsT} {masa[3]} o {UkT} {masa[4]}.\n{Oz} {masa[5]}.\n{Lb} {masa[6]}.\n{St} {masa[7]}";
                    }
                    else
                    {
                        MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            #endregion
            #region Presión
            else if (magnitud.Text == "Presión")
            {
                //Comprobar el Checkbox de unidades
                if (MS_check.IsChecked == true)
                {
                    if (unidad.Text == ms_presion[0])//Pascal
                    {
                        double kp = i / 1000, hp = i / 100, Mp = kp / 1000;
                        outtxt.Text = $"{i} {ms_presion[0]} son\n{hp} {ms_presion[2]}.\n{kp} {ms_presion[1]}.\n{Mp} {ms_presion[3]}";
                    }
                    else if (unidad.Text == ms_presion[1])//Kilopascal
                    {
                        double kp = i / 1000, hp = i / 100, Mp = kp / 1000;
                        outtxt.Text = $"{i} {ms_presion[0]} son\n{hp} {ms_presion[2]}.\n{kp} {ms_presion[1]}.\n{Mp} {ms_presion[3]}";
                    }
                    else if (unidad.Text == ms_presion[2])//Hectopascal
                    {
                        double kp = i / 1000, hp = i / 100, Mp = kp / 1000;
                        outtxt.Text = $"{i} {ms_presion[0]} son\n{hp} {ms_presion[2]}.\n{kp} {ms_presion[1]}.\n{Mp} {ms_presion[3]}";
                    }
                    else if (unidad.Text == ms_presion[3])//Megapascal
                    {
                        double pa = i * 1000000, kp = i * 1000, hp = kp * 10;
                        outtxt.Text = $"{i} {ms_presion[3]} son\n{pa} {ms_presion[0]}.\n{kp} {ms_presion[1]}.\n{hp} {ms_presion[2]}";
                    }
                    else
                    {
                        //Esto solo esta aquí por si algo falla.
                        MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                else if (MS_check.IsChecked == false)
                {
                    if (unidad.Text == presion[0])
                    {
                        double[] o = Conversor.Atm(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }
                        outtxt.Text = $"{i} {presion[0]} son:\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}.\n{s[3]} {presion[3]}.\n{s[4]} {presion[4]}.\n{s[5]} {presion[5]}.\n{s[6]} {presion[6]}.\n{s[7]} {presion[7]}.\n{s[8]} {presion[8]}.";
                    }
                    else if (unidad.Text == presion[1])
                    {
                        double[] o = Conversor.Bar(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                    }
                    else if (unidad.Text == presion[2])
                    {
                        double[] o = Conversor.Mbar(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[3])
                    {
                        double[] o = Conversor.Psi(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[4])
                    {
                        double[] o = Conversor.Pa(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[5])
                    {
                        double[] o = Conversor.Hpa(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[6])
                    {
                        double[] o = Conversor.Mmhg(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[7])
                    {
                        double[] o = Conversor.Torr(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else if (unidad.Text == presion[8])//kilopondio /cm^2
                    {
                        double[] o = Conversor.Kpcm(i);
                        string[] s = new string[8];
                        for (int i = 0; i < o.Length; i++)
                        {
                            s[i] = $"{o[i]}";
                        }

                        outtxt.Text = $"{i} {presion[8]} son:\n{s[0]} {presion[0]}\n{s[1]} {presion[1]}\n{s[2]} {presion[2]}\n{s[3]} {presion[3]}\n{s[4]} {presion[4]}\n{s[5]} {presion[5]}\n{s[6]} {presion[6]}\n{s[7]} {presion[7]}\n";

                    }
                    else
                    {
                        MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            #endregion
            else { MessageBox.Show("Esto no debería aparecerte", "Error en la unidad seleccionada", MessageBoxButton.OK, MessageBoxImage.Error); }
        }


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
                if (MS_check.IsChecked == true)
                {
                    foreach (string s in a_temps)//Buscamos en el arreglo temps todos las strings y las añadimos al ComboBox
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;//Selecionamos el primer objeto de la lista
                }
                else
                {
                    foreach (string s in temps)//Buscamos en el arreglo a_temps todos las strings y las añadimos al ComboBox
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;//Selecionamos el primer objeto de la lista
                }

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
                if (MS_check.IsChecked == true)
                {
                    foreach (string s in ms_masa)
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;
                }
                else
                {
                    foreach (string s in masa)
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;
                }
            }
            else//Presión
            {
                unidad.Items.Clear();
                if (MS_check.IsChecked == true)
                {
                    foreach (string s in ms_presion)
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;
                }
                else
                {
                    foreach (string s in presion)
                    {
                        unidad.Items.Add(s);
                    }
                    unidad.SelectedIndex = 0;
                }
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
        /// <summary>
        /// Borramos la salida al cerrar el menu de las unidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unidad_DropDownClosed(object sender, EventArgs e)
        {
            outtxt.Text = "";
        }
    }
}
