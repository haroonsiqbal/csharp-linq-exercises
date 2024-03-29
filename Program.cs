﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = fruits.Where(n => n.StartsWith("L"));

            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(n => n).ToList();
            foreach (string word in descend)
            {
                Console.WriteLine(word);
            }
            // Build a collection of these numbers sorted in ascending order
            List<int> numbersup = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            List<int> numbersAscending = numbersup.OrderBy(n => n).ToList();
            foreach (int number in numbersAscending)
            {
                Console.WriteLine(number);
            }

            // Output how many numbers are in this list
            List<int> numbersCount = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            int countedNumbers = numbersCount.Count();
            Console.WriteLine(countedNumbers);

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            double sumPurchases = purchases.Sum();
            Console.WriteLine(sumPurchases);

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double maxPrice = prices.Max();
            Console.WriteLine(maxPrice);
            /*
            Store each number in the following List until a perfect square
            is detected.

            Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
                    List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 9, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            List<int> stopSquare = wheresSquaredo.TakeWhile(n => Math.Sqrt(n) % 1 != 0).ToList();
            foreach (int item in stopSquare)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            /*
            Given the same customer set, display how many millionaires per bank.
            Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

            Example Output:
            WF 2
            BOA 1
            FTB 1
            CITI 1
            */
            
            List<Customer> millionaires = customers.Where(n => n.Balance > 999999).ToList();

            var results = millionaires.GroupBy(
                n => n.Bank,
                n => n.Name,
                (key, g) => new {Bank = key, Name = g.ToList()}
            );
            
            foreach (var item in results) {
                //count how many name items appear in each bank and display the count
                int counted = item.Name.Count();
                Console.WriteLine($"{item.Bank} {counted}");
            }

        }
    }
}
