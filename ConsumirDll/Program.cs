using RSACripto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsumirDll
{
    class Program
    {


        static void Main(string[] args)
        {

            Metodo objeto= new Metodo();
            objeto.Algo();
            Console.ReadKey();

        }
        public class Metodo
        {
            RSACriptoGrafia Objeto = new RSACriptoGrafia();
            public void Algo()
            {

                string mensaje = "PERRO";

                Objeto.Iniciar();
               
                Console.WriteLine("Tamanio de la llave: \t " + Objeto.Llave);
            }
        }
    }
}
