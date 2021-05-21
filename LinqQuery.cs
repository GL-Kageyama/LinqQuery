using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqQuery
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var queryClass = new QueryClass();

            queryClass.QueryLength();

            queryClass.QueryLower();

            queryClass.QuerySelect();

            queryClass.QueryDeferred();

            // The contents of the list have been rewritten
            queryClass.QueryLength();

            queryClass.QueryImmediate();
        }
    }

    class QueryClass
    {
        List<string> citys = new List<string>
        {
            "Tokyo", "New Delhi", "Bangkok", "London", "Paris", 
            "Canberra", "Hong Kong", "Amsterdam", "Ankara", "Napoli", 
            "Nazca", "Nairobi", "Yangon", "Yalta", "Southsampton", 
            "San Diego", "Santos", "Seattle", "Jakarta", "Shanghai", 
        };

        // Extract city names of 5 characters or less
        public void QueryLength()
        {
            IEnumerable<string> query = citys.Where(s => s.Length <= 5);
            foreach (string s in query)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // Convert city names of 5 characters or less to lowercase
        public void QueryLower()
        {
            var query = citys.Where(s => s.Length <= 5)
                            .Select(s => s.ToLower());
            foreach (string s in query)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // Convert city name to number of characters
        public void QuerySelect()
        {
            var query = citys.Select(s => s.Length);
            foreach (var n in query)
                Console.WriteLine("{0} ", n);
            Console.WriteLine();
        }

        // Rename the 0th and 6th and delay execution
        public void QueryDeferred()
        {
            var query = citys.Where(s => s.Length <= 5);
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("- - -");

            citys[0] = "Kyoto";
            citys[6] = "Koube";
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine();
        }

        // Immediate execution (rename 0th and 6th)
        public void QueryImmediate()
        {
            var query = citys.Where(s => s.Length <= 5).ToArray();
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("- - -");

            // Since the query is executed when the ToArray function is called, 
            // the following transformations are not reflected
            citys[0] = "Gihu";
            citys[6] = "Salem";
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}