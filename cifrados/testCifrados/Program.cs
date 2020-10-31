using System;
using cifrados;
namespace testCifrados
{
    class Program
    {
        static void Main(string[] args)
        {

            Cesar cifradoCesar = new Cesar();
            
            //cifradoCesar.generarClave();


            cifradoCesar.Cifrar("MARYJ", "MY SPIDER SENSES ARE TINGLING");
            
            Console.WriteLine(cifradoCesar.mensajeCifrado);
        }
    }
}
