using System;
using System.Collections.Generic;
using System.Text;

namespace UnderstandingArrayList
{
    class WorkingWithList
    {
        public void UnderstandingList() {
            List<int> numbers = new List<int>();
            numbers.Add(100);
            numbers.Add(200);
            numbers.Add(200);
            for (int i = 0; i<numbers.Count;i++)
            {
                numbers[i] *= 2;
                numbers[i] += i;
            }
            numbers.Add(340);
            Console.WriteLine("after all add");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            numbers.Remove(340);
            Console.WriteLine("After removing");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("does the list contain 202??"+numbers.Contains(202));
        }
        public void UnderstandinSets()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("jim");
            names.Add("tim");
            names.Add("lim");
            names.Add("rim");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("removing 'jim'");
            names.Remove("jim");
            Console.WriteLine("after removing");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("does the list contain jim??" + names.Contains("jim"));
        }
        public void UnderstandingLinkedLIst()
        {
            LinkedList<float> numbers = new LinkedList<float>();
            LinkedListNode<float> node = new LinkedListNode<float>(12.45f);
            numbers.AddFirst(node);
            numbers.AddAfter(node, 20);
            numbers.AddLast(30.4f);
            numbers.AddAfter(node, 22.2f);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        public void UnderstandingDictionary()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            students.Add(101, new Student(101, "jim", 90.8f));
            students.Add(102, new Student(102, "kim", 30.8f));
            students.Add(103, new Student(103, "rim", 10.8f));
            students.Add(104, new Student(104, "dim", 20.8f));
            foreach (var item in students.Keys)
            {
                Console.WriteLine("the key is"+item);
                Console.WriteLine(students[item]);
            }
            Console.WriteLine("Does the collection the key 103??"+students.ContainsKey(103));
            Console.WriteLine("check the value kim"+students.ContainsValue(new Student(102,"kim",88.2f)));
        }
        public void MoreOnEqual()
        {
            Student s1 = new Student(101, "jim", 90.8f);
            Student s2 = new Student(101, "jim", 90.8f);
            if(s1==s2)
            {
                Console.WriteLine("equals");
            }
            else
                Console.WriteLine("not equal");
        }
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float Amount { get; set; }
            public Student()
            {

            }
            public static bool operator ==(Student s1,Student s2)
            {
                if (s1.Id == s2.Id && s1.Name == s2.Name)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Student s1,Student s2)
            {
                if (s1.Id == s2.Id && s1.Name == s2.Name)
                    return true;
                else
                    return false;
            }

            public Student(int id, string name, float amount)
            {
                Id = id;
                Name = name;
                Amount = amount;
            }
            public override bool Equals(object obj)
            {
                Student s1, s2;
                s1 = this;
                s2 = (Student)obj;
                if (s1.Id == s2.Id && s1.Name == s2.Name)
                    return true;
                else
                    return false;
                
            }
            public override string ToString()
            {
                return Id+" "+Name+" "+Amount; 
            }
        }
    }
}
