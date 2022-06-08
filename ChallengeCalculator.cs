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
            //Split the string based on the separators
            string[] commaSeparatedNumbers = userInput.Split(new string[] { ",", "\\n" }, StringSplitOptions.None);

            bool isNegativeNumber = false;
            foreach (var number in commaSeparatedNumbers)
            {
                int parsedInteger = 0;

                //Try parsing the string to an integer.
                if (!int.TryParse(number, out parsedInteger))
                {
                    //Convert the unparsed string to 0
                    parsedInteger = 0;
                }

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
