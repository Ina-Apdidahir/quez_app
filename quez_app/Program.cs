

        // Step 1: Collect user info
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your student ID: ");
        string studentId = Console.ReadLine();

        // Step 2: Choose quiz type
        Console.WriteLine("\nChoose quiz type:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.Write("Enter choice (1-4): ");
        int choice = int.Parse(Console.ReadLine());

        string quizType = choice switch
        {
            1 => "Addition",
            2 => "Subtraction",
            3 => "Multiplication",
            4 => "Division",
            _ => "Addition"
        };

        Console.WriteLine($"\nStarting {quizType} quiz for {name}...\n");

        int score = 0;
        Random rand = new Random();

        // Step 3: Ask 10 questions
        for (int i = 1; i <= 10; i++)
        {
            int num1 = rand.Next(1, 21); // 1 to 20
            int num2 = rand.Next(1, 21); // 1 to 20
            int correctAnswer = 0;

            string question = "";

            switch (choice)
            {
                case 1:
                    correctAnswer = num1 + num2;
                    question = $"{num1} + {num2}";
                    break;
                case 2:
                    correctAnswer = num1 - num2;
                    question = $"{num1} - {num2}";
                    break;
                case 3:
                    correctAnswer = num1 * num2;
                    question = $"{num1} * {num2}";
                    break;
                case 4:
                    num2 = rand.Next(1, 11); // avoid division by 0
                    num1 = num2 * rand.Next(1, 11); // make divisible
                    correctAnswer = num1 / num2;
                    question = $"{num1} / {num2}";
                    break;
            }

            Console.Write($"Q{i}: What is {question}? ");
            int userAnswer;
            if (int.TryParse(Console.ReadLine(), out userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer is {correctAnswer}\n");
                }
            }
            else
            {
                Console.WriteLine($"Invalid input. The correct answer is {correctAnswer}\n");
            }
        
    }

// Step 4: Display formatted results
double percentage = (score / 10.0) * 100;
string grade = percentage switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    >= 50 => "E",
    _ => "F"
};

int rank = 7; // Example rank

// Final output to match image
Console.WriteLine($"\n(ID: {studentId}) {name}");
Console.WriteLine($"Total Score: {score * 10}/100");
Console.WriteLine($"Grade: {grade}\n");

Console.WriteLine($"{"ID",-8}{"Magac",-10}{"Score",-8}{"Grade",-8}percentages");
Console.WriteLine($"{studentId,-8}{name,-10}{rank,-8}{grade,-8}{percentage}%");