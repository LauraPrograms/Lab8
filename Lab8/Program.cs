using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        { //write a program that willrecognize the invalid input when the user requrest info about students in a class
          //this app will do: rpovide info about students in a class, prompt the user to ask about a particular student, give proper responses according to user-submitted info, ask if user would like to learn about another student

            string[] studentArray = new string[] { "Liam", "Emma", "Noah", "Olivia", "William", "Ava", "Logan", "Isabella", "Sophia", "Benjamin", "Mason", "Charlotte", "Amelia", "Elijah", "Jacob" };  //make sure to add the quotes for strings
            string[] studentHometown = new string[] { "Miami", "Columbus", "San Degio", "Tempe", "Reno", "Monroe", "Pittsburgh", "Denver", "Atlanta", "Cario", "Santa Fe", "Boston", "El Paso", "Buffalo", "Chicago" };
            string[] studentFavoriteFood = new string[] { "Apple Pie", "Veggie Burger", "Clam Chowder", "Bagel and Lox", "Pepperoni Pizza", "Texas Barbecue", "Tacos", "Sushi", "Stir Fry", "Pot roast", "Pad Thai", "Butternut Squash Chili", "Shepherd's Pie", "Minestrone soup", "Lasagna" };
            string student = "";
            string hometown = "";
            string food = "";
            string answer = "";
            int studentID = 0;
            int userStudent = 0;
            bool runningStudent = true;
            while (runningStudent)

            {
                bool studentPicker = true;
                while (studentPicker)
                {
                    try
                    {
                        Console.WriteLine("Which student would you like to learn more about? (please enter a number between 1-15)");
                        userStudent = int.Parse(Console.ReadLine());//this will account for the student is out of range exception
                        studentID = userStudent - 1; //this is to line up the array with their number option
                        student = studentArray[studentID];
                        Console.WriteLine("Student " + userStudent  + " is " + student + ".");
                        studentPicker = false;
                    }
                    catch (IndexOutOfRangeException e)//this one deals with arrays out of range (so we have an array for food and they called for age.
                    {
                        Console.WriteLine(e.Message);
                        studentPicker = true;
                    }
                    catch (FormatException e1)//this will work great with Parsing failing.
                    {
                        Console.WriteLine(e1.Message);
                        studentPicker = true;
                    }
                }

                bool run = true;
                while (run)
                {
                    Console.WriteLine("What would you like to know about " + student + "? (enter in \"hometown\" or \"favorite food\")");
                    string userInterest1 = Console.ReadLine().ToLower();
                    if (userInterest1 == "hometown")
                    {
                        hometown = studentHometown[studentID];
                        Console.WriteLine(student + " is from " + hometown + ".");
                        run = false;
                    }
                    else if (userInterest1 == "favorite food")
                    {
                        food = studentFavoriteFood[studentID];
                        Console.WriteLine(student + "'s favorite food is " + food + ".");
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("That data does not exist. Please try again.");
                        run = true;
                    }
                }
                runningStudent = AskingForAnother();

            }
        }//end of Main method

        public static bool AskingForAnother()
        {
            string answer;
            bool result = true;
            while (result)
            {
                Console.WriteLine("Would you like too know about another student? (enter yes or no)");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    return true;
                }
                else if (answer == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter \"yes\" or \"no\"");
                    return AskingForAnother();
                }
            }
            return result;
        }

    }
}

