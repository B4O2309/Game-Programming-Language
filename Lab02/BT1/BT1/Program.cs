using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập số lượng phần tử n > 0: ");
        int n = int.Parse(Console.ReadLine()); 

        List<int> numbers = new List<int>();
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            numbers.Add(rnd.Next(100));
        }

        Console.WriteLine("Dãy số ngẫu nhiên: ");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }

        numbers.Sort();
        Console.WriteLine("\nDãy sau khi sắp xếp tăng dần: ");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }    
    }
}