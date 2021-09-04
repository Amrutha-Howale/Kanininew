using System;

namespace AssignmentClassWork
{
    class Program
    {
        void AverageNumbers()
        {
            int Num1, i, sum = 0, count = 0;
            Console.WriteLine("please enter the numberes");
            for (i = 0; i < 10; i++)
            {
                Num1 = Convert.ToInt32(Console.ReadLine());
                if (Num1 % 7 == 0)
                {
                    sum += Num1;
                    count++;
                }
            }
            Console.WriteLine("the average is " + sum / count);


        }
        void PrimeorNot()
        {
            Console.WriteLine("Enter a number you want to check");
            int Num3 = Convert.ToInt32(Console.ReadLine());
            int prime = 0;
            if (Num3 < 1)
                Console.WriteLine("Invalid");
            else
            {
                for (int i = 2; i < Num3; i++)
                {
                    if (Num3 % i == 0)
                    {
                        prime++;
                        break;
                    }
                }
                if (prime == 0)
                    Console.WriteLine("Its a prime");
                else
                    Console.WriteLine("Not a prime");
            }
        }



        void EvenandOdd()
        {
            bool flag = true;
            int even = 0, odd = 0;
            int Num3;
            while (flag)
            {
                Console.WriteLine("enter a number");
                // Num3 = Convert.ToInt32(Console.ReadLine());
                while (!int.TryParse(Console.ReadLine(), out Num3))
                {
                    Console.WriteLine("Invalid entry. Please enter again");
                }
                if (Num3 > 0)
                {
                    //Num3 = Convert.ToInt32(Console.ReadLine());
                    if (Num3 % 2 == 0)
                    {

                        Console.WriteLine("number is even");
                        even++;
                    }
                    else
                        Console.WriteLine("number is odd");
                    odd++;
                }
                else
                    flag = false;
            }
            Console.WriteLine($"Even number count = {even}, odd number count = {odd}");

        }


