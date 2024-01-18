using System;
using System.ComponentModel.DataAnnotations;

namespace M03_UF2_PR1_ClassLibrary
{
    public class PR1Library
    {
        public static bool InRange(double num, double max, double min)
        {
            return num >= min && num <= max;
        }
        public static bool NameCheck(string names)
        {
            int commaCount = 0;
            char comma = ',';
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == comma)
                {
                    commaCount++;
                }
            }
            return commaCount >= 3;
        }
        public static double RandomStats (double max, double min)
        {
            Random rnd = new Random();
            return (double)rnd.Next(Convert.ToInt32(min), Convert.ToInt32(max) + 1);
        }
        public static int[] Turns(int[] turns)
        {
            Random rnd = new Random();
            int[] turnsRandom = new int[turns.Length];
            for (int i = 0; i < turns.Length; i++)
            {
                turnsRandom[i] = rnd.Next(0, 4) + 1;
                for (int j = 0; j < i; j++)
                {
                    if (turnsRandom[i] == turnsRandom[j])
                    {
                        i--;
                    }
                }
            }
            return turnsRandom;
        }
    }
}
