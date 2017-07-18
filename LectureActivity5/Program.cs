using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LectureActivity5
{
    class Program
    {

        static int digCount = 0;
        static int uppCount = 0;
        static bool isPalin = false;
        static void digiCountMethod(Object analyse)
        {
            string analyseString = analyse.ToString();
            for (int i = 0; i < analyseString.Length; i++)
            {
                if (analyseString[i] >= 48 && analyseString[i] <= 57)
                    digCount++;
            }
        }
        static void isPalindromeMethod(Object analyse)
        {
            string analyseString = analyse.ToString();
            for (int i = 0, j = analyseString.Length - 1; i < analyseString.Length / 2; i++, j--)
            {
                if (analyseString[i] != analyseString[j])
                {
                    isPalin = false;
                    return;

                }

            }
            isPalin = true;
        }
        static void upperCountMethod(Object analyse)
        {
            string analyseString = analyse.ToString();
            for (int i = 0; i < analyseString.Length; i++)
            {
                if (analyseString[i] >= 65 && analyseString[i] <= 90)
                    uppCount++;
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            // Creating 3 threads          
            Thread digitCount = new Thread(digiCountMethod);
            Thread isPalindrome = new Thread(isPalindromeMethod);
            Thread upperCount = new Thread(upperCountMethod);

            // Start each thread
            digitCount.Start(str);            isPalindrome.Start(str);            upperCount.Start(str);

            // wait until all the threads are done
            digitCount.Join();            isPalindrome.Join();            upperCount.Join();

            // Display the string analysis results
            Console.WriteLine("The Digit count of the String: {0}", digCount);
            Console.WriteLine("The UpperCase letters count of the String: {0}", uppCount);
            if (isPalin)
                Console.WriteLine("The Given String is a Palindrome");
            else
                Console.WriteLine("The Given String is Not a Palindrome");
            Console.ReadKey();




        }



    }

}
