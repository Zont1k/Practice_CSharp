using Lesson_4_Exceptions;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Write ur name: ");
            string name = ValidateStringNameInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur surname: ");
            string surname = ValidateStringSurnameInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur height: ");
            double height = ValidateDoubleTypes();

            Console.Write("Write ur birth day: ");
            int day = ValidateIntTypes(Console.ReadLine());

            Console.Write("Write ur birth month: ");
            int month = ValidateIntTypes(Console.ReadLine());

            Console.Write("Write ur birth year: ");
            int year = ValidateIntTypes(Console.ReadLine());
            DateTime birthday = new DateTime(year);

            Console.Write("Write ur city: ");
            string city = ValidateStringNameInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur country: ");
            string country = ValidateStringNameInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur phone number: ");
            string phoneNumber = Console.ReadLine();
            if (!Regex.IsMatch(phoneNumber, @"^\+?[0-9]{1,4}-?[0-9]{6,}$"))
            {
                throw new UserInputException("Invalid phone number format.\nCorrect form: +00 (000) 00 000 000");
            }

            Console.WriteLine();

            DisplayInformation(name, surname, height, day, month, year, city, country, phoneNumber);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new UserInputException("Invalid birthday date");
        }
        catch (UserInputException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static double ValidateDoubleTypes()
    {
        if (!double.TryParse(Console.ReadLine(), out double height) || height < 0)
        {
            throw new InvalidDoubleException("Error with height");
        }

        return height;
    }

    private static string ValidateStringNameInputUsingRegularExpression(string name)
    {
        if (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[A-Za-z\-']+$"))
        {
            throw new InvalidNameException("Invalid name format. The name should only contain letters, hyphens, and apostrophes.");
        }
        return name;
    }

    private static string ValidateStringSurnameInputUsingRegularExpression(string name)
    {
        if (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[A-Za-z\-']+$"))
        {
            throw new InvalidNameException("Invalid surname format. The name should only contain letters, hyphens, and apostrophes.");
        }
        return name;
    }

    private static int ValidateIntTypes(string value)
    {
        if (!int.TryParse(value, out int result) || result <= 0)
        {
            throw new InvalidIntException("Invalid format for the provided value. Please enter a valid positive integer.");
        }
        return result;
    }

    static void DisplayInformation(string name, string surname, double height, int day, int month, int year, string city, string country, string phoneNumber)
    {
        Console.WriteLine($"Ur name: {name}\nUr surname: {surname}\nUr height: {height}\n" +
                          $"Ur birth date: {day}.{month}.{year}\nUr city: {city}\nUr country: {country}\n" +
                          $"Ur phone number: {phoneNumber}");
    }
}
