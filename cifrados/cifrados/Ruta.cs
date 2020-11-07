using System;
using System.Collections.Generic;
using System.Text;

namespace cifrados
{
    
    public class Ruta
    {
        int fila;
        int columna;
        string TextArchivo;
        char[,] matriz;

        public string textoCifrado = "";
        public string textoDescifrado = "";

        public Ruta(int filaMatriz, int columnaMatriz, string contenidoArchivo) {
            fila = filaMatriz;
            columna = columnaMatriz;
            TextArchivo = contenidoArchivo;
            matriz = new char[fila, columna];
        }

        public void cifrar()
        {
           
            int cont = 0;

            for (int i = 0; i < columna; i++)
            {
                for (int j = 0; j < fila; j++)
                {
                    if (cont < TextArchivo.Length)
                    {
                        matriz[j, i] = TextArchivo[cont];
                    }

                    else {
                        matriz[j, i] = '☻';
                    }
                        

                    cont++;
                }
            }

            string outPut = "";
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    outPut += matriz[i, j];
                }
            }

            textoCifrado = outPut;
        }

        public void descifrar()
        {
            int cont = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columna; j++)
                {
                    matriz[i, j] = TextArchivo[cont];
                    cont++;
                }
            }

            string outPut = "";
            for (int i = 0; i < columna; i++)
            {
                for (int j = 0; j < fila; j++)
                {
                    outPut += matriz[j, i];
                }
            }

            outPut = outPut.Replace('#', ' ');

            textoDescifrado = outPut;
        }


    }
}
