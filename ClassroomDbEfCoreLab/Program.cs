// See https://aka.ms/new-console-template for more information

using ClassroomDbEfCoreLab;
bool runProgram = true;
//CreateDB();
while (runProgram)
{
    DisplayAllDB();
    DisplayStudentDB();
    runProgram = Validator.Validator.GetContinue("Would you like to select another student? [y/n]");
}

static void CreateDB()
{
    using (ClassContext context = new ClassContext())
    {
        //Alternate with List
        List<Student> students = new List<Student>();
        students.Add(new Student()
        {
            Name = "Justin",
            Food = "Baja Blast",
            Hometown = "Wyoming"
        });
        context.AddRange(students);


        //SLOWER WAY -ABOVE IS MUCH BETTER
       Student justin = new Student()
       {
           Name = "Justin",
           Food = "Baja Blast",
           Hometown = "Wyoming"
       };
        context.Students.Add(justin);
        Student lucas = new Student()
        {
            Name = "Lucas",
            Food = "Sushi",
            Hometown = "Lousville"
        };
        context.Students.Add(lucas);
        Student aaliyah = new Student()
        {
            Name = "Aaloiyah",
            Food = "Chicken Wings",
            Hometown = "Manchester"
        };
        context.Students.Add(aaliyah);
        Student jon = new Student()
        {
            Name = "Jon",
            Food = "Bacon",
            Hometown = "Toledo"
        };
        context.Students.Add(jon);
        Student tarik = new Student()
        {
            Name = "Tarik",
            Food = "Tacos",
            Hometown = "Queens, NY"
        };
        context.Students.Add(tarik);
        Student alex = new Student()
        {
            Name = "Alex",
            Food = "Spaghetti",
            Hometown = "Ferndale"
        };
        context.Students.Add(alex);
        Student josh = new Student()
        {
            Name = "Josh",
            Food = "Nalesniki",
            Hometown = "Cali"
        };
        context.Students.Add(josh);
        context.SaveChanges();
    }
}

static void DisplayAllDB()
{
    using(ClassContext context = new ClassContext())
    {
        foreach(Student s in context.Students)
        {
            Console.WriteLine($"{s.StudentID}\t{s.Name}");
        }
    }
}

static void DisplayStudentDB()
{
    int selectedID = 0;
    using(ClassContext context = new ClassContext())
    {
        Console.WriteLine("Select a Student ID:");
        while (true)
        {
            while(!int.TryParse(Console.ReadLine(), out selectedID))
            {
                Console.WriteLine("That was not a valid input! :( ");
            }
            if(selectedID > 0 && selectedID <= 7)
            {
                Student result = context.Students.First(S => S.StudentID == selectedID);
                Console.WriteLine($"Favorite food is {result.Food}. & their hometown is {result.Hometown}");
                break;
            }
            else
            {
                Console.WriteLine("That number is not in range. Select a number from the list.");
            }
        }
    }
}