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
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = i / 51.715;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i;//mmhg
            o[7] = i;//kpcm
            return o;
        }

        /// <summary>
        /// Metodo de conversion de Kilogramo-fuerza por centimetro cuadrado al resto de unidades
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double[] Kpcm(double i)//Kilogramo-fuerza (Kilopondio) por centimetro cuadrado
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = i / 14.5038;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i * 735.559;//mmhg
            o[7] = o[6];//torr
            return o;
        }
    }
}
