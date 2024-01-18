using System;
using M03_UF2_PR1_ClassLibrary;
using Microsoft.VisualBasic;
namespace EspañaJanUF2PR1
{
    public class HeroeVSMonstruo
    {
        public static void Main()
        {
            const string INTRO = "Bienvenido a Héroes vs Monstruo. Qué quieres hacer?\n1. Empezar una nueva aventura\n0. Salir",
                DIFF = "Elige un nivel de dificultad:\n1. Fácil\n2. Difícil\n3. Personalizado\n4. Aleatorio",
                NAMES = "Introduce los nombres de tus héroes (separados por comas, no son necesarios espacios):",
                HEROES = "Arquera: {0}. Bárbaro: {1}. Maga: {2}. Druida: {3}.",
                CUSTOMHP = "Introduce la vida de {0}, la cual está en el siguiente rango: [{1}, {2}]",
                CUSTOMATK = "Introduce el ataque de {0}, el cual está en el siguiente rango:  [{1}, {2}]",
                CUSTOMDF = "Introduce la defensa de {0}, la cual está en el siguiente rango: [{1}, {2}]",
                EXITMSG = "Muchas gracias por jugar Héroes VS Monstruo.";

            string names;
            string[] heroes = new string[4];
            double selection = 0, difficulty = 0, errorCount = 3, max, min, hpMax, hpMin, atkMax, atkMin, dfMax, dfMin;
            double[] hp = new double[3], atk = new double[3], df = new double[3],

            maxHp = { 2000, 3750, 1500, 2500, 7000 }, minHp = { 1500, 3000, 1100, 2000, 1000 },
            maxAtk = { 300, 250, 400, 120, 400 }, minAtk = { 200, 150, 300, 70, 300 },
            maxDf = { 35, 45, 35, 40, 30 }, minDf = { 25, 35, 20, 25, 20 };

            do
            {
                do
                {
                    Console.WriteLine(INTRO);
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (!PR1Library.InRange(selection, max = 1, min = 0))
                    {
                        errorCount--;
                    }
                }
                while (!PR1Library.InRange(selection, max = 1, min = 0) && errorCount > 0);

                do
                {
                    Console.WriteLine(DIFF);
                    difficulty = Convert.ToInt32(Console.ReadLine());
                    if (!PR1Library.InRange(difficulty, max = 4, min = 1))
                    {
                        errorCount--;
                    }
                }
                while (!PR1Library.InRange(difficulty, max = 4, min = 1) && errorCount > 0 && selection == 1);

                

                do
                {
                    Console.WriteLine(NAMES);
                    names = Console.ReadLine();
                }
                while (!PR1Library.NameCheck(names));

                for (int i = 0; i < heroes.Length; i++)
                {
                    heroes[i] = names.Split(',')[i].Trim();
                }
                Console.WriteLine(HEROES, heroes[0], heroes[1], heroes[2], heroes[3]);

                if (difficulty == 1)
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        hp[i] = maxHp[i];
                        atk[i] = maxAtk[i];
                        df[i] = maxDf[i];
                    }
                }
                else if (difficulty == 2)
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        hp[i] = minHp[i];
                        atk[i] = minAtk[i];
                        df[i] = minDf[i];
                    }
                }
                else if (difficulty == 3)
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        do
                        {
                            Console.WriteLine(CUSTOMHP, heroes[i], minHp[i], maxHp[i]);
                            hp[i] = Convert.ToDouble(Console.ReadLine());
                        } while (!PR1Library.InRange(hp[i], max = maxHp[i], min = minHp[i]));
                        do
                        {
                            Console.WriteLine(CUSTOMATK, heroes[i], minAtk[i], maxAtk[i]);
                            atk[i] = Convert.ToDouble(Console.ReadLine());
                        } while (!PR1Library.InRange(atk[i], max = maxAtk[i], min = minAtk[i]));
                        do
                        {
                            Console.WriteLine(CUSTOMDF, heroes[i], minDf[i], maxDf[i]);
                            df[i] = Convert.ToDouble(Console.ReadLine());
                        } while (!PR1Library.InRange(df[i], max = maxDf[i], min = minDf[i]));
                    }
                }
            }
            while (errorCount < 0);
            Console.WriteLine(EXITMSG);
        }
    }
}