﻿using System;
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
                ERROR = "Valor incorrecto, vuelve a introducirlo.";
            
            int selection = 0, difficulty = 0, max, min;
            do
            {
                Console.WriteLine(INTRO);
                selection = Convert.ToInt32(Console.ReadLine());
                if (!HeroeVSMonstruoLibrary.InRange(selection, max = 1, min = 0))
                {
                    Console.WriteLine(ERROR);
                }
            }
            while (!HeroeVSMonstruoLibrary.InRange(selection, max = 1, min = 0));
            do
            {
                Console.WriteLine(DIFF);
                difficulty = Convert.ToInt32(Console.ReadLine());
                if (!HeroeVSMonstruoLibrary.InRange(difficulty, max = 4, min = 1))
                {
                    Console.WriteLine(ERROR);
                }
            }
            while (!HeroeVSMonstruoLibrary.InRange(difficulty, max = 4, min = 1));
        }
    }
}