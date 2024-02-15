using AutoFixture;
using Lesson_6_StudentProperties;

class Program
{
    static void Main(string[] args)
    {
        var fixture = new Fixture();

        var students = new List<Student>();

        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            students.Add(student);
        }

        FilterStudentsByFirstLetter(students); // Фильтрация студентов по первой букве имени

        OrderStudentsByNameAndDateOfBirth(students); // Сортировка студентов сначала по имени, а затем по дате рождения

        RemoveDuplicates(students); // Удаление дубликатов студентов из списка

        FindEarliestDateOfBirth(students); // Нахождение самой ранней даты рождения студентов

        ReturnFirstElement(students); // Возврат первого элемента из списка студентов

        ReturnLastElement(students); // Возврат последнего элемента из списка студентов

        ElementAtMethod(students); // Получение элемента по индексу

        ConcatListsMethod(students); // Объединение двух списков студентов

        SkipElements(students); // Пропуск указанного количества элементов в списке

        TakeElements(students); // Взятие указанного количества элементов из начала списка

        ZipElements(students); // Создание пар из элементов двух списков

        PrintSingleStudent(students); // Вывод информации о единственном студенте с указанным именем

        FoundMaxDateOfBirth(students); // Нахождение максимальной даты рождения среди студентов

        FoundMinDateOfBirth(students); // Нахождение минимальной даты рождения среди студентов

        CountElemetsInStudentList(students); // Подсчет количества элементов в списке студентов

        IntersectElemetsInStudentList(students); // Нахождение пересечения двух списков студентов

        UnoinElementsInStudentList(students); // Объединение двух списков студентов

        ExceptElementsInStudentList(students); // Исключение элементов одного списка из другого списка

        ContainsMethod(students, "Oleksii"); // Проверка наличия студента с определенным именем в списке

        AllStudentsAdult(students); // Проверка, являются ли все студенты взрослыми

        ReverseList(students); // Разворот списка студентов

        ToLookUpMethod(students); // Преобразование списка студентов в Lookup для группировки по первой букве имени

        GroupByMethod(students); // Группировка студентов по первой букве имени

        JoinMethod(students); // Присоединение студентов к другому списку по фамилии

        ThenByDescendingMethod(students); // Сортировка студентов по имени в порядке убывания, а затем по дате рождения

        ThenByMethod(students); // Сортировка студентов по имени, а затем по дате рождения

