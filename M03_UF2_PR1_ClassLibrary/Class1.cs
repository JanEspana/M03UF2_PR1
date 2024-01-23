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
        public static double Random (double max, double min)
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
                turnsRandom[i] = rnd.Next(0, 4);
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
        public static double Attack(double atk, double hp, double df)
        {
            return hp - atk + (atk * df / 100) > 0 ? hp - atk + (atk * df / 100) : 0;
        }
        public static double[] Heal(double[] hp, double[] maxHp)
        {
            for (int i = 0; i < hp.Length; i++)
            {
                if (hp[i] + 500 >= maxHp[i])
                {
                    hp[i] = maxHp[i];
                }
                else if (hp[i] <= 0)
                {
                    hp[i] = 0;
                }
                else
                {
                    hp[i] = hp[i] + 500;
                }
            }
            return hp;
        }
        public static double[] BubbleSort(double[] hp)
        {
            for (int i = 0; i < hp.Length - 1; i++)
            {
                for (int j = 0; j < hp.Length - 1; j++)
                {
                    if (hp[j] < hp[j + 1])
                    {
                        double temp = hp[j];
                        hp[j] = hp[j + 1];
                        hp[j + 1] = temp;
                    }
                }
            }
            return hp;
        }
        public static string[] NameSort(string[] heroes, double[] auxHp, double[] hp)
        {
            string[] output = new string[4];
            for (int i = 0; i < heroes.Length; i++)
            {
                for (int j = 0; j < heroes.Length; j++)
                {
                    if (auxHp[i] == hp[j])
                    {
                        output[i] = heroes[j];
                    }
                }
            }
            return output;
        }
    }
}
