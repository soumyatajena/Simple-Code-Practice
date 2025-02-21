
using System.Globalization;
using System.Linq;
using System.Text;

class CodingPractice
{
    internal static void StringManipulation(string input)
    {
        string newInput = input;

        // 1. Reverse the string
        // string are immutatble , hence always convert them to char[] first to do any modification on it as char[] is mutatable
        char[] originalStr1 = input.ToCharArray();
        //Console.WriteLine(originalStr1);
        Array.Reverse(originalStr1);
        Console.WriteLine(originalStr1);

        // 2nd way

        char[] originalStr2 = input.ToCharArray();
        //Console.WriteLine("{0} : Length =>{1}", originalStr2, originalStr2.Length);
        for (int i = originalStr2.Length - 1; i >= 0; i--)
        {
            Console.Write(originalStr2[i]);
        }
        Console.WriteLine();

        // 2. Reverse the order of words in a given string
        string[] arrStr = input.Split(" ");
        string outputStr = "";
        for (int i = arrStr.Length - 1; i >= 0; i--)
        {
            outputStr = outputStr + arrStr[i] + " ";
        }
        Console.WriteLine($"Reverse the order of words of the given string - {input} => {outputStr}");

        // 3. Reverse each word in a given string
        string outputStr1 = "";
        for (int i = 0; i < arrStr.Length; i++)
        {
            var eachWord = arrStr[i].ToCharArray();
            Array.Reverse(eachWord);
            outputStr1 = outputStr1 + string.Join("", eachWord) + " ";
        }
        Console.WriteLine($"Reverse each word in the given string - {input} => {outputStr1}");

        // 4. Count the occurrence of each character in a string
        Dictionary<char, int> keyValuePairs = [];
        input = input.Replace(" ", "");
        originalStr2 = input.ToCharArray();
        for(int i=0;i<originalStr2.Length;i++)
        {
            if (!keyValuePairs.TryAdd(originalStr2[i], 1))
            {
                keyValuePairs[originalStr2[i]] += 1;
            }
        }
        Console.WriteLine($"Occurrence of each character in the string - {input} =>");
        foreach(var k in keyValuePairs)
        {
            Console.WriteLine(k.Key + ":" + k.Value);
        }
        keyValuePairs.Clear();

        // 5. Remove duplicate characters from a string
        Console.WriteLine($"Removal of duplicate characters from the string - {input} =>");
        for (int i = 0; i < originalStr2.Length; i++)
        {
            if (keyValuePairs.TryAdd(originalStr2[i], 1)) Console.Write(originalStr2[i]);
        }
        Console.WriteLine();

        // 6. Find all possible substring of a given string
        // abc => a b c ab bc abc
        Console.WriteLine($"Find all possible substrings in string {newInput} =>");
        for (int i = 0; i < newInput.Length; i++)
        {
            for (int j = i; j < newInput.Length; j++)
            {
                Console.Write(newInput.Substring(i, j - i + 1) + " ");
            }
        }
        //for (int i = 0; i < input.Length; i++)
        //{
        //    var subStr = new StringBuilder(input.Length - i);
        //    for (int j = i; j < input.Length; j++)
        //    {
        //        subStr.Append(input[j]);
        //        Console.Write(subStr + " ");
        //    }
        //}
        Console.WriteLine();

        // 7, Find all possible subsets of a given string
        // abc => "" a b ab c ac bc abc
        Console.WriteLine($"Find all possible subsets in string {input} =>");
        List<string> subsets = new List<string>();
        subsets.Add("");
        for (int i = 0; i < newInput.Length; i++)
        {
            int count = subsets.Count;
            for (int j = 0; j < count; j++)
            {
                subsets.Add(subsets[j] + newInput[i]);
            }
        }
        foreach (var sub in subsets)
        {
            Console.Write($"{{{sub}}}");
        }

        List<string> result = new List<string>();
        List<string> result1 = new List<string>();
        string arr = "abc";
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            { // 0,0 0,1 0,2 1,1 1,2 2,2
              // 0,1 0,2 0,3 1,2 1,3 2,3
                result.Add(arr.Substring(i, j-i+1));
            }
        }
        
        // 8.  Perform Left circular rotation of an array by 1 place
        // 1 2 3 4 5 => 2 3 4 5 1
        Console.Write($"Left circular rotation of '{newInput}' by 1 place =>");
        originalStr2 = newInput.ToCharArray();
        char temp = originalStr2[0]; // first element
        for(int i=1;i<= originalStr2.Length - 1; i++)
        {
            originalStr2[i - 1] = originalStr2[i];
        }
        originalStr2[^1] = temp;
        Console.Write(string.Join("",originalStr2));
        Console.WriteLine();