        void Primearray()
        {
            Console.WriteLine("Please Enter 10 numbers");
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 2; j < arr[i]; j++)
                {
                    if (arr[i] % j == 0) break;
                    else
                    {
                        Console.WriteLine("prime numbers are");
                        Console.WriteLine(arr[i]);
                        break;
                    }
                }
            }
        }
        //Take 11 numbers from user and find that one number which is not repeating
        //example
        //2,3,4,5,1,10,3,2,5,4,1
        //10
        void NonRepeating()
        {
            bool flag = false;
            Console.WriteLine("Enter 11 numbers separate by ',' :");
            string[] line = new string[11];
            line = Console.ReadLine().Split(",");
            int[] arr = new int[11];
            for (int i = 0; i < 11; i++)
            {
                arr[i] = Convert.ToInt32(line[i]);
            }
            for (int i = 0; i < 11; i++)
            {
                flag = false;
                for (int j = 0; j < 11; j++)
                {
                    if (arr[i] == arr[j] && i != j)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine($"Number which not repeat is: {arr[i]}");
                }
            }
        }

        void Findnextarray()
        {
            int[] num = new int[10];
            int j, count = 0;
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($" Please enter the numbers ");
                num[i] = Convert.ToInt32(Console.ReadLine());

            }
            for (int i = 0; i < num.Length - 1; i++)
            {
                for (j = i + 1; j < num.Length; j++)
                {
                    if (num[i] + 1 == num[j])
                    {
                        count++;
                        // Console.Write(num[i]+ " , ");

                    }
                }

            }

            Console.WriteLine("The word found repeated is " + count);
            // Console.WriteLine(names[names.Length - 1]);


        }

        void EvenandOddSort()
        {
            int i = 0;
            float median;
            int[] Num3 = new int[30];
            Console.Write("Enter the Number of values to be Sort : ");
            int n = Convert.ToInt16(Console.ReadLine());
            for (i = 1; i <= n; i++)
            {
                Console.Write("Enter the No " + i + ":");
                Num3[i] = Convert.ToInt16(Console.ReadLine());
                if (Num3[i] < 0)
                    break;
            }

            for (i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - 1; j++)
                {
                    if (Num3[j] > Num3[j + 1])
                    {
                        int temp = Num3[j];
                        Num3[j] = Num3[j + 1];
                        Num3[j + 1] = temp;
                    }
                }
            }
            if (n % 2 == 0)
            {
                median = (Num3[(n / 2) - 1] + Num3[(n / 2)]) / 2.0F;
            }
            else
            {
                median = Num3[(n / 2)];
            }
            //Display the Ascending values one by one  
            Console.Write("The values obtained after Ascending Sort : ");
            for (i = 1; i <= n; i++)
            {
                Console.Write(Num3[i] + " ");
            }
            Console.Write("Median is " + median);
            //Waiting for output
            Console.ReadKey();
        }

        void PrimeNumbersBetweenInverval()
        {
            int MinNum, MaxNum, i, j, flag;
            Console.WriteLine("Enter lower bound of " +
                              "the interval: ");
            MinNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter upper bound of the interval: ");
            MaxNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPrime numbers between {0} and {1} are: ", MinNum, MaxNum);

            // Traverse each number in the interval
            // with the help of for loop
            for (i = MinNum; i <= MaxNum; i++)
            {
                // Skip 0 and 1 as they are
                // neither prime nor composite
                if (i == 1 || i == 0)
                    continue;

                // flag variable to tell
                // if i is prime or not
                flag = 1;

                for (j = 2; j <= i / 2; ++j)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }

                // flag = 1 means i is prime
                // and flag = 0 means i is not prime
                if (flag == 1)
                    Console.WriteLine(i);
            }
        }

        void NumberReverseandSum()
        {
            int m = 0,sum=0;
            long[] CardNum = new long[50];
            Console.WriteLine("Enter the 16 digit card number ");
            for (int i = 0; i < CardNum.Length; i++)
            {
                CardNum[i] = long.Parse(Console.ReadLine());
            }
            for (int i = 0; i < CardNum.Length; i++)
            {
                Console.WriteLine(CardNum[i]);
            }
            Console.WriteLine("reverse of the entered digits is: ");
            for (int i = CardNum.Length - 1; i < 0; i--)
            {
                Console.WriteLine(CardNum[i]);
            }
            Console.WriteLine("The even place digits mutlipied by 2 : ");
            for (int i = CardNum.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0 || i == 0)
                {
                    CardNum[i] = CardNum[i] * 2;
                    Console.Write(CardNum[i]);
                }
                else
                {
                    Console.Write(CardNum[i]);
                }
            }
            Console.WriteLine("Sum of two digit Numbers present in array ");
            for (int i = CardNum.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0 || i == 0)
                {

                    if (CardNum[i] >= 10)
                    {
                        m =(int)(CardNum[i] % 10);
                        CardNum[i] = CardNum[i] / 10;
                        CardNum[i] = CardNum[i] + m;
                    }

                }

                Console.WriteLine(CardNum[i]);

            }
            Console.WriteLine("total sum is");
            for (int i = CardNum.Length - 1; i >= 0; i--)
            {
                sum = (int)(sum + CardNum[i]);
            }
            Console.WriteLine(sum);
        }

        void RemoveDuplicates()
        {
            int[] num = new int[10];
            int n = num.Length;
            for (int i = 0; i < n; i++)
            {
                num[i] = Convert.ToInt32(Console.ReadLine());
            }
            if (n > 0)
            {
                int[] temp = new int[n];
                int j = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    if (num[i] != num[i + 1])
                    {
                        temp[j++] = num[i];
                    }
                    temp[j++] = num[n - 1];
                }
                for (int i = 0; i < j; i++)
                    num[i] = temp[i];
                for (int i = 0; i < n; i++)
                    Console.Write(num[i] + " ");
            }
        }








        static void Main(string[] args)
        {
            //new Program().AverageNumbers();
            // new Program().PrimeorNot();
            //new Program().EvenandOdd();
            //new Program().Primearray();
            //new Program().NonRepeating();
            //new Program().Findnextarray();
            //new Program().EvenandOddSort();
            //new Program().PrimeNumbersBetweenInverval();
            new Program().RemoveDuplicates();
        }
    }
}


