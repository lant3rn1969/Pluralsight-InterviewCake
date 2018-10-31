using System;
using System.Linq;
using System.Collections.Generic;


namespace LanguageInternals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting\n");

            FindTheKthToLastNode(10);

            //InterviewCake.TestQueueWithTwoStacks();

            Console.WriteLine("\ndone");
            Console.ReadKey();
        }

        static void FindTheKthToLastNode(int k)
        {
            Random rand = new Random();
            int length = rand.Next(k, k + 30);
            Console.WriteLine($"Length is {length}");
            var rootNode = new LinkedListNode<int>(0);
            var linkedList = new MyLinkedList<int>(rootNode);
            for (int i = 1; i<=length; i++)
            {
                linkedList.AddNode(i);
            }
            Console.WriteLine($"Expected value is {length-k}");
            Console.WriteLine($"The value of the node {k} places before the last is {InterviewCake.FindKthToLastNode(k, linkedList).Value}");
        }

        static void FindTheRotationPoint()
        {
            var words = new string[]
            {
                "ptolemaic",
                "retrograde",
                "supplant",
                "undulate",
                "xenoepist",
                "asymptote",  // <-- rotates here!
                "babka",
                "banoffee",
                "engender",
                "karpatka",
                "othellolagkage",
            };

            Console.WriteLine($"The pivot point of {nameof(words)} is at index {InterviewCake.FindRotationIndexForStringArray(words)}.");
        }

        static void FindThePalindrome()
        {
            string input = "foofok";
            Console.WriteLine($"The string {input} can be a palindrome: {InterviewCake.CanBePalindrome(input)}");
        }

        static void FindTwoMovies()
        {
            int flightLength = 226;
            int[] movieLengths = new int[] { 90, 82, 97, 113, 101, 114, 89, 99, 107, 131, 113, 123, 119, 111 };
            var found = InterviewCake.CanFindTwoMovies(flightLength, movieLengths);
            Console.WriteLine(found);
            
        }
    }
}
