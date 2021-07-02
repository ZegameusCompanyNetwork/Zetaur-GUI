using System;
using System.Collections.Generic;
using System.Text;

namespace Zetaur_GUI
{
    public class Conversor
    {
        /// <summary>
        /// Metodo de converison de Atmosferas tecnicas al resto de unidades
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double[] Atm(double i)
        {
            double[] o = new double[8];
            o[0] = i * 1.013;//bar
            o[1] = o[0] * 1000; //mbar
            o[2] = i * 14.6959;//psi
            o[3] = i * 101325;//pa
            o[4] = o[4] / 100;//hpa
            o[5] = i * 760; //mmhg
            o[6] = o[5];//torr
            o[7] = i * 1.03323;//kpcm2
            return o;
        }
        /// <summary>
        /// Metodo de conversion de Bares al resto de unidades
        /// </summary>
        /// <param name="i">Valor a convertir</param>
        /// <returns></returns>
        public static double[] Bar(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i * 1000; //mbar
            o[2] = i * 14.5038;//Psi
            o[3] = i * 100000;//Pa
            o[4] = o[1];//Hpa
            o[5] = i * 750.062; //mmhg
            o[6] = o[5];//torr
            o[7] = i * 1.01972;//kpcm2
            return o;
        }


        public static double[] Mbar(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }


        public static double[] Psi(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 51.715;//mmhg
            o[7] = o[6];//torr
            return o;
        }


        public static double[] Pa(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }


        public static double[] Hpa(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }


        public static double[] Mmhg(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }


        public static double[] Torr(double i)
        {
            double[] o = new double[8];
            o[0] = i / 760;//atm
            o[1] = i / 750.062; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = i / 51.715;//psi
            o[4] = i * 133.322;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i;//mmhg
            o[7] = i / 735.559;//kpcm
            return o;
        }

        /// <summary>
        /// Metodo de conversion de Kilogramo-fuerza (Kilopondio) por centimetro cuadrado al resto de unidades
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double[] Kpcm(double i)//Kilogramo-fuerza (Kilopondio) por centimetro cuadrado
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = i * 14.5038;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }
    }
    public partial class Temp : Conversor
    {
        public static double[] Celsius(double i)
        {
            double[] o = new double[4];
            o[0] = (i * 9 / 5) + 32; // Fahrenheit
            o[1] = i + 273.15; //Kelvin
            o[2] = (i * 9 / 5) + 491.67; //Rankine
            o[3] = i * 0.8; //Réaumur
            return o;
        }
        public static double[] Fahr(double i)
        {
            double[] o = new double[4];
            o[0] = (i - 32) * 5 / 9; // Celsius
            o[1] = o[0] + 273.15; //Kelvin
            o[2] = i + 459.67; //Rankine
            o[3] = (i - 32) * 4 / 9; //Réaumur
            return o;
        }
        public static double[] Kelvin(double i)
        {
            double[] o = new double[4];
            o[0] = i - 273.15; //Celsius
            o[1] = (i * 9 / 5) - 459.67; //Fahrenheit
            o[2] = i * 9 / 5; //Rankine
            o[3] = (i - 273.15) * 4 / 5; //Réaumur
            return o;
        }
        public static double[] Rankine(double i)
        {
            double[] o = new double[4];
            o[0] = (i - 491.67) * 5 / 9; //Celsius
            o[1] = i - 459.67; //Fahrenheit
            o[2] = i * 5 / 9; //Kelvin
            o[3] = (o[1] - 32) * 4 / 9; //Réaumur
            return o;
        }
        public static double[] Reaumur(double i)
        {
            double[] o = new double[4];
            o[0] = i * 5 / 4; //Celsius
            o[1] = (i * 9 / 4) + 32; //Fahrenheit
            o[2] = i * 5 / 4 + 273.15; //Kelvin
            o[3] = (i * 9 / 4) + 491.67; //Rankine
            return o;
        }
    }
}
