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
            string name = ValidateStringTypes(Console.ReadLine());

            Console.Write("Write ur surname: ");
            string surname = ValidateStringTypes(Console.ReadLine());

            Console.Write("Write ur height: ");
            if(!double.TryParse(Console.ReadLine(), out double height) || height < 0)
            {
                throw new Exception("Error with height");
            }    

            Console.Write("Write ur birth day: ");
            int day = ValidateIntTypes(Console.ReadLine());


            Console.Write("Write ur birth month: ");
            int month = ValidateIntTypes(Console.ReadLine());


            Console.Write("Write ur birth year: ");
            int year = ValidateIntTypes(Console.ReadLine());

            try
            {
                DateTime birthday = new DateTime(year);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception("Invalid birthday date");
            }

            Console.Write("Write ur city: ");
            string city = ValidateStringTypes(Console.ReadLine());

            Console.Write("Write ur country: ");
            string country = ValidateStringTypes(Console.ReadLine());

            Console.Write("Write ur phone number: ");
            string phoneNumber = Console.ReadLine();
            if (!Regex.IsMatch(phoneNumber, @"^\+?[0-9]{1,4}-?[0-9]{6,}$"))
            {
                throw new Exception("Invalid phone number format.\nCorrect form: +00 (000) 00 000 000");
            }

            Console.WriteLine();

            DisplayInformation(name, surname, height, day, month, year, city, country, phoneNumber);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ValidateStringTypes(string name)
    {
        if (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, @"^[A-Za-z\-']+$"))
        {
            throw new Exception("Invalid name format.");
        }
        return name;
    }

    static int ValidateIntTypes(string value)
    {
        if (!int.TryParse(value, out int result) || result <= 0)
        {
            throw new Exception("Invalid types format.");
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
