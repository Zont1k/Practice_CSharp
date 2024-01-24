using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Write ur name: ");
            string name = Console.ReadLine();

            if (int.TryParse(name, out _))
            {
                throw new Exception("U connot a int use");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name is empty or null");
            }

            Console.Write("Write ur surname: ");
            string surname = Console.ReadLine();
            if(string.IsNullOrEmpty(surname))
            {
                throw new Exception("Surname is empty or null");
            }

            Console.Write("Write ur height: ");
            if(!double.TryParse(Console.ReadLine(), out double height))
            {
                throw new Exception("Error with height");
            }    

            Console.Write("Write ur birth day: ");
            if(!int.TryParse(Console.ReadLine(), out int day))
            {
                throw new Exception("Error with day");
            }

            Console.Write("Write ur birth month: ");
            if(!int.TryParse(Console.ReadLine(), out int month))
            {
                throw new Exception("Error with month");
            }

            Console.Write("Write ur birth year: ");
            if(!int.TryParse(Console.ReadLine(), out int  year))
            {
                throw new Exception("Error with year");
            }

            Console.Write("Write ur city: ");
            string city = Console.ReadLine();
            if(string.IsNullOrEmpty(city))
            {
                throw new Exception("City is empty or null");
            }

            Console.Write("Write ur country: ");
            string country = Console.ReadLine();
            if( string.IsNullOrEmpty(country) )
            if( string.IsNullOrEmpty(country) )
            {
                throw new Exception("Country is empty or null");
            }

            Console.Write("Write ur phone number: ");
            string phoneNumber = Console.ReadLine();
            if(string.IsNullOrEmpty(phoneNumber)) 
            {
                throw new Exception("Phone number is empty or null");
            }

            Console.WriteLine();

            DisplayInformation(name, surname, height, day, month, year, city, country, phoneNumber);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DisplayInformation(string name, string surname, double height, int day, int month, int year, string city, string country, string phoneNumber)
    {
        Console.WriteLine($"Ur name: {name}\nUr surname: {surname}\nUr height: {height}\n" +
                          $"Ur birth date: {day}.{month}.{year}\nUr city: {city}\nUr country: {country}\n" +
                          $"Ur phone number: {phoneNumber}");
    }
}
