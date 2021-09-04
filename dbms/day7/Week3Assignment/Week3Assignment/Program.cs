using System;

namespace Week3Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Num = new int[30];
            
            Console.WriteLine("enter the array length");
            int MaxLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the array");
            for (int i = 0; i < MaxLength; i++)
            {
                Num[i] = Convert.ToInt32(Console.ReadLine());
            }
            /*for (int i = 0; i < MaxLength; i++)
            {
                Console.WriteLine(Num[i] + " ");
            }*/
            Console.WriteLine("enter the number of times rotation");
            int k= Convert.ToInt32( Console.ReadLine());
            for(int i = 0; i < k; i++)
            {
                int temp;
                temp = Num[MaxLength - 1];
                for(int j = MaxLength - 1; j > 0; j--)
                {
                    Num[j] = Num[j - 1];
                }
                Num[0] = temp;
            }
            for (int i = 0; i <MaxLength; i++)
            {
                Console.WriteLine(Num[i]+" ");
            }
        }
    }
}
