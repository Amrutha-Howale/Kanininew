using System;

namespace ArrayOddNumberOfValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Num = new int[30];
            bool flag;

            Console.WriteLine("enter the array length");
            int MaxLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the array");
            for (int i = 0; i < MaxLength; i++)
            {
                Num[i] = Convert.ToInt32(Console.ReadLine());             
            }
            for (int i = 0; i < MaxLength; i++)
           {
                Console.WriteLine($"Num[{i}]={Num[i]}");
            }
           /* for (int i = 0; i < MaxLength; i++)
            {
                for (int j = 1; j < MaxLength; j++)
                {
                    if (Num[i] == Num[j + 1])
                    {
                        Console.WriteLine($"The elements at indexs {i} and {j+1} have values {Num[i]}");
                    }
                }  
            }*/
            for (int i = 0; i < MaxLength; i++)
            {
                flag = false;
                for (int j = 0; j < MaxLength -1; j++)
                {
                    if (Num[i] == Num[j] && i != j)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine($"unpaired is: {Num[i]}");
                }
            }
        }
    }
}
