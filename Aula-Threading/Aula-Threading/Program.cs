using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula_Threading
{
    class Program
    {
    static void Main(string[] args)
        {
            //criar dicionario
            var dict = new HashSet<string>(
                File.ReadAllLines("wordlist-big-latest.txt"),
                StringComparer.InvariantCultureIgnoreCase
                );
            var palavras = dict.ToArray();
            Random rnd = new Random();
            //criar o Documento para verificar palavras que existam

            var lista = new List<String>();

            for(int i = 0; i < 1000000; i++)
            {
                lista.Add(palavras[rnd.Next(0, palavras.Length)]);
            }
            lista[12415] = "andre";
            lista[72515] = "afasgaga";
            lista[537371] = "obgrbior";

            var erros = new List<string>();

            //foreach (var item in lista){
            //    if (!dict.Contains(item))
            //    {
            //        erros.Add(item);
            //    }
            //}

            var errosConc = new ConcurrentBag<Tuple<int, string>>();

            Parallel.ForEach(lista, (palavra, state, pos) => 
            {
                if (!dict.Contains(palavra)) errosConc.Add(Tuple.Create((int)pos,palavra));
            });
            foreach(var item in errosConc)
            {
                Console.WriteLine(item.Item1 + "-" + item.Item2);
            }
            Console.ReadKey();
        }


        //static int a;
        //static int b;
        //static readonly object _locker = new object(); //para bloquear classes para nao modificar as variaveis que estou a utilizar

        //static void Main(string[] args)
        //{
        //    a = 12;
        //    b = 6;

        //    Thread t1 = new Thread(CalculaDivisao);
        //    Thread t2 = new Thread(CalculaDivisao);

        //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  A iniciar Threads\n");
        //    t1.Start();
        //    t2.Start();

        //    t1.Join();
        //    t2.Join();

        //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  A modificar Valor\n");
        //    lock (_locker)
        //    {
        //        b = 0;
        //    }
        //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  Valor Modificado\n");

        //    Console.ReadKey();
        //}

        //static void CalculaDivisao()
        //{
        //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  A iniciar\n");
        //    lock (_locker)
        //    {
        //        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  Bloqueado \n");
        //        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  O Resultado é : " + a / b);
        //    }
           
        //}
        //        static void Main(string[] args)
        //        {

        //            Thread t1 = new  Thread(DesenhaX);
        //            Thread t2 = new Thread(Desenha0);

        //            t1.Start();
        //            //t1.Join(); Espera que a thread acabe antes de continuar o codigo
        //            //t1.Sleep(100); Mesma coisa mas o codigo fica adormecido durante x tempo
        //            // Thread. Usa a thread principal ou a thread em uso no momento
        //            //Thread.SpinWait(10); Apos x ciclos pára VERIFICAR DEPOIS 
        //            t2.Start();

        //            for(int i = 0; i < 1000; i++)
        //            {
        //                Console.Write("y");
        //            }
        //            Console.ReadKey();
        //        }
        //        static void DesenhaX()
        //        {
        //            for (int i = 0; i < 1000; i++)
        //            {
        //                Console.Write("x");
        //            }
        //        }

        //        static void Desenha0()
        //        {
        //            for (int i = 0; i < 1000; i++)
        //            {
        //                Console.Write("0");
        //            }
        //        }
    }
}