        // 9. Perform Right circular rotation of an array by 1 place
        // 1 2 3 4 5 => 5 1 2 3 4
        Console.Write($"Right circular rotation of '{newInput}' by 1 place =>");
        originalStr2 = newInput.ToCharArray();
        temp = originalStr2[^1]; // last element
        for(int i=1;i<originalStr2.Length-1;i++)
        {
            originalStr2[i]=originalStr2[i-1];
        }
        originalStr2[0] = temp;
        Console.Write(string.Join("", originalStr2));
        Console.WriteLine();

    }
    internal static bool PalindromeCheck(string input)
    {
        bool flag = false;
        char[] arr = input.ToCharArray();
        for (int i = 0, j = arr.Length - 1; i < arr.Length / 2; i++, j--)
        {
            if (arr[i] == arr[j]) flag = true;
            else
            {
                flag = false;
                break;
            }
        }
        return flag;

    }
    internal static int Fibonacci(int input)
    {
        // Non recursive way
        int index = 2, temp = 0;
        int first = 0, second = 1;
        //Console.Write($"Sequence =>");
        if (input < 2) Console.Write(input + " ");
        //Console.Write("0 1"+" ");
        while (index <= input)
        {
            temp = first + second;
            first = second;
            second = temp;
            //Console.Write(temp + " ");
            index++;
        }
        Console.WriteLine();
        Console.WriteLine($"Non-recursive Fibonacci Series upto {input} is {temp}");

        // Recursive way
        if (input < 2) return input;
        else
        {
            return (Fibonacci(input - 1) + Fibonacci(input - 2));
        }

    }
    internal static void PrimeCheck(int input)
    {
        // Prime Check
        bool prime = false;
        if (input == 0 || input == 1) prime = false;
        else if (input == 2) prime = true;
        else
        {
            for (int i = 2; i < input / 2; i++)
            {
                if (input % i == 0)
                {
                    prime = false;
                    break;
                }
                else prime = true;
            }
        }
        if(prime) Console.WriteLine($"{input} is a prime");
        else Console.WriteLine($"{input} is not a prime");

        // Find the sum of digits of the positive integer
        int sum = 0;
        if(input.ToString().Length == 1)
        {
            Console.WriteLine($"Sum of digits of {input} is {input}");
            return;
        }
        int[] arr = [.. input.ToString().ToCharArray().Select(x => int.Parse(x.ToString()))];
        foreach (var i in arr)
        {
            sum += i;
        }
        Console.WriteLine($"Sum of digits of {input} is {sum}");
    }
    internal static void ArrManipulation(string[] input)
    {
        // Find second largest integer in an array using only one loop
        int[] newInput = Array.ConvertAll(input, x => int.Parse(x));
        int max = 0;
        int secondMax = 0;
        for (int i = 1; i < newInput.Length; i++)
        { 
            if(newInput[i] > max)
            { 
                secondMax = secondMax < max ? secondMax : max;
                max = newInput[i];
            }
            else if (newInput[i] > secondMax && newInput[i]!=max)
            {
                secondMax = newInput[i];
            }
        }
        Console.WriteLine($"Second largest integer in the array => {secondMax}");

        // OR
        // 1 4 5 2 3 => 4
        newInput = [.. newInput.OrderDescending()]; // input.OrderDescending().ToArray();
        Console.WriteLine($"Second largest integer in the array using Array built-in functions => {newInput[1]}");
    }
    internal static void Arr2DManipulation(int[,] input)
    {   //  0 1 2
        //0[1,2,3] => [1,4,2,5,3,6]
        //1[4,5,6]
        Console.WriteLine("Yor 2D array is:");
        for (int i = 0; i < input.GetLength(0); i++)
        {
            for (int j = 0; j < input.GetLength(1); j++)
            {
                Console.Write(input[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        int[] list = new int[input.Length];
        int count = 0;
        for (int col = 0; col < input.GetLength(1); col++)
        {
            for(int row=0; row<input.GetLength(0);row++)
            {
                list[count++] = input[row, col];
            }
        }
        Console.WriteLine("1D array of 2D array is:");
        foreach (var i in list)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

class Program()
{
    private static bool wantToContinue = true;

    public static void Main()
    {
        do
        {
            Console.WriteLine("Options available for you to choose:");
            Console.WriteLine("\n 1. String Manipulation \n 2. Palindrome \n 3. Fibonacci \n 4. Prime \n 5. 1D Array \n 6. 2D Array");
            Console.WriteLine("Enter your option choice:");
            var op = int.TryParse(Console.ReadLine(), out int num);
            if (op)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Enter your choice of string :");
                        var str1 = Console.ReadLine();
                        CodingPractice.StringManipulation(str1);
                        break;
                    case 2:
                        Console.WriteLine("Enter your choice of input for Palindrome check :");
                        var str2 = Console.ReadLine();
                        bool response = CodingPractice.PalindromeCheck(str2);
                        if (response) Console.WriteLine($"{str2} is a palindrome");
                        else Console.WriteLine($"{str2} is not palindrome");
                        break;
                    case 3:
                        Console.WriteLine("Enter how long you want your Fibonnaci series to be (n > 0):");
                        var str3 = Console.ReadLine();
                        _ = int.TryParse(str3, out int fib);
                        if (fib >= 0)
                        {
                            int result = CodingPractice.Fibonacci(fib);
                            Console.Write($"Recursive way - Fibonacci Series of {fib} => {result}");
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Please enter a correct positive integer > 0");
                        break;
                    case 4:
                        Console.WriteLine("Enter a positive integer:");
                        _ = int.TryParse(Console.ReadLine(), out int inpNum);
                        if(inpNum > 0) CodingPractice.PrimeCheck(inpNum);
                        else Console.WriteLine("Please enter a correct positive integer > 0");
                        break;
                    case 5:
                        Console.WriteLine("Enter your array (DELIMITER : SPACE) :");
                        string[] arr = Console.ReadLine().Split(" ");
                        CodingPractice.ArrManipulation(arr);
                        break;
                    case 6:
                        int[,] array2D = new int[2, 3];
                        Console.WriteLine("Enter your 2D integer array:");
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Console.Write($"Enter element at position [{j},{i}]: ");
                                array2D[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        CodingPractice.Arr2DManipulation(array2D);
                        break;
                    default:
                        Console.WriteLine("In future will try to add that number.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer");
            }
            Console.Write("Do you wish to contine ? (Y/N) : ");
            wantToContinue = Console.ReadLine().ToLower() == "y" ? true : false;
            Console.WriteLine();
        }
        while (wantToContinue);
    }
}