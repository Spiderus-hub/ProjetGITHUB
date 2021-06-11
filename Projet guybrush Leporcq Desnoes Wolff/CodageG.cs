using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet_guybrush_Leporcq_Desnoes_Wolff
{
    class CodageG
    {
        int[,] trameE = new int[10,10];
        char[,] trameC = new char[10,10];
        string CheminAcess;
        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe CodageG
        /// </summary>
        /// <param name="CheminAccess"></param>
        ///
        public CodageG (string CheminAccess)
        {
            string Lcarte;
            int j = 0;
            StreamReader carte = new StreamReader(CheminAccess + ".clair.txt"); //permet la lecture de la carte
            while ((Lcarte = carte.ReadLine()) != null) //met chaques lignes dans la var carte et la décompose avec foreach
            {
                int i = 0;
                foreach (char E in Lcarte) 
                {
                    trameC[i, j] = E;
                    i++;
                }
                j++;
            }
            carte.Close();
            for (int H = 0; H<10; H++) //Si H=0 la ligne est celle du haut
            {
                for (int L = 0; L<10; L++) //Si L=0 la ligne est celle de gauche
                {
                    char F = trameC[L, H];
                    int Val = 0;

                    if (H == 0)
                    {
                        Val = Val + 1;
                    }
                    else
                    {
                        if (F != trameC[L,H-1])
                        {
                            Val = Val + 1;
                        }
                    }

                    if (H == 9)
                    {
                        Val = Val + 4;
                    }
                    else
                    {
                        if (F != trameC[L, H + 1])
                        {
                            Val = Val + 4;
                        }
                    }

                    if (L == 0)
                    {
                        Val = Val + 2;
                    }
                    else
                    {
                        if (F != trameC[L - 1, H])
                        {
                            Val = Val + 2;
                        }
                    }

                    if (L == 9)
                    {
                        Val = Val + 8;
                    }
                    else
                    {
                        if (F != trameC[L + 1, H])
                        {
                            Val = Val + 8;
                        }
                    }
                    if (F =='F')
                    {
                        Val = Val + 32;
                    }
                    if (F == 'M')
                    {
                        Val = Val + 64;
                    }
                    trameE[L, H] = Val;
                }
            }

            for (int H = 0; H < 10; H++) //affichage
                    {
                        for (int L = 0; L < 10; L++)
                        {
                    Console.Write("{0} ", trameE[L, H]);
                    Console.Write(":");
                }
                Console.Write("|");
                    }
            Console.WriteLine();
                }
        #endregion
    }
}
