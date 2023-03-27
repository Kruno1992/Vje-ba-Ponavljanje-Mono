using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Vjezba_ime_prezime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> scores = new List<int>();
            List<double> numbers = new List<double>();
            bool doneEnteringScores = false;
            bool doneEnteringNumbers = false;


            while (!doneEnteringScores)
                {
                    Console.WriteLine("Pick one of the options:");
                    Console.WriteLine("");
                    Console.WriteLine("1. Odd or even!");
                    Console.WriteLine("2. Quadratic equation!");
                    Console.WriteLine("3. Average score!");
                    Console.WriteLine("4. Magic numbers and magic sum!");
                    Console.WriteLine("5. Lets check Lotto numbers! Only for Lotto 7 of 45!");
                    Console.WriteLine("6. Lotto 6 of 49 ticket! Get lucky!");
                    Console.WriteLine("7. Persons and Statistics");
                    Console.WriteLine("8. Option #8");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Enter a number: ");
                            string numberInput = Console.ReadLine();
                            int number = int.Parse(numberInput);

                            if (number % 2 == 0)
                            {
                                Console.WriteLine("The number you entered is even.");
                            }
                            else
                            {
                                Console.WriteLine("The number you entered is odd.");
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu....");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "2":
                            Console.WriteLine("Enter a, b, and c for the quadratic equation:");
                            Console.Write("a: ");
                            double a = double.Parse(Console.ReadLine());
                            Console.Write("b: ");
                            double b = double.Parse(Console.ReadLine());
                            Console.Write("c: ");
                            double c = double.Parse(Console.ReadLine());

                            double discriminant = b * b - 4 * a * c;

                            if (discriminant < 0)
                            {
                                Console.WriteLine("The equation has no real roots.");
                            }
                            else if (discriminant == 0)
                            {
                                double x = -b / (2 * a);
                                Console.WriteLine("The equation has one root: {0}", x);
                            }
                            else
                            {
                                double x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                                double x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                                Console.WriteLine("The equation has two roots: {0} and {1}", x1, x2);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu....");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "3":
                            int score = 0;
                            while (score != -1)
                            {
                                Console.WriteLine("Enter a score from 0 to 5, or enter 0 to finish:");
                                string scoreInput = Console.ReadLine();
                                score = int.Parse(scoreInput);

                                if (score == 0)
                                {
                                    break;
                                }

                                if (score < 0 || score > 5)
                                {
                                    Console.WriteLine("Invalid input. Please enter a score from 0 to 5.");
                                    continue;
                                }

                                scores.Add(score);
                            }

                            double averageScore = scores.Average();
                            int roundedAverageScore = (int)Math.Round(averageScore);
                            Console.WriteLine("The average score is: {0}", roundedAverageScore);

                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu....");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    case "4":
                        while (!doneEnteringNumbers)
                        {
                            Console.WriteLine("Enter the number of numbers you want to add:");
                            int n = int.Parse(Console.ReadLine());

                            List<double> inputNumbers = new List<double>();

                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("Enter a number:");
                                double inputNumber = double.Parse(Console.ReadLine());
                                inputNumbers.Add(inputNumber);
                            }

                            double sum = 0;

                            if (inputNumbers.Count >= 2)
                            {
                                sum = inputNumbers[inputNumbers.Count - 1] + inputNumbers[inputNumbers.Count - 2];
                            }

                            int lastTwoDigitsSum = (int)sum % 100;

                            if (lastTwoDigitsSum == 0)
                            {
                                Console.WriteLine("The sum of the last two numbers is {0}. The sum of the last two digits is 0, please try again.", sum);
                                inputNumbers.Clear();
                            }
                            else
                            {
                                Console.WriteLine("The sum of the last two numbers is {0}. The sum of the last two digits is {1}.", sum, lastTwoDigitsSum);
                                inputNumbers.Clear();
                                doneEnteringNumbers = true;
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu....");
                        Console.ReadKey();
                        Console.Clear();
                        doneEnteringNumbers = false;
                        break;

                    case "5":
                        Random rand = new Random();
                        List<int> lottoNumbers = new List<int>();

                        while (lottoNumbers.Count < 7)
                        {
                            int newNumber = rand.Next(1, 46);
                            if (!lottoNumbers.Contains(newNumber))
                            {
                                lottoNumbers.Add(newNumber);
                            }
                        }

                        Console.WriteLine("The winning lotto numbers are:");
                        foreach (int lnumber in lottoNumbers)
                        {
                            Console.Write(lnumber + " ");
                        }
                        Console.WriteLine();

                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu....");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        case "6":
                        string filePath = @"C:\Users\Krunoslav\Desktop\Vjezba 27.3 Console App\lotto_ticket.txt";

                        List<int> LOnumbers = new List<int>();
                        for (int i = 1; i <= 49; i++)
                        {
                            LOnumbers.Add(i);
                        }

                        //// Shuffle the list of numbers
                        //Random rando = new Random();
                        //for (int i = 0; i < LOnumbers.Count; i++)
                        //{
                        //    int j = rando.Next(i, LOnumbers.Count);
                        //    int temp = LOnumbers[i];
                        //    LOnumbers[i] = LOnumbers[j];
                        //    LOnumbers[j] = temp;
                        //}

                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            int index = 0;
                            for (int i = 0; i < 7; i++)
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    if (index >= 49)
                                    {
                                        break;
                                    }
                                    writer.Write("{0,2} ", LOnumbers[index]);
                                    index++;
                                }
                                writer.WriteLine();
                            }
                        }

                        Console.WriteLine("LOTTO ticket generated and saved to {0}", filePath);
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu....");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        Console.WriteLine("You selected Option #7");

                        List<Person> people = new List<Person>();
                        for (int i = 0; i < 4; i++)
                        {
                            Console.WriteLine($"Person {i + 1}:");
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Surname: ");
                            string surname = Console.ReadLine();
                            Console.Write("Date of Birth (YYYY-MM-DD): ");
                            DateTime dateOfBirth;
                            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                            {
                                Console.WriteLine("Invalid date format. Please try again.");
                                Console.Write("Date of Birth (YYYY-MM-DD): ");
                            }
                            Console.Write("Sex (M/F): ");
                            string sex = Console.ReadLine();
                            while (sex != "M" && sex != "F")
                            {
                                Console.WriteLine("Invalid sex. Please try again.");
                                Console.Write("Sex (M/F): ");
                                sex = Console.ReadLine();
                            }
                            Person person = new Person(name, surname, dateOfBirth, sex);
                            people.Add(person);
                        }

                        Statistics statistics = new Statistics(people);

                        Console.WriteLine($"Eldest person: {statistics.GetEldestPerson().Name} {statistics.GetEldestPerson().Surname}");
                        Console.WriteLine($"Youngest person: {statistics.GetYoungestPerson().Name} {statistics.GetYoungestPerson().Surname}");
                        Console.WriteLine($"Number of males: {statistics.GetNumberOfMales()}");
                        Console.WriteLine($"Number of females: {statistics.GetNumberOfFemales()}");
                        Console.Write("Number of people born before year 2000: ");
                        Console.WriteLine(statistics.GetNumberOfPeopleBornBeforeYear(2000));

                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to menu....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
                            Console.WriteLine("You selected Option #8");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to menu....");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "0":
                            Console.WriteLine("Exiting...");
                            return;

                    }
                }
            }
        }
    }
