using AutoFixture;
using Lesson_6_StudentProperties;
using Spectre.Console;
using System.Text.Json;

class Program
{
    private static readonly Fixture fixture = new Fixture();
    static void Main(string[] args)
    {
       var students = CreateStudentList();

        var filteredStudents = FilterStudentsByFirstLetter(students);

        var orderedStudents = OrderStudentsByNameAndDateOfBirth(students);

        var uniqueStudents = RemoveDuplicates(students);

        var earliestDateOfBirth = FindEarliestDateOfBirth(students);

        var firstElement = ReturnFirstElement(students);

        var lastElement = ReturnLastElement(students);

        var elementAtStudent = ElementAtMethod(students);

        var concatenatedLists = ConcatListsMethod(students);

        var skippedElements = SkipElements(students);

        var tookStudentElements = TakeElements(students);

        var zippedElements = ZipElements(students);

        var singleOrDefault = PrintSingleStudent(students);

        var maxElementInStudentList = FoundMaxDateOfBirth(students);

        var minElementInStudentList = FoundMinDateOfBirth(students);

        var countStudentsElementsList = CountElementsInStudentList(students);

        var intersectElementsInStudentList = IntersectElementsInStudentList(students);

        var unionElementsInStudentList = UnionElementsInStudentList(students);

        var exceptElementsInStudentList = ExceptElementsInStudentList(students);

        var containsMethod = ContainsMethod(students, "Oleksii");

        var allStudentsIsAdult = AreAllStidentsAdult(students);

        var reverseList = ReverseList(students);

        var toLookUp = ToLookUpMethod(students);

        var groupedStudents = GroupByMethod(students);

        var joinListStudents = JoinMethod(students);

        var thenByDescending = ThenByDescendingMethod(students);

        var thenBy = ThenByMethod(students);

        var orderByDescending = OrderByDescendingMethod(students);

        AnsiConsole.MarkupLine("[red]1) FilterStudentsByFirstLetter[/]");
        PrintSerializedObject(filteredStudents);
        AnsiConsole.MarkupLine("[red]2) OrderStudentsByNameAndDateOfBirth[/]");
        PrintSerializedObject(orderedStudents);
        AnsiConsole.MarkupLine("[red]3) RemoveDuplicates[/]");
        PrintSerializedObject(uniqueStudents);
        AnsiConsole.MarkupLine("[red]4) FindEarliestDateOfBirth[/]");
        PrintSerializedObject(earliestDateOfBirth);
        AnsiConsole.MarkupLine("[red]5) ReturnFirstElement[/]");
        PrintSerializedObject(firstElement);
        AnsiConsole.MarkupLine("[red]6) ReturnLastElement[/]");
        PrintSerializedObject(lastElement);
        AnsiConsole.MarkupLine("[red]7) ElementAtStudent[/]");
        PrintSerializedObject(elementAtStudent);
        AnsiConsole.MarkupLine("[red]8) ConcatListsMethod[/]");
        PrintSerializedObject(concatenatedLists);
        AnsiConsole.MarkupLine("[red]9) SkipElements[/]");
        PrintSerializedObject(skippedElements);
        AnsiConsole.MarkupLine("[red]10) TakeElements[/]");
        PrintSerializedObject(tookStudentElements);
        AnsiConsole.MarkupLine("[red]11) ZipElements[/]");
        PrintSerializedObject(zippedElements);
        AnsiConsole.MarkupLine("[red]12) PrintSingleStudent[/]");
        PrintSerializedObject(singleOrDefault);
        AnsiConsole.MarkupLine("[red]13) FoundMaxDateOfBirth[/]");
        PrintSerializedObject(maxElementInStudentList);
        AnsiConsole.MarkupLine("[red]14) FoundMinDateOfBirth[/]");
        PrintSerializedObject(minElementInStudentList);
        AnsiConsole.MarkupLine("[red]15) CountStudentsElementsList[/]");
        PrintSerializedObject(countStudentsElementsList);
        AnsiConsole.MarkupLine("[red]16) IntersectElementsInStudentList[/]");
        PrintSerializedObject(intersectElementsInStudentList);
        AnsiConsole.MarkupLine("[red]17) UnionElementsInStudentList[/]");
        PrintSerializedObject(unionElementsInStudentList);
        AnsiConsole.MarkupLine("[red]18) ExceptElementsInStudentList[/]");
        PrintSerializedObject(exceptElementsInStudentList);
        AnsiConsole.MarkupLine("[red]19) ContainsMethod[/]");
        PrintSerializedObject(containsMethod);
        AnsiConsole.MarkupLine("[red]20) AllCheckElements[/]");
        PrintSerializedObject(allStudentsIsAdult);
        AnsiConsole.MarkupLine("[red]21) ReverseMethod[/]");
        PrintSerializedObject(reverseList);
        AnsiConsole.MarkupLine("[red]22) ToLookUpMethod[/]");
        PrintSerializedObject(toLookUp);
        AnsiConsole.MarkupLine("[red]23) GroupByMethod[/]");
        PrintSerializedObject(groupedStudents);
        AnsiConsole.MarkupLine("[red]24) JoinMethod[/]");
        PrintSerializedObject(joinListStudents);
        AnsiConsole.MarkupLine("[red]25) ThenByDescendingMethod[/]");
        PrintSerializedObject(thenByDescending);
        AnsiConsole.MarkupLine("[red]26) ThenByMethod[/]");
        PrintSerializedObject(thenBy);
        AnsiConsole.MarkupLine("[red]27) OrderByDescendingMethod[/]");
        PrintSerializedObject(orderByDescending);
    }

