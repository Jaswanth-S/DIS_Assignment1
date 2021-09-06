using System;
using System.Collections.Generic;

namespace DIS_Assignment_1_Fall2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
           
            Console.WriteLine("The Final string after rotation is {0} ", rotated_string);

            Console.WriteLine();
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            try
            {   
                //In this problem I learned how to use Lists and how to solve a problem by dividing into two simple problems. 
                // write your code here
                // Storing all the vowels in the list 
                List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
                //count1 contains number of vowels in first half of the string
                //count2 contains number of vowels in first half of the string
                int count1 = 0, count2 = 0;
                //Loop to count the vowels in first half
                for (int i = 0; i < s.Length / 2; i++)
                {
                    if (vowels.IndexOf(s[i]) >= 0)
                    {
                        count1++;
                    }
                }
                //Loop to count the vowels in second half
                for (int i = s.Length / 2; i < s.Length; i++)
                {
                    if (vowels.IndexOf(s[i]) >= 0)
                    {
                        count2++;
                    }
                }
                //if both the counters are equal return true
                if (count1 == count2)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                //In this program I learned how to use arrays and got more clarity on Ascii
                // write your code here.
                //intializing an array of size 26, this is used to keep track of each English letter exists in the string or not
                int[] result = new int[26];
                foreach (var i in s)
                {
                    // getting the ascii value of each character in the string  
                    int index = (int)i - 97;
                    result[index]++;
                }

                // Now we have an array which contains the counters of each letter, so iterate and check if at any array element count is zero 

                bool temp = true;
                for (int i = 0; i < 26; i++)
                {
                    if (result[i] == 0)
                    {
                        temp = false;
                        break;
                    }
                }
                return temp;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                //In this program I learned how to use 2D array in C#    
                // write your code here
                int msum = 0;
                //maxsum or max_wealth
                int r = accounts.GetUpperBound(0);
                int c = accounts.GetUpperBound(1);
                //iterating through the rows
                for (int i = 0; i <= r; i++) {
                    int curCustSum = 0;
                    //iterating through the columns
                    for (int j = 0; j <= c; j++) {
                        curCustSum += accounts[i,j];
                    }
                    msum = Math.Max(msum, curCustSum);
                }
                return msum;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                //In this problem I learned foreach loop on string 
                // write your code here.
                int count = 0;
                //iterating through each character in stones
                foreach (char stone in stones)
                {
                    //checking if character is in jewels and incrementing the counter
                    if (jewels.Contains(stone)) 
                    { 
                        count++;
                    }
                }
                return count;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                //In this problem, I understood how to use character array 
                // write your code here.
                // Store index with the string char and return string based of indices char.
                
                    char[] charArr = new char[indices.Length];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        charArr[indices[i]] = s[i];
                    }
                return new string(charArr);
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            
            try
            {
                //In this problem I learned how to perform two loops and use if else condition inside the loops
                // creating target array
                int[] target = new int[nums.Length];
                // iterating through each element in nums array
                for (int i = 0; i < nums.Length; i++)
                {
                    //fitting the number in target array based on index
                    if (index[i] == i)
                    {
                        target[i] = nums[i];
                    }
                    else
                    {

                        for (int j = i; j > index[i]; j--)
                        {
                            target[j] = target[j - 1];
                        }
                        target[index[i]] = nums[i];
                    }
                }

                return target;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
