namespace Student_Grades_System
{
    class Program
    {
        static void Main(string[] args)
        {

            // get total number of students from user
            int totalStudents;
            Console.Write("Enter total students: ");
            
            while (!int.TryParse(Console.ReadLine(), out totalStudents) || totalStudents < 1)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of students.");
                Console.Write("\nEnter total students: ");
            }

            // array to store student data
            Student[] students = new Student[totalStudents];

            // loop for user interaction
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("\nWelcome to the Student Grades System!");
                Console.WriteLine("[1] Enroll Students\n[2] Enter Student Grades\n[3] Show Student Grades\n[4] Show Top Student\n[5] Exit");

                Console.Write("\nEnter choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Input. Please enter a valid number (1-5).");
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
                    // get student name from user
                    Console.Write($"\nEnter student name: ");
                    string name = Console.ReadLine();
                    students[i] = new Student { Name = name };

                    // ask user if they want to enroll another student
                    if (i < students.Length - 1)
                    {
                        Console.Write("Enter Again [Y/N]: ");
                        string choice = Console.ReadLine().ToUpper();
                        if (choice != "Y")
                            break;
                    }
                }
            }

            // Enter
            static void EnterStudentGrades(Student[] students)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    // check if student is null
                    if (students[i] == null)
                    {
                        break;
                    }

                    Console.WriteLine($"\nStudent: {students[i].Name}");

                    // get and validate science grade
                    double scienceGrade;
                    do
                    {
                        Console.Write("Enter grade for Science: ");
                    } while (!double.TryParse(Console.ReadLine(), out scienceGrade) || scienceGrade < 0 || scienceGrade > 100);
                    students[i].ScienceGrade = scienceGrade;

                    // get and validate math grade
                    double mathGrade;
                    do
                    {
                        Console.Write("Enter grade for Math: ");
                    } while (!double.TryParse(Console.ReadLine(), out mathGrade) || mathGrade < 0 || mathGrade > 100);
                    students[i].MathGrade = mathGrade;

                    // get and validate english grade
                    double englishGrade;
                    do
                    {
                        Console.Write("Enter grade for English: ");
                    } while (!double.TryParse(Console.ReadLine(), out englishGrade) || englishGrade < 0 || englishGrade > 100);
                    students[i].EnglishGrade = englishGrade;

                    // ask user if they want to enter grades for another student
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
                for (int i = 0; i < students.Length; i++)
                {
                    // check if student is not null
                    if (students[i] != null)
                    {
                        Console.WriteLine($"{students[i].Name}\t\t{students[i].ScienceGrade}\t{students[i].MathGrade}\t{students[i].EnglishGrade}\t{students[i].GetAverage()}");
                    }
                }
            }

            static void ShowTopStudent(Student[] students)
            {
                double highestAverage = 0;
                string topStudent = "";

                for (int i = 0; i < students.Length; i++)
                {
                    // check if student is not null
                    if (students[i] != null)
                    {
                        double avg = students[i].GetAverage();
                        if (avg > highestAverage)
                        {
                            highestAverage = avg;
                            topStudent = students[i].Name;
                        }
                    }
                }

                Console.WriteLine($"\nTop Student: {topStudent}");
            }
        }

        class Student
        {
            // property for student name
            public string Name { get; set; }
            
            // property for science grade
            public double ScienceGrade { get; set; }

            // property for math grade
            public double MathGrade { get; set; }
            
            // property for english grade
            public double EnglishGrade { get; set; }

            // method to calculate student's average grade
            public double GetAverage()
            {
                return (ScienceGrade + MathGrade + EnglishGrade) / 3;
            }
        }
    }
}
