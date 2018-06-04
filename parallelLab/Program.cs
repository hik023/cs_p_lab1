using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace parallelLab
{
    class Program
    {
        static int[] mas = new int[] { 3, 1, 7, 5 };

        static void sortUp()
        {
            lock (mas)
            {
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        if (mas[i] > mas[j])
                        {
                            int tmp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = tmp;
                        }
                    }
                }
            }
        }

        static void sortDown()
        {
            lock (mas)
            {
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        if (mas[i] < mas[j])
                        {
                            int tmp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = tmp;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            
            for (int el = 0; el < mas.Length; el++)
            {
                Console.WriteLine(mas[el]);
            }
            Console.WriteLine('\n');
            Thread t1 = new Thread(sortUp);
            t1.Start();
            t1.Join();
            
            for (int el = 0; el < mas.Length; el++)
            {
                Console.WriteLine(mas[el]);
            }
            Console.WriteLine('\n');
            Thread t2 = new Thread(sortDown);
            t2.Start();
            t2.Join();

            for (int el = 0; el < mas.Length; el++)
            {
                Console.WriteLine(mas[el]);
            }
            Console.ReadLine();
        }
    }
}
