using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

internal class Program
{
    static void ListExample()
    {
        List<string> tasks = new List<string>();
        tasks.Add("Apple");
        tasks.Add("Banana");
        tasks.Add("Cherry");
        tasks.Add("Blueberry");
        Console.WriteLine("Contains Banana: " + tasks.Contains("Banana"));
        tasks[0] = "Avocado";
        tasks.Remove("Banana");
        tasks.RemoveAt(0);

        foreach (var fruit in tasks)
        {
            Console.WriteLine(fruit);
        }
        Console.ReadLine();
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}";
        }

        static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        
        static void Main(string[] args)
        {
            ListExample();

            Console.WriteLine("===List<Student>===");
            List<Student> students = new List<Student>
            {
                new Student(1, "Alice"),
                new Student(2, "Bob"),
                new Student(3, "Charlie")
            };
            students.Add(new Student(4, "David"));
            if (students.Count > 3)
            {
                students.RemoveAt(3);
            }
            PrintCollection(students);
            Console.WriteLine($"Count: {students.Count}");
            Console.WriteLine($"Exists: {students.Exists(s => s.Name == "Bob")}");

            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Alice", 25);
            ages.Add("Bob", 30);
            if (ages.ContainsKey("Alice"))
            {
                Console.WriteLine($"Alice's age: {ages["Alice"]}");
            }
            else
            {
                Console.WriteLine("Alice not found in the dictionary");
            }
        }
        static void StackExample()
        {
            Stack<string> history = new Stack<string>();
            history.Push("Page 1");
            history.Push("Page 2");
            Console.WriteLine("Current page: " + history.Peek());
            Console.WriteLine("Go back " + history.Pop());

            foreach (var page in history)
            {
                Console.WriteLine(page);
            }
        }
        static void QueueExample()
        {
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Download file");
            tasks.Enqueue("Scan file");
            Console.WriteLine("Next task: " + tasks.Peek());
            Console.WriteLine("Processing: " + tasks.Dequeue());

            foreach (var task in tasks)
            {
                Console.WriteLine(tasks);
            }
        }
        static void SortedListExample()
        {
            SortedList<int, string> students = new SortedList<int, string>();
            students.Add(101, "Nam");
            students.Add(102, "Lan");
            students.Add(103, "Hòa");
            students[102] = "Linh";

            if (students.ContainsKey(105))
            {
                Console.WriteLine("Student 105: " + students[105]);
            }
            students.Remove(101);

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Key}: {s.Value}");
            }
        }

        static void BT1()
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numbers.Add(i);
            }
            numbers.RemoveAll(n => n % 2 == 0);
            Console.WriteLine("Danh sách sau khi xóa số chẵn: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }
        static void BT2()
        {
            Dictionary<string, double> products = new Dictionary<string, double>()
            {
                {"Sữa", 20000 },
                {"Bánh mì", 15000 },
                {"Trứng", 25000 },
                {"Nước", 10000 },
                {"Gạo", 30000 }
            };
            products["Trứng"] = 28000;
            products.Remove("Nước");
            Console.WriteLine("Danh sách sản phẩm: ");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key}: {item.Value} VND");
            }
        }
        static void BT3()
        {
            Queue<string> customerQueue = new Queue<string>();
            customerQueue.Enqueue("Khách 1");
            customerQueue.Enqueue("Khách 2");
            customerQueue.Enqueue("Khách 3");
            customerQueue.Enqueue("Khách 4");
            customerQueue.Enqueue("Khách 5");

            customerQueue.Dequeue();
            customerQueue.Dequeue();

            Console.WriteLine("Khách hàng còn lại trong hàng đợi: ");
            foreach (string customer in customerQueue)
            {
                Console.WriteLine(customer);
            }
        }
        static void BT4()
        {
            Console.Write("Nhập chuỗi để kiểm tra Palindrome: ");
            string input = Console.ReadLine();
            Stack<char> charStack = new Stack<char>();

            foreach (char c in input)
            {
                charStack.Push(c);
            }
            string reversed = "";
            while (charStack.Count > 0)
            {
                reversed += charStack.Pop();
            }
            if (input == reversed)
            {
                Console.WriteLine("Chuỗi là Palindrome");
            }
            else
            {
                Console.WriteLine("Chuỗi không là Palindrome");

            }    
        }
    }
}