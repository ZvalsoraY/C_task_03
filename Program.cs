using System;
using System.Diagnostics;

namespace C_task_03
{
    public class GCD //greatest common divisor
    {
        public static long Euclidean(long var1, long var2)  //greatest common divisor Euclidean Algorithm
        {
            while ((var1 != 0) && (var2 != 0))
            {
                if (var1 > var2)
                    var1 -= var2;
                else
                    var2 -= var1;
            }
            return Math.Max(var1, var2);
        }
        public static long Euclidean(long a, long b, out string elapsedTime) //greatest common divisor Recursive Stein's Algorithm
        {
            //elapsedTime = "RunTime ";
            Stopwatch stopwatchStein = new Stopwatch();
            stopwatchStein.Start();
            long answer = Euclidean(a, b);
            stopwatchStein.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan timeStein = stopwatchStein.Elapsed;
            // Format and display the TimeSpan value.
            //elapsedTime = elapsedTime + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    timeStein.Hours, timeStein.Minutes, timeStein.Seconds,
            //    timeStein.Milliseconds / 10);
            elapsedTime = timeStein.TotalMilliseconds.ToString();
            return answer;
        }
        public static long Euclidean(long var1, long var2, long var3)  //greatest common divisor Euclidean Algorithm
        {
            return Euclidean(var1, Euclidean(var2, var3));
        }
        public static long Euclidean(long var1, long var2, long var3, long var4)  //greatest common divisor Euclidean Algorithm
        {
            return Euclidean(var1, Euclidean(var2, Euclidean(var3, var4)));
        }
        public static long Euclidean(long var1, long var2, long var3, long var4, long var5)  //greatest common divisor Euclidean Algorithm
        {
            return Euclidean(var1, Euclidean(var2, Euclidean(var3, Euclidean(var4, var5))));
        }

        //public static int SteinGCD(int a, int b)  //greatest common divisor Stein's Algorithm
        //{
        //    // GCD(0, b) == b; GCD(a, 0) == a,  
        //    // GCD(0, 0) == 0 
        //    if (a == 0)
        //        return b;
        //    if (b == 0)
        //        return a;
        //    // Finding K, where K is the greatest  
        //    // power of 2 that divides both a and b 
        //    int k;
        //    for (k = 0; ((a | b) & 1) == 0; ++k)
        //    {
        //        a >>= 1;
        //        b >>= 1;
        //    }

        //    // Dividing a by 2 until a becomes odd 
        //    while ((a & 1) == 0)
        //        a >>= 1;
        //    // From here on, 'a' is always odd 
        //    do
        //    {
        //        // If b is even, remove  
        //        // all factor of 2 in b  
        //        while ((b & 1) == 0)
        //            b >>= 1;
        //        /* Now a and b are both odd. Swap  
        //        if necessary so a <= b, then set  
        //        b = b - a (which is even).*/
        //        if (a > b)
        //        {
        //            // Swap u and v. 
        //            int temp = a;
        //            a = b;
        //            b = temp;
        //        }

        //        b = b - a;
        //    } while (b != 0);

        //    /* restore common factors of 2 */
        //    return a << k;
        //}

        public static long Stein(long a, long b) //greatest common divisor Recursive Stein's Algorithm
        {
            if (a == b)
                return a;
            // GCD(0, b) == b; 
            // GCD(a, 0) == a, 
            // GCD(0, 0) == 0 
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            // look for factors of 2 
            // a is even 
            if ((~a & 1) == 1)
            {
                // b is odd 
                if ((b & 1) == 1)
                    return Stein(a >> 1, b);
                else
                    // both a and b are even 
                    return Stein(a >> 1, b >> 1) << 1;
            }

            // a is odd, b is even 
            if ((~b & 1) == 1)
                return Stein(a, b >> 1);
            // reduce larger number 
            if (a > b)
                return Stein((a - b) >> 1, b);
            return Stein((b - a) >> 1, a);
        }

        public static long Stein(long a, long b, out string elapsedTime) //greatest common divisor Recursive Stein's Algorithm
        {
            Stopwatch stopwatchStein = new Stopwatch();
            stopwatchStein.Start();
            long answer = Stein(a, b);
            stopwatchStein.Stop();
            TimeSpan timeStein = stopwatchStein.Elapsed;
            elapsedTime = timeStein.TotalMilliseconds.ToString();
            return answer;  
        }
    }
    class Program
    {
        static void Main()
        {
            static long [] InputData(int n)
            {
                Console.WriteLine("Введите числа через Enter");
                long[] Data = new long[n];
                int i = 0;
                while (i < n)
                {
                    Data[i] = long.Parse(Console.ReadLine());
                    Console.WriteLine();
                    i++;
                }
                return Data;
            }
            
            Console.WriteLine("Здравствуйте! Данна программа позволяет вычислять НОД.");
            Console.WriteLine("Если вы хотите вычислить НОД двух целых чисел используя алгоритм Евклида введите 1.");
            Console.WriteLine("Если вы хотите вычислить НОД трех целых чисел используя алгоритм Евклида введите 2.");
            Console.WriteLine("Если вы хотите вычислить НОД четырех целых чисел используя алгоритм Евклида введите 3.");
            Console.WriteLine("Если вы хотите вычислить НОД пяти целых чисел используя алгоритм Евклида введите 4.");
            Console.WriteLine("Если вы хотите вычислить НОД двух целых чисел используя алгоритм Стейна введите 5.");
            Console.WriteLine("Если вы хотите вычислить НОД двух целых чисел используя алгоритм Стейна и узнать сколько времени на это потребовалось введите 6.");
            Console.WriteLine("Если вы хотите вычислить НОД двух целых чисел используя алгоритм Евклида и узнать сколько времени на это потребовалось введите 7.");

            Console.Write("Введите число : ");
            int funSelection = Convert.ToInt16(Console.ReadLine());
            long nodRes = 0;
            if (funSelection == 1)
            {
                long[] Data = InputData(2);
                nodRes = GCD.Euclidean(Data[0], Data[1]);
            }
            else if (funSelection == 2)
            {
                long[] Data = InputData(3);
                nodRes = GCD.Euclidean(Data[0], Data[1], Data[2]);
            }
            else if (funSelection == 3)
            {
                long[] Data = InputData(4);
                nodRes = GCD.Euclidean(Data[0], Data[1], Data[2], Data[3]);
            }
            else if (funSelection == 4)
            {
                long[] Data = InputData(5);
                nodRes = GCD.Euclidean(Data[0], Data[1], Data[2], Data[3], Data[4]);
            }
            else if (funSelection == 5)
            {
                long[] Data = InputData(2);
                nodRes = GCD.Stein(Data[0], Data[1]);
            }
            else if (funSelection == 6)
            {
                long[] Data = InputData(2);
                string value;
                nodRes = GCD.Stein(Data[0], Data[1], out value);
                Console.WriteLine("RunTime {0} milliseconds", value);
            }
            else if (funSelection == 7)
            {
                long[] Data = InputData(2);
                string value;
                nodRes = GCD.Euclidean(Data[0], Data[1], out value);
                Console.WriteLine("RunTime {0} milliseconds", value);
            }
            else Console.WriteLine("Было введено не корректное значение.");

            Console.WriteLine("НОД = {0}", nodRes);
            
            Console.WriteLine("Спасибо, что воспользовались нашей программой.");
            Console.ReadLine();

        }
    }
}
