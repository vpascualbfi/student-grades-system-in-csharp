namespace Student_Grades_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalStudents;
            int choice = 0;

            Console.Write("Enter total students: ");

            while (!int.TryParse(Console.ReadLine(), out totalStudents) || totalStudents < 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("\nEnter total students: ");
            }

            Student[] students = new Student[totalStudents];

            while (choice != 5)
            {
                Console.WriteLine("\nWelcome to the Student Grades System!");
                Console.WriteLine("[1] Enroll Students\n[2] Enter Student Grades\n[3] Show Student Grades\n[4] Show Top Student\n[5] Exit");

                Console.Write("\nEnter choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Input. Please enter a valid number.");
                    Console.Write("\nEnter choice: ");
                }

                switch (choice)
                {
                    case 1:
                        EnrollStudents(students);
                        break;
                    case 2:
                        EnterStudentGrades(students);
                        break;
                    case 3:
                        ShowStudentGrades(students);
                        break;
                    case 4:
                        ShowTopStudent(students);
                        break;
                    case 5:
                        Console.WriteLine("\nBye!");
                        break;
                }
            };

            static void EnrollStudents(Student[] students)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    Console.Write($"\nEnter student name: ");
                    string name = Console.ReadLine();
                    students[i] = new Student { name = name };

                    if (i < students.Length - 1)
                    {
                        Console.Write("Enter Again [Y/N]: ");
                        string choice = Console.ReadLine().ToUpper();
                        if (choice != "Y")
                            break;
                    }
                }
            }

            static void EnterStudentGrades(Student[] students)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i] == null)
                    {
                        break;
                    }

                    Console.WriteLine($"\nStudent: {students[i].name}");

                    // Science Grade
                    double scienceGrade;
                    Console.Write("Enter grade for Science: ");
                    while (!double.TryParse(Console.ReadLine(), out scienceGrade) || scienceGrade < 0 || scienceGrade > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid grade.\n");
                        Console.Write("Enter grade for Science: ");
                    }
                    students[i].scienceGrade = scienceGrade;

                    // Math Grade
                    double mathGrade;
                    Console.Write("Enter grade for Math: ");
                    while (!double.TryParse(Console.ReadLine(), out mathGrade) || mathGrade < 0 || mathGrade > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid grade.\n");
                        Console.Write("Enter grade for Math: ");
                    }
                    students[i].mathGrade = mathGrade;

                    // English Grade
                    double englishGrade;
                    Console.Write("Enter grade for English: ");
                    while (!double.TryParse(Console.ReadLine(), out englishGrade) || englishGrade < 0 || englishGrade > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid grade.\n");
                        Console.Write("Enter grade for English: ");
                    }
                    students[i].englishGrade = englishGrade;

                    Console.Write("Enter Again [Y/N]: ");
                    string choice = Console.ReadLine().ToUpper();
                    if (choice != "Y")
                        break;
                }
            }

            static void ShowStudentGrades(Student[] students)
            {
                Console.WriteLine("\nStudent Grades");
                Console.WriteLine("Name\t\tScience\tMath\tEnglish\tAve.");
                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.name}\t\t{student.scienceGrade}\t{student.mathGrade}\t{student.englishGrade}\t{student.GetAverage()}");
                }
            }

            static void ShowTopStudent(Student[] students)
            {
                double highestAverage = 0;
                string topStudent = "";

                foreach (Student student in students)
                {
                    double avg = student.GetAverage();
                    if (avg > highestAverage)
                    {
                        highestAverage = avg;
                        topStudent = student.name;
                    }
                }

                Console.WriteLine($"\nTop Student: {topStudent}");
            }
        }

        class Student
        {
            public string name { get; set; }
            public double scienceGrade { get; set; }
            public double mathGrade { get; set; }
            public double englishGrade { get; set; }

            public double GetAverage()
            {
                return (scienceGrade + mathGrade + englishGrade) / 3;
            }
        }

    }
}
