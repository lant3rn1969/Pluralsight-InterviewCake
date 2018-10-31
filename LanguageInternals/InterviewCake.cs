using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInternals
{
    public class InterviewCake
    {
        public static bool CanFindTwoMovies(int flightLength, int[] movieLengths)
        {
            List<int> movies = new List<int>(movieLengths.Length);
            int halfTheFlight = flightLength / 2;
            int diff = halfTheFlight - movieLengths[0];
            int firstMoviePosition = 0;
            int firstMovieLength = 0;
            for (int i = 0; i < movieLengths.Length; i++)
            {
                int currMovieLength = movieLengths[i];
                int temp = halfTheFlight - currMovieLength;
                if (Math.Abs(temp) < Math.Abs(diff))
                {
                    firstMoviePosition = i;
                    firstMovieLength = currMovieLength;
                    diff = temp;
                }
                movies.Add(movieLengths[i]);
            }

            if ((firstMovieLength - halfTheFlight) == 0)
            {
                var lookup = movies.ToLookup(m => m);
                if (lookup.Contains(firstMovieLength) && lookup[firstMovieLength].Count() > 1)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CanBePalindrome(string input)
        {
            if (input == null) throw new ArgumentNullException();
            if (input.Length == 0 || input.Length == 1) return false;
            var dict = new Dictionary<char, int>(input.Length);

            foreach (char c in input.ToCharArray())
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c] += 1;
                }
            }

            var hasOddNumber = false;
            foreach (char c in dict.Keys)
            {
                int count = dict[c];
                if ((count % 2) != 0)
                {
                    if (hasOddNumber) return false;
                    else hasOddNumber = true;
                }
            }

            return true;
        }

        public static int[] SortScores(int[] unorderedScores, int highestPossibleScore)
        {
            var list = new SortedList<int, int>(unorderedScores.Length);

            foreach (int score in unorderedScores)
            {
                list.Add(score, score);
            }

            return list.Values.ToArray();
        }

        public static int FindRotationIndexForStringArray(string[] inputArray)
        {
            int length = inputArray.Length;
            if (length == 0 || length == 1) return 0;
            char prevFirstLetter = '\x0000';

            for (int i = 0; i < length; i++)
            {
                var firstLetter = inputArray[i].ToCharArray()[0];
                if (firstLetter.CompareTo(prevFirstLetter) < 0)
                {
                    return i;
                }
                prevFirstLetter = firstLetter;
            }

            throw new ArgumentOutOfRangeException("Input array does not have a pivot point");
        }

        public static void TestQueueWithTwoStacks()
        {
            var q = new Queue();
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }

            Console.WriteLine("expecting \"0...1...2...3...\"");

            Console.WriteLine();
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");
            Console.WriteLine();

            for (int i = 11; i < 15; i++)
            {
                q.Enqueue(i);
            }

            Console.WriteLine("expecting \"4...5...6...7...\"");
            Console.WriteLine();
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");
            Console.Write(q.Dequeue() + "...");

        }

        public static LinkedListNode<int> FindKthToLastNode(int k, MyLinkedList<int> linkedList)
        {
            if (k < 1) return null;
            if (linkedList == null) throw new ArgumentNullException($"{nameof(linkedList)} list can't be null");
            var length = 1;
            var currnode = linkedList.RootNode;
            while (currnode.Next != null)
            {
                currnode = currnode.Next;
                length++;
            }

            int counter = 1;
            int kThNodePosition = length - k;
            currnode = linkedList.RootNode;
            while (currnode.Next != null)
            {
                if (counter == kThNodePosition)
                    break;

                counter++;
                currnode = currnode.Next;
            }

            return currnode;
        }
    }
}
