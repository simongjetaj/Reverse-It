using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var array = Enumerable.Range(1, 9).OrderBy(x => random.Next()).ToArray();
            Console.Write("Your random array is: ");
            PrintArray(array);
            Console.WriteLine();

            int number = 0;
            int count = 0;
            do
            {
                try
                {
                    Console.Write("Up to which number would you like to reverse the array? ");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (number > 0)
                    {
                        for (int i = 0; i < number / 2; i++)
                        {
                            int tmp = array[i];
                            array[i] = array[number - i - 1];
                            array[number - i - 1] = tmp;
                        }
                        PrintArray(array);
                        count++;
                    }
                }
            } while (!IsArraySorted(array) && count <= 16);

            if (count <= 16 && IsArraySorted(array))
            {
                Console.WriteLine("You Win in {0} move(s)!", count);
            }
            else
            {
                Console.WriteLine("You lose!");
                return;
            }
            
            Console.ReadKey();
        }
     }
     
        public static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");
        }

        public static bool IsArraySorted(int[] array)
        {
            for (int i = 1, arrLength = array.Length; i < arrLength; i++)
            {
                if (array[i - 1] > array[i])
                    return false;
            }
            return true;
        }
}
