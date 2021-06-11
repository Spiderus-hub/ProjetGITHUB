using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet_guybrush_Leporcq_Desnoes_Wolff
{
    class Décodage
    {
        int[,] trameE = new int[10, 10];
        string[,] trameC = new string[10, 10];
        string CheminAcess;
        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe Décodage
        /// </summary>
        /// <param name="CheminAccess"></param>
        public Décodage(string CheminAccess)
        {
            string Lcarte;
            int j = 0;
            int i;
            int k = 0;
            StreamReader carte = new StreamReader(CheminAccess + ".chiffre.txt"); //permet de lire la carte
            trameF = ExtraS(carte.ReadLine()); //Extrait les symboles de la carte

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    trameE[i, j] = Convert.ToInt32(trameF[k]); // transforme en entier
                    k++;
                }
            }
            Décoder();
            carte.Close();
        }
        string[] trameF = new string[100];
        private string[] ExtraS(string LigneFichier)
        {
            string[] Tab = LigneFichier.Split(':', '|'); //séparation du tableau

            return Tab;

        }
        #endregion
        #region méthode
        /// <summary>
        /// Permet d'effectuer l'affichage de la carte colorié
        /// </summary>
        public void Affichage()
        {
            int i;
            int j;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    if (trameC[i, j] == "M")
                    {
                        // Coloration de la Lettre en Bleu
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(trameC[i, j]);
                    }

                    else if (trameC[i, j] == "F")
                    {
                        // Coloration de la Lettre en Vert
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(trameC[i, j]);
                    }

                    else
                    {
                        // Coloration de la Lettre en Blanc
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(trameC[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Décodage de la trame
        /// </summary>
        private void Décoder()
        {
            int i;
            int j;
            for (i = 0; i < 10; i++) //chaque for vérifie chaque ligne de chaque colonne
            {
                for (j = 0; j < 10; j++)
                {
                    if (trameE[i,j] >= 64) //Si la valeur >64 remplacer
                    {
                        trameC[i, j] = "M";
                    }
                        else if(trameE[i,j] >=32 && trameE[i, j] < 64) //
                    {
                        trameC[i, j] = "F";
                        }
                    else if (trameE[i, j] < 32)
                    {
                        trameC[i, j] = "O";
                    }
             }
         }
        }
        #endregion


    }
}

