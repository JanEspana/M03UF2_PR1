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
                CUSTOMDF = "Introduce la reducción de daño de {0}, la cual está en el siguiente rango: [{1}, {2}]",
                EXITMSG = "Muchas gracias por jugar Héroes VS Monstruo.",
                TURN = "Turno {0}", HEROTURN = "Estadísticas de {0}:\nVida: {1}\nAtaque: {2}\nReducción de daño: {3}%\n",
                STATSHOW = "{0}:\nVida: {1}\nAtaque: {2}\nReducción de daño: {3}%\n",
                TOOMANYERRORS = "Has cometido demasiados errores, esta estadística será la mínima cantidad posible.",
                BATTLE = "Es el turno de {0}.\n1. Atacar\n2. Defenderse\n3. Habilidad especial.",
                COOLDOWN = "Aún quedan {0} turnos para que {1} pueda usar su habilidad especial.",
                ATTACK = "{0} inflinge {1} puntos de daño al Monstruo, dejándolo con {2} puntos de vida.",
                DEFFENSE = "{0} se defiende, duplicando su resistencia por este turno.",
                SPECIAL = "{0} utiliza su habilidad especial!",
                MONSTERATTACK = "¡El monstruo ataca!";

            string names;
            bool resetTurn = false;
            int flinchAbility = 0, protectAbility = 0;
            string[] heroes = new string[4];
            double selection = 0, difficulty = 0, errorCount = 3, max, min;
            bool[] protect = new bool[4];
            int[] turn = new int[4], abilityCooldown = new int[4];
            double[] hp = new double[4], atk = new double[4], df = new double[4], monster = new double[3],

                //Para que se entienda el código, cada personaje es un elemento de cada una de las arrays.
                //Arquera = 0, Bárbaro = 1, Maga = 2, Druida = 3.

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
                    monster[0] = minHp[minHp.Length - 1];
                    monster[1] = minAtk[minAtk.Length - 1];
                    monster[2] = minDf[minDf.Length - 1];
                }
                else if (difficulty == 2)
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        hp[i] = minHp[i];
                        atk[i] = minAtk[i];
                        df[i] = minDf[i];
                    }
                    monster[0] = maxHp[maxHp.Length - 1];
                    monster[1] = maxAtk[maxAtk.Length - 1];
                    monster[2] = maxDf[maxDf.Length - 1];
                }
                else if (difficulty == 3)
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        errorCount = 3;
                        do
                        {
                            Console.WriteLine(CUSTOMHP, heroes[i], minHp[i], maxHp[i]);
                            hp[i] = Convert.ToDouble(Console.ReadLine());
                            if (!PR1Library.InRange(hp[i], max = maxHp[i], min = minHp[i]))
                            {
                                errorCount--;
                            }
                        } while (!PR1Library.InRange(hp[i], max = maxHp[i], min = minHp[i]) && errorCount > 0);
                        if (errorCount == 0)
                        {
                            Console.WriteLine(TOOMANYERRORS);
                            hp[i] = minHp[i];
                        }
                        errorCount = 3;
                        do
                        {
                            Console.WriteLine(CUSTOMATK, heroes[i], minAtk[i], maxAtk[i]);
                            atk[i] = Convert.ToDouble(Console.ReadLine());
                            if (!PR1Library.InRange(atk[i], max = maxAtk[i], min = minAtk[i]))
                            {
                                errorCount--;
                            }
                        } while (!PR1Library.InRange(atk[i], max = maxAtk[i], min = minAtk[i]) && errorCount > 0);
                        if (errorCount == 0)
                        {
                            Console.WriteLine(TOOMANYERRORS);
                            atk[i] = minAtk[i];
                        }
                        errorCount = 3;
                        do
                        {
                            Console.WriteLine(CUSTOMDF, heroes[i], minDf[i], maxDf[i]);
                            df[i] = Convert.ToDouble(Console.ReadLine());
                            if (!PR1Library.InRange(df[i], max = maxDf[i], min = minDf[i]))
                            {
                                errorCount--;
                            }
                        } while (!PR1Library.InRange(df[i], max = maxDf[i], min = minDf[i]) && errorCount > 0);
                        if (errorCount == 0)
                        {
                            Console.WriteLine(TOOMANYERRORS);
                            df[i] = minDf[i];
                        }

                    }
                    Console.Write("Turno del monstruo.");
                    errorCount = 3;
                    do
                    {
                        Console.WriteLine(CUSTOMHP, "el monstruo", minHp[minHp.Length - 1], maxHp[maxHp.Length - 1]);
                        monster[0] = PR1Library.RandomStats(maxHp[maxHp.Length - 1], minHp[minHp.Length - 1]);
                    } while (!PR1Library.InRange(monster[0], max = maxHp[maxHp.Length - 1], min = minHp[minHp.Length - 1]) && errorCount > 0);
                    if (errorCount == 0)
                    {
                        Console.WriteLine(TOOMANYERRORS);
                        monster[0] = minHp[minHp.Length - 1];
                    }
                    errorCount = 3;
                    do
                    {
                        Console.WriteLine(CUSTOMATK, "el monstruo", minAtk[minAtk.Length - 1], maxAtk[maxAtk.Length - 1]);
                        monster[1] = PR1Library.RandomStats(maxAtk[maxAtk.Length - 1], minAtk[minAtk.Length - 1]);
                    } while (!PR1Library.InRange(monster[1], max = maxAtk[maxAtk.Length - 1], min = minAtk[minAtk.Length - 1]) && errorCount > 0);
                    if (errorCount == 0)
                    {
                        Console.WriteLine(TOOMANYERRORS);
                        monster[1] = minAtk[minAtk.Length - 1];
                    }
                    errorCount = 3;
                    do
                    {
                        Console.WriteLine(CUSTOMDF, "el monstruo", minDf[minDf.Length - 1], maxDf[maxDf.Length - 1]);
                        monster[2] = PR1Library.RandomStats(maxDf[maxDf.Length - 1], minDf[minDf.Length - 1]);
                    } while (!PR1Library.InRange(monster[2], max = maxDf[maxDf.Length - 1], min = minDf[minDf.Length - 1]) && errorCount > 0);
                    if (errorCount == 0)
                    {
                        Console.WriteLine(TOOMANYERRORS);
                        monster[2] = minDf[minDf.Length - 1];
                    }
                }
                else
                {
                    for (int i = 0; i < heroes.Length; i++)
                    {
                        hp[i] = PR1Library.RandomStats(maxHp[i], minHp[i]);
                        atk[i] = PR1Library.RandomStats(maxAtk[i], minAtk[i]);
                        df[i] = PR1Library.RandomStats(maxDf[i], minDf[i]);
                    }
                    monster[0] = PR1Library.RandomStats(maxHp[maxHp.Length - 1], minHp[minHp.Length - 1]);
                    monster[1] = PR1Library.RandomStats(maxAtk[maxAtk.Length - 1], minAtk[minAtk.Length - 1]);
                    monster[2] = PR1Library.RandomStats(maxDf[maxDf.Length - 1], minDf[minDf.Length - 1]);
                }

                for (int i = 0; i < heroes.Length; i++)
                {
                    Console.WriteLine(STATSHOW, heroes[i], hp[i], atk[i], df[i]);
                }
                Console.WriteLine(STATSHOW, "Monstruo", monster[0], monster[1], monster[2]);



                for (int battleTurns = 1; monster[0] > 0; battleTurns++)
                {
                    Console.WriteLine(TURN, battleTurns);
                    turn = PR1Library.Turns(turn);
                    Console.WriteLine("Orden: ");
                    for (int j = 0; j < turn.Length; j++)
                    {
                        Console.Write(heroes[turn[j]] + " ");
                    }
                    for (int i = 0; i < heroes.Length && monster[0] > 0; i++)
                    {   
                        if (hp[turn[i]] > 0)
                        {
                            Console.WriteLine();
                            do
                            {
                                resetTurn = false;
                                Console.WriteLine(BATTLE, heroes[turn[i]]);
                                selection = Convert.ToInt32(Console.ReadLine());
                            } while (!PR1Library.InRange(selection, max, min));
                            do
                            {
                                if (selection == 1)
                                {
                                    monster[0] = Math.Round(PR1Library.HeroAttack(atk[turn[i]], monster[0], monster[2]), 2);
                                    Console.WriteLine(ATTACK, heroes[turn[i]], atk[turn[i]], monster[0]);
                                }
                                else if (selection == 2)
                                {
                                    protect[turn[i]] = true;
                                    Console.WriteLine(DEFFENSE, heroes[turn[i]]);
                                }
                                else
                                {
                                    if (abilityCooldown[turn[i]] == 0)
                                    {
                                        Console.WriteLine(SPECIAL, heroes[turn[i]]);
                                        if (turn[i] == 0)
                                        {
                                            flinchAbility = 2;
                                        }
                                        else if (turn[i] == 1)
                                        {
                                            protectAbility = 2;
                                        }
                                        else if (turn[i] == 2)
                                        {
                                            monster[0] = PR1Library.HeroAttack(atk[turn[i]] * 3, monster[0], monster[2]);
                                        }
                                        else
                                        {
                                            if (difficulty == 2)
                                            {
                                                hp = PR1Library.Heal(hp, minHp);
                                            }
                                            else
                                            {
                                                hp = PR1Library.Heal(hp, maxHp);
                                            }
                                        }
                                        abilityCooldown[turn[i]] = 5;
                                    }
                                    else
                                    {
                                        Console.Write(COOLDOWN, 5 - abilityCooldown[turn[i]], heroes[turn[i]]);
                                        resetTurn = true;
                                    }
                                }
                            } while (resetTurn);
                        }
                    }
                    Console.Write(MONSTERATTACK);

                }


            }
            while (errorCount < 0);
            Console.WriteLine(EXITMSG);
        }
    }
}