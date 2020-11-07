using System;
using cifrados;
namespace testCifrados
{
    class Program
    {
        static void Main(string[] args)
        {
            string himnoPrueba = "¡Guatemala feliz! que tus aras no profane jamás el verdugo; ni haya esclavos que laman el yugo ni tiranos que escupan tu faz.";
            //Cesar cifradoCesar = new Cesar();

            //cifradoCesar.generarClave();


            //cifradoCesar.Cifrar("MARYJ", himnoPrueba.ToUpper());

            //Console.WriteLine(cifradoCesar.mensajeCifrado);

            //cifradoCesar.Descifrar("MARYJ", cifradoCesar.mensajeCifrado);

            //Console.WriteLine(cifradoCesar.mensajeDescifrado);



            //ZigZag cifradoZigZag = new ZigZag(himnoPrueba, 4);


            //cifradoZigZag.cifrar();

            //cifradoZigZag.Descifrar(cifradoZigZag.textoCifrado , 4);

            Ruta cifradoRuta = new Ruta(25,8, himnoPrueba.ToUpper());
            cifradoRuta.cifrar();
            Console.WriteLine(cifradoRuta.textoCifrado);

            Ruta DescifradoRuta = new Ruta(25, 8, cifradoRuta.textoCifrado);

            DescifradoRuta.descifrar();
            Console.WriteLine(DescifradoRuta.textoDescifrado);

        }
    }
}
