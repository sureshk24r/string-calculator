using System;

namespace challenge_calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Prompt for user input
            Console.WriteLine("Please enter the numbers and press enter. To exit press CTRL + C");
            //Get User Input
            string userInput;
            do
            {
                userInput = "";
                userInput = Console.ReadLine();
                Console.WriteLine("User Input String : " + userInput);
                StringCalculator stringCalculator = new StringCalculator();
                int returnvalue = 0;
                //Call the Add function to add the numbers and print the calculated value.
                returnvalue = stringCalculator.Add(userInput);
                Console.WriteLine("Calculated Value : " + returnvalue);
            } while (userInput != null);
        }
    }
}
