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
            List<int> intList = new List<int>();

            //Split the string based on the separators
            string[] commaSeparatedNumbers = userInput.Split(new string[] { ",", "\\n" }, StringSplitOptions.None);

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
                calculatedValue += parsedInteger;
            }

            Console.WriteLine("Calculated Numbers: " + string.Join(" + ", intList.ToArray()) + " = " + calculatedValue);

            //Return the calculated value
            return calculatedValue;
        }
    }
}
