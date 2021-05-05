using System;
using System.Collections.Generic;
using System.Text;

namespace Zetaur_GUI
{
    public class Conversor
    {
        public static double[] atm(double i)
        {
            double[] o = new double[8];
            o[0] = i * 1.013;//bar
            o[1] = o[0] *1000; //mbar
            o[2] = i * 14.6959;//psi
            o[3] = i * 101325;//pa
            o[4] = o[4] / 100;//hpa
            o[5] = i*760; //mmhg
            o[6] = o[5];//torr
            o[7] = i*1.03323;//kpcm2
            return o;
        }
        public static double[] bar(double i)
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
        public static double[] mbar(double i)
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
        public static double[] psi(double i)
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
        public static double[] pa(double i)
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
        public static double[] hpa(double i)
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
        public static double[] mmhg(double i)
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
        public static double[] torr(double i)
        {
            double[] o = new double[8];
            o[0] = i / 1.03323;//atm
            o[1] = i / 1.0172; //bar
            o[2] = o[1] * 1000;//mbar
            o[3] = 14.2233;//psi
            o[4] = i * 98066.5;//pa
            o[5] = o[4] / 100; //hpa
            o[6] = i;//mmhg
            o[7] = i;//kpcm
            return o;
        }
        public static double[] kpcm(double i)
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
    }
}
