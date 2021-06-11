using System;

namespace Projet_guybrush_Leporcq_Desnoes_Wolff
{
    class Program
    {
        static void Main(string[] args)
        {
            CodageG CodageScabb = new CodageG(@"C:\Users\Max\Desktop\Scabb");
            Décodage DécodageScabb = new Décodage(@"C:\Users\Max\Desktop\Scabb");
            DécodageScabb.Affichage();
        }
    }
}
