using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace challenge_calculator
{
    public class StringCalculator
    {
        public int Add(string userInput)
        {
            int calculatedValue = 0;
            //List of all integers in the given string
            List<int> intList = new List<int>();

            //List for collecting negative numbers
            List<int> negativeNumberList = new List<int>();

            //Support custom delimiter
            string customdelimiterstring = "";

            string[] customeDelimiters;

            if (userInput.Contains("//"))
            {
                int endindexofDelimiter = userInput.IndexOf("\\n");
                customdelimiterstring = userInput.Substring(2, (endindexofDelimiter - 2));

                //Check for multiple any length delimiters
                if (customdelimiterstring.Contains("["))
                    customdelimiterstring = customdelimiterstring.Substring(1, (customdelimiterstring.Length - 2));
            }

            //Get all the custom delimiters and replace them with "-"
            customeDelimiters = customdelimiterstring.Split(new string[] { "][" }, StringSplitOptions.None);
            foreach(var delimiter in customeDelimiters)
            {
                userInput = userInput.Replace(delimiter, "-");
            }

            //Split the string based on the separators
            string[] calculatedNumbers = userInput.Split(new string[] { ",", "\\n", "-" }, StringSplitOptions.None);

            bool isNegativeNumber = false;
            foreach (var number in calculatedNumbers)
            { 
                int parsedInteger = 0;

                //Try parsing the string to an integer.
                if (!int.TryParse(number, out parsedInteger))
                {
                    //Convert the unparsed string to 0
                    parsedInteger = 0;
                }
                //if the integer value is greater than 1000, reset it to 0
                if (parsedInteger > 1000)
                    parsedInteger = 0;

                intList.Add(parsedInteger);
                //If the parsed integer value is negative, add it to the list.
                if (parsedInteger < 0)
                {
                    isNegativeNumber = true;
                    negativeNumberList.Add(parsedInteger);
                }
                calculatedValue += parsedInteger;
            }
            if (isNegativeNumber == true)
                throw new Exception("Negative numbers are not allowd: List of negative numbers = " + string.Join(" , ", negativeNumberList.ToArray()));

            Console.WriteLine("Calculated Numbers: " + string.Join(" + ", intList.ToArray()) + " = " + calculatedValue);

            //Return the calculated value
            return calculatedValue;
        }
    }
}