    // Method for creating a second list of students
    private static List<Student> CreateStudentList()
    {
        var secondList = new List<Student>();

        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondList.Add(student);
        }
        return secondList;
    }

    static void PrintSerializedObject(object obj)
    {
        // Serialization options: set formatting for JSON minification
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        // Serialize an object in JSON format
        string jsonString = JsonSerializer.Serialize(obj, options);

        // Output JSON string to console
        Console.WriteLine($"\n{jsonString}");
    }

    private static IEnumerable<Student> FilterStudentsByFirstLetter(List<Student> students)
    {
        return students
            .Where(s => char.IsLetter(s.FirstName[0]))
            .OrderBy(s => s.FirstName);
    }

    private static IEnumerable<Student> OrderStudentsByNameAndDateOfBirth(List<Student> students)
    {
        return students
            .OrderBy(s => s.FirstName)
            .ThenBy(s => s.DateOfBirth);
    }

        // The standard equality comparator compares objects by reference, not by content. This means that if two objects
        // refer to the same location in memory (have the same reference), then they will be considered the same and one of
        // them will be deleted as a duplicate.
    private static IEnumerable<Student> RemoveDuplicates(List<Student> students)
    {
        return students.Distinct();
    }

    private static DateTime FindEarliestDateOfBirth(List<Student> students)
    {
        return students
            .Select(s => s.DateOfBirth)
            .Aggregate((earliest, next) => next < earliest ? next : earliest);
    }

    // Returning the first element from the list of students
    private static Student ReturnFirstElement(List<Student> students)
    {
        return students.FirstOrDefault();
    }

    // Returning the last element from the list of students
    private static Student ReturnLastElement(List<Student> students)
    {
        return students.LastOrDefault();
    }

    // Getting an element by index
    private static Student ElementAtMethod(List<Student> students)
    {
        return students.ElementAt(4);
    }

    // Concatenating two lists of students
    private static IEnumerable<Student> ConcatListsMethod(List<Student> students)
    {
        var secondListOfStudents = CreateStudentList();

        return secondListOfStudents.Concat(students);
    }

    // Skipping a specified number of elements in the list
    private static IEnumerable<Student> SkipElements(List<Student> students)
    {
        return students.Skip(3);
    }

    // Taking a specified number of elements from the beginning of the list
    private static IEnumerable<Student> TakeElements(List<Student> students)
    {
        return students.Take(2);
    }

    // Creating pairs from elements of two lists
    private static IEnumerable<(Student, Student)> ZipElements(List<Student> students)
    {
        var secondListOfStudents = CreateStudentList();

        return students.Zip(secondListOfStudents, (first, second) => (first, second));
    }

    // Printing information about a single student with a specified name
    private static IEnumerable<Student> PrintSingleStudent(List<Student> students)
    {
        yield return students.SingleOrDefault(x => x.FirstName == "Student");
    }

    // Finding the maximum date of birth among students
    private static Student FoundMaxDateOfBirth(List<Student> students)
    {
        var maxDateOfBirth = students.MaxBy(x => x.DateOfBirth)?.DateOfBirth;

        return students.FirstOrDefault(s => s.DateOfBirth == maxDateOfBirth);
    }

    // Finding the minimum date of birth among students
    private static Student FoundMinDateOfBirth(List<Student> students)
    {
        var minDateOfBirth = students.MinBy(x => x.DateOfBirth)?.DateOfBirth;

        return students.FirstOrDefault(x => x.DateOfBirth == minDateOfBirth);
    }

    // Counting the number of elements in the list of students
    private static int CountElementsInStudentList(List<Student> students)
    {
        return students.Count();
    }

    // Finding the intersection of two lists of students
    private static IEnumerable<Student> IntersectElementsInStudentList(List<Student> students)
    {
        var secondIntersectListOfStudents = CreateStudentList();

        return students.Intersect(secondIntersectListOfStudents);
    }

    // Union of two lists of students
    private static IEnumerable<Student> UnionElementsInStudentList(List<Student> students)
    {
        var secondUnionListOfStudents = CreateStudentList();

        return students.Union(secondUnionListOfStudents);
    }

    // Excluding elements of one list from another list
    private static IEnumerable<Student> ExceptElementsInStudentList(List<Student> students)
    {
        var secondExceptListOfStudents = CreateStudentList();

        return students.Except(secondExceptListOfStudents);
    }

    // Checking for the presence of a student with a specific name in the list
    private static bool ContainsMethod(List<Student> students, string firstName)
    {
        return students.Select(s => s.FirstName).Contains(firstName, StringComparer.OrdinalIgnoreCase);
    }

    // Checking if all students are adults
    private static bool AreAllStidentsAdult(List<Student> students)
    {
        return students.All(s => IsAdult(s.DateOfBirth));

        static bool IsAdult(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            DateTime eighteenYearsAgo = today.AddYears(-18);
            return dateOfBirth <= eighteenYearsAgo;
        }
    }

    // Reversing the list of students
    private static IEnumerable<Student> ReverseList(List<Student> students)
    {
        return students.AsEnumerable().Reverse();
    }

    // Converting the list of students to a Lookup for grouping by the first letter of the name
    private static ILookup<char, Student> ToLookUpMethod(List<Student> students)
    {
        return students.ToLookup(s => s.FirstName[0]);
    }

    // Grouping students by the first letter of the name
    private static IEnumerable<IGrouping<char, Student>> GroupByMethod(List<Student> students)
    {
        return students.GroupBy(s => s.FirstName[0]);
    }

    // Joining students to another list by last name
    private static IEnumerable<Student> JoinMethod(List<Student> students)
    {
        var secondListOfStudents = students.ToList();

        return students.Join(
            secondListOfStudents,
            student => student.LastName,
            secondStudent => secondStudent.LastName,
            (student, secondStudent) => student
        );
    }

    // Sorting students by name in descending order, then by date of birth
    private static IEnumerable<Student> ThenByDescendingMethod(List<Student> students)
    {
        return students
            .OrderBy(s => s.FirstName)
            .ThenByDescending(s => s.DateOfBirth);
    }

    // Sorting students by name, then by date of birth
    private static IEnumerable<Student> ThenByMethod(List<Student> students)
    {
        return students
            .OrderBy(s => s.FirstName)
            .ThenBy(s => s.DateOfBirth);
    }

    // Sorting students by date of birth in descending order
    private static IEnumerable<Student> OrderByDescendingMethod(List<Student> students)
    {
        return students.OrderByDescending(s => s.DateOfBirth);
    }
}
