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
                ERROR = "Valor incorrecto, vuelve a introducirlo.", EXITMSG = "Muchas gracias por jugar Héroes VS Monstruo.";

            string names;
            string[] heroes = new string[4];
            int selection = 0, difficulty = 0, errorCount = 3, max, min;
            do
            {
                do
                {
                    Console.WriteLine(INTRO);
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (!PR1Library.InRange(selection, max = 1, min = 0))
                    {
                        errorCount--;
                        if (errorCount > 0)
                        {
                            Console.WriteLine(ERROR);
                        }
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
                        if (errorCount > 0)
                        {
                            Console.WriteLine(ERROR);
                        }
                    }
                }
                while (!PR1Library.InRange(difficulty, max = 4, min = 1) && errorCount > 0 && selection == 1);

                do
                {
                    Console.WriteLine(NAMES);
                    names = Console.ReadLine();
                    if (!PR1Library.NameCheck(names))
                    {
                        Console.WriteLine(ERROR);
                    }
                }
                while (!PR1Library.NameCheck(names));

                for (int i = 0; i < heroes.Length; i++)
                {
                    heroes[i] = names.Split(',')[i].Trim();
                }
            }
            while (errorCount < 0);
            Console.WriteLine(EXITMSG);
        }
    }
}