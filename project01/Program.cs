using System;
using System.IO;

namespace project01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateExamFiles();

            Console.WriteLine("Choose an exam:");
            Console.WriteLine("1 - Exam 1");
            Console.WriteLine("2 - Exam 2");
            Console.WriteLine("3 - Exam 3");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                string fileName = "";

                switch (choice)
                {
                    case 1: fileName = "exam1.txt"; break;
                    case 2: fileName = "exam2.txt"; break;
                    case 3: fileName = "exam3.txt"; break;
                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found!");
                    return;
                }

                string[] lines = File.ReadAllLines(fileName);
                int score = 0;

                Console.WriteLine("\n--- Start Exam ---\n");

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    // حماية من الخطأ
                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Invalid question format, skipped.");
                        continue;
                    }

                    string question = parts[0];
                    string correctAnswer = parts[1];

                    Console.WriteLine(question);
                    Console.Write("Your answer: ");
                    string userAnswer = Console.ReadLine();

                    if (userAnswer != null &&
                        userAnswer.Trim().ToLower() == correctAnswer.ToLower())
                    {
                        score++;
                    }
                }

                Console.WriteLine("\n--- Result ---");
                Console.WriteLine($"Your score: {score} / {lines.Length}");
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }

        static void CreateExamFiles()
        {
            // Exam 1
            File.WriteAllLines("exam1.txt", new string[]
            {
                "Q1: What is 2 + 2?|4",
                "Q2: What is the capital of France?|Paris",
                "Q3: What color is the sky?|Blue"
            });

            // Exam 2
            File.WriteAllLines("exam2.txt", new string[]
            {
                "Q1: What is 5 * 3?|15",
                "Q2: What is the capital of Saudi Arabia?|Riyadh",
                "Q3: What is 10 + 5?|15"
            });

            // Exam 3
            File.WriteAllLines("exam3.txt", new string[]
            {
                "Q1: What is 10 / 2?|5",
                "Q2: What is the largest planet?|Jupiter",
                "Q3: What language is used in C#?|C#"
            });
        }
    }
}