        OrderByDescendingMethod(students); // Сортировка студентов по дате рождения в порядке убывания
    }

    // Фильтрация студентов по первой букве имени
    private static void FilterStudentsByFirstLetter(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("1) FilterStudentsByFirstLetter");
        Console.ResetColor();

        var selectedStudents = students
            .Where(s => new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }
            .Contains(s.FirstName.ToUpper().Substring(0, 1)))
            .OrderBy(s => s.FirstName);

        foreach (Student student in selectedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(student.FirstName);
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Сортировка студентов сначала по имени, а затем по дате рождения
    private static void OrderStudentsByNameAndDateOfBirth(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("2) OrderStudentsByNameAndDateOfBirth");
        Console.ResetColor();

        var selectedStudents = from s in students
                               orderby s.FirstName, s.DateOfBirth
                               select s;
        foreach (Student s in selectedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"FirstName: {s.FirstName} - {s.DateOfBirth}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Удаление дубликатов студентов из списка
    private static void RemoveDuplicates(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("3) RemoveDuplicates");
        Console.ResetColor();

        var result = students.Distinct();

        foreach (Student s in result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s.FirstName);
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Нахождение самой ранней даты рождения студентов
    private static void FindEarliestDateOfBirth(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("4) FindEarliestDateOfBirth");
        Console.ResetColor();

        DateTime earliestDateOfBirth = students
            .Select(s => s.DateOfBirth)
            .Aggregate((earliest, next) => next < earliest ? next : earliest);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Earliest Date of Birth: {earliestDateOfBirth}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Возврат первого элемента из списка студентов
    private static void ReturnFirstElement(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5) ReturnFirstElement");
        Console.ResetColor();

        var firstElement = students.FirstOrDefault();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"First Element in List: {firstElement}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Возврат последнего элемента из списка студентов
    private static void ReturnLastElement(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("6) ReturnLastElement");
        Console.ResetColor();

        var lastElement = students.LastOrDefault();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Last Element in List: {lastElement}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Получение элемента по индексу
    private static void ElementAtMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("7) ElementAtMethod");
        Console.ResetColor();

        Student elementAt = students.ElementAt(4);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Student at index 4:\n" +
            $"FirstName: {elementAt.FirstName},\n" +
            $"LastName: {elementAt.LastName},\n" +
            $"DateOfBirth: {elementAt.DateOfBirth},\n" +
            $"Country: {elementAt.Country},\n" +
            $"City: {elementAt.City}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Объединение двух списков студентов
    private static void ConcatListsMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("8) ConcatListsMethod");
        Console.ResetColor();

        List<Student> newList = new List<Student>();

        var newFixture = new Fixture();

        for (int i = 0; i < 10; i++)
        {
            var fakeStudent = newFixture.Create<Student>();
            newList.Add(fakeStudent);
        }

        var concatenatedLists = newList.Concat(students);

        foreach (Student student in concatenatedLists)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Concatenated List student with List newList:");
            Console.WriteLine($"FirstName: {student.FirstName}");
            Console.WriteLine($"LastName: {student.LastName}");
            Console.WriteLine($"DateOfBirth: {student.DateOfBirth}");
            Console.WriteLine($"Country: {student.Country}");
            Console.WriteLine($"City: {student.City}");
            Console.ResetColor();

            Console.WriteLine();
        }
    }

    // Пропуск указанного количества элементов в списке
    private static void SkipElements(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("9) SkipElements");
        Console.ResetColor();

        var skippedElements = students.Skip(3);

        foreach (Student student in skippedElements)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Skipped elements: {student.FirstName}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Взятие указанного количества элементов из начала списка
    private static void TakeElements(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("10) TakeElements");
        Console.ResetColor();

        var takeElements = students.Take(2);

        foreach (Student student in takeElements)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Take 2 Elements: {student}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Создание пар из элементов двух списков
    private static void ZipElements(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("11) ZipElements");
        Console.ResetColor();

        var fixture = new Fixture();

        var secondListOfStudents = new List<Student>();

        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondListOfStudents.Add(student);
        }

        var zippedStudents = students.Zip(secondListOfStudents, (first, second) => new
        {
            FirstStudent = first,
            SecondStudent = second
        });

        foreach (var pair in zippedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"First Student: {pair.FirstStudent.FirstName} - Second Student: {pair.SecondStudent.FirstName}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Вывод информации о единственном студенте с указанным именем
    private static void PrintSingleStudent(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("12) PrintSingleStudent");
        Console.ResetColor();

        var singleOrDefault = students.SingleOrDefault(x => x.FirstName == "Student");

        if (singleOrDefault != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Single Student: {singleOrDefault}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student with name 'Student' not found");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Нахождение максимальной даты рождения среди студентов
    private static void FoundMaxDateOfBirth(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("13) FoundMaxDateOfBirth");
        Console.ResetColor();

        var maxElementInStudentList = students.Max(x => x.DateOfBirth);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Maximum Date of Birth: {maxElementInStudentList}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Нахождение минимальной даты рождения среди студентов
    private static void FoundMinDateOfBirth(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("14) FoundMinDateOfBirth");
        Console.ResetColor();

        var minElementInStudentList = students.Min(x => x.DateOfBirth);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Minimum Date of Birth: {minElementInStudentList}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Подсчет количества элементов в списке студентов
    private static void CountElemetsInStudentList(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("15) CountElemetsInStudentList");
        Console.ResetColor();

        var countStudentsElementsList = students.Count();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Count: {countStudentsElementsList}");
        Console.ResetColor();

        Console.WriteLine();
    }

    // Нахождение пересечения двух списков студентов
    private static void IntersectElemetsInStudentList(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("16) IntersectElemetsInStudentList");
        Console.ResetColor();

        var fixture = new Fixture();

        var secondIntersectListOfStudents = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondIntersectListOfStudents.Add(student);
        }

        var intersection = students.Intersect(secondIntersectListOfStudents);

        if (!intersection.Any())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("There no common elements in student lists");
            Console.ResetColor();
        }
        else
        {
            foreach (Student student in intersection)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Intersection: {student.FirstName}");
                Console.ResetColor();
            }
        }

        Console.WriteLine();
    }

    // Объединение двух списков студентов
    private static void UnoinElementsInStudentList(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("17) UnoinElementsInStudentList");
        Console.ResetColor();

        var fixture = new Fixture();

        var secondUnionListOfStudents = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondUnionListOfStudents.Add(student);
        }

        var union = students.Union(secondUnionListOfStudents);

        foreach (Student student in union)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nUnion Elements:");
            Console.WriteLine($"FirstName: {student.FirstName}");
            Console.WriteLine($"LastName: {student.LastName}");
            Console.WriteLine($"DateOfBirth: {student.DateOfBirth}");
            Console.WriteLine($"Country: {student.Country}");
            Console.WriteLine($"City: {student.City}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Исключение элементов одного списка из другого списка
    private static void ExceptElementsInStudentList(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("18) ExceptElementsInStudentList");
        Console.ResetColor();

        var fixture = new Fixture();

        var secondExceptListOfStudents = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondExceptListOfStudents.Add(student);
        }

        var except = students.Except(secondExceptListOfStudents);

        foreach (Student student in except)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nExcept Elements:");
            Console.WriteLine($"FirstName: {student.FirstName}");
            Console.WriteLine($"LastName: {student.LastName}");
            Console.WriteLine($"DateOfBirth: {student.DateOfBirth}");
            Console.WriteLine($"Country: {student.Country}");
            Console.WriteLine($"City: {student.City}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Проверка наличия студента с определенным именем в списке
    private static void ContainsMethod(List<Student> students, string firstName)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("19) ContainsMethod");
        Console.ResetColor();

        bool containsFirstName = students.Select(s => s.FirstName).Contains(firstName, StringComparer.OrdinalIgnoreCase);

        if (containsFirstName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"List contains student with the first name '{firstName}'.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"List does not contain student with the first name '{firstName}'.");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // проверка, являются ли все студенты взрослыми
    private static void AllStudentsAdult(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("20) AllCheckElements");
        Console.ResetColor();

        bool allAdults = students.All(s => IsAdult(s.DateOfBirth));

        if(allAdults)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All students are adults");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Not all students are adults");
            Console.ResetColor();
        }

        Console.WriteLine();


        static bool IsAdult(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            return age >= 18;
        }
    }

    // Разворот списка студентов
    private static void ReverseList(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("21) ReverseMethod");
        Console.ResetColor();

        students.Reverse();

        foreach (Student student in students)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nReverse Elements:");
            Console.WriteLine($"FirstName: {student.FirstName}");
            Console.WriteLine($"City: {student.City}");
            Console.WriteLine($"Country: {student.Country}");
            Console.WriteLine($"DateOfBirth: {student.DateOfBirth}");
            Console.WriteLine($"LastName: {student.LastName}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Преобразование списка студентов в Lookup для группировки по первой букве имени
    private static void ToLookUpMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("22) ToLookUpMethod");
        Console.ResetColor();

        var studentsLookUp = students.ToLookup(s => s.FirstName[0]);

        foreach (var group in studentsLookUp)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Students with names starting with '{group.Key}':");
            Console.ResetColor();

            foreach (var student in group)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName}");
            }

            Console.WriteLine();
        }

    }

    // Группировка студентов по первой букве имени
    private static void GroupByMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("23) GroupByMethod");
        Console.ResetColor();

        var groupedStudents = students.GroupBy(s => s.FirstName[0]);

        foreach (var group in groupedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Students with names starting with '{group.Key}':");
            Console.ResetColor();

            foreach (var student in group)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName}");
            }

            Console.WriteLine();
        }
    }

    // Присоединение студентов к другому списку по фамилии
    private static void JoinMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("24) JoinMethod");
        Console.ResetColor();

        var fixture = new Fixture();
        var secondListOfStudents = new List<Student>();
        for (int i = 0; i < 10; i++)
        {
            var student = fixture.Create<Student>();
            secondListOfStudents.Add(student);
        }

        var joinedStudents = students.Join(
            secondListOfStudents,
            student => student.LastName,
            secondStudent => secondStudent.LastName,
            (student, secondStudent) => new { Student = student, SecondStudent = secondStudent }
        );

        if(joinedStudents.Any())
        {
            foreach (var pair in joinedStudents)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Student: {pair.Student.LastName} - Second Student: {pair.SecondStudent.FirstName}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No matches found");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Сортировка студентов по имени в порядке убывания, азатем по дате рождения
    private static void ThenByDescendingMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("25) ThenByDescendingMethod");
        Console.ResetColor();

        var orderedStudents = students
            .OrderBy(s => s.FirstName)
            .ThenByDescending(s => s.DateOfBirth);

        foreach(var student in orderedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {student.FirstName}, Date of Birth: {student.DateOfBirth}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    //Сортировка студентов по имени, а затем по дате рождения
    private static void ThenByMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("26) ThenByMethod");
        Console.ResetColor();

        var orderedStudents = students
            .OrderBy(s => s.FirstName)
            .ThenBy(s => s.DateOfBirth);

        foreach (var student in orderedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {student.FirstName}, Date of Birth: {student.DateOfBirth}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

    // Сортировка студентов по дате рождения в порядке убывания
    private static void OrderByDescendingMethod(List<Student> students)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("27) OrderByDescendingMethod");
        Console.ResetColor();

        var orderedStudents = students.OrderByDescending(s => s.DateOfBirth);

        foreach(var student in orderedStudents)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {student.FirstName}, Date of Birth: {student.DateOfBirth}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }
}
