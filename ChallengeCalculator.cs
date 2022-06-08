using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            
            //Support custome delimiter
            var customdelimiter = "";

            if (userInput.Contains("//"))
            {
                int endindexofDelimiter = userInput.IndexOf("\\n");
                customdelimiter = userInput.Substring(2, (endindexofDelimiter - 2));

                //Check for any length delimiter
                if (customdelimiter.Contains("["))
                    customdelimiter = customdelimiter.Substring(1, (customdelimiter.Length - 2));
            }
            //Split the string based on the separators
            string[] calculatedNumbers = userInput.Split(new string[] { ",", "\\n", customdelimiter }, StringSplitOptions.None);

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
