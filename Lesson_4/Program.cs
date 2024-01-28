using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

public class UserInputException : Exception
{
    public UserInputException(string message) : base(message) { }
}

public class InvalidNameException : UserInputException
{
    public InvalidNameException(string message) : base(message) { }
}

public class InvalidIntException : UserInputException
{
    public InvalidIntException(string message) : base(message) { }
}

public class InvalidDoubleException : UserInputException
{
    public InvalidDoubleException(string message) : base(message) { }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Write ur name: ");
            string name = ValidateStringInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur surname: ");
            string surname = ValidateStringInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur height: ");
            if(!double.TryParse(Console.ReadLine(), out double height) || height < 0)
            {
                throw new InvalidDoubleException("Error with height");
            }    

            Console.Write("Write ur birth day: ");
            int day = ValidateIntTypes(Console.ReadLine());


            Console.Write("Write ur birth month: ");
            int month = ValidateIntTypes(Console.ReadLine());


            Console.Write("Write ur birth year: ");
            int year = ValidateIntTypes(Console.ReadLine());

            Console.Write("Write ur city: ");
            string city = ValidateStringInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur country: ");
            string country = ValidateStringInputUsingRegularExpression(Console.ReadLine());

            Console.Write("Write ur phone number: ");
            string phoneNumber = Console.ReadLine();
            if (!Regex.IsMatch(phoneNumber, @"^\+?[0-9]{1,4}-?[0-9]{6,}$"))
            {
                throw new UserInputException("Invalid phone number format.\nCorrect form: +00 (000) 00 000 000");
            }

            try
            {
                DateTime birthday = new DateTime(year);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new UserInputException("Invalid birthday date");
            }

            Console.WriteLine();

            DisplayInformation(name, surname, height, day, month, year, city, country, phoneNumber);
        }
        catch(UserInputException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ValidateStringInputUsingRegularExpression(string name)
    {
        if (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[A-Za-z\-']+$"))
        {
            throw new InvalidNameException("Invalid name format. The name should only contain letters, hyphens, and apostrophes.");
        }
        return name;
    }

    static int ValidateIntTypes(string value)
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
