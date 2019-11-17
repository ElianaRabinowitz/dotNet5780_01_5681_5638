using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace something
{
    public class Ex1_1
    {
        int[] A;
        int[] B;
        int[] C;
        public Ex1_1()
        {
            A = new int[20];
            B = new int[20];
            C = new int[20];
        }

        internal void run(Random rand)
        {
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(18, 122);
                B[i] = rand.Next(18, 122);
                C[i] = Math.Abs(A[i] - B[i]);
            }
        }

        internal void show()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0, 3} ", A[i]);

            }
            Console.WriteLine();
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0, 3} ", B[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0, 3} ", C[i]);
            }
            Console.WriteLine();
        }
    }
}

/********** Output ***********
 *  22  23  46  42  77  89  63  67  42  69  57  52  98  99 114  76  96  92  31  34
 * 111  64  64  49  75  51  51  49  48  76  79  32 102 111  42  26  57  26 111  21
 * 89  41  18   7   2  38  12  18   6   7  22  20   4  12  72  50  39  66  80  13
 *Press any key to continue . . .
 ****************************/


namespace something
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Ex1_1 ex = new Ex1_1();
            ex.run(rand);
            ex.show();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
