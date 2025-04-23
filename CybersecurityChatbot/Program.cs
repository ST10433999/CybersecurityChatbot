using System;
using SpeechLib; // COM reference: Microsoft Speech Object Library

namespace CyberbotApp
{
    class Program
    {
        static void Main()
        {
            ShowHeader();
            SpeakIntroMessage();
            string user = GetUserName();
            StartChat(user);
            EndSession();
        }

        // Displays ASCII welcome banner
        static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
  ____            _              _             
 |  _ \ ___  __ _| |_ ___  _ __ (_) ___  _ __  
 | |_) / _ \/ _` | __/ _ \| '_ \| |/ _ \| '_ \ 
 |  _ <  __/ (_| | || (_) | | | | | (_) | | | |
 |_| \_\___|\__,_|\__\___/|_| |_|_|\___/|_| |_|");

            Console.WriteLine("Cyberbot Console - Cybersecurity Companion\n");
            Console.ResetColor();
        }

        // Plays an automated voice introduction
        static void SpeakIntroMessage()
        {
            try
            {
                SpVoice speaker = new SpVoice();
                speaker.Volume = 100;
                speaker.Rate = 0;
                speaker.Speak("Welcome. This is Cyberbot. I will assist you with basic cybersecurity knowledge.");
            }
            catch
            {
                Console.WriteLine("[!] Voice playback failed. Ensure COM speech services are available.");
            }
        }

        // Requests user name input and confirms
        static string GetUserName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}. Let's begin.");
            return name;
        }

        // Main chatbot loop and logic
        static void StartChat(string user)
        {
            while (true)
            {
                Console.Write("\nAsk a question or type 'exit': ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input not recognized. Please try again.");
                    continue;
                }

                if (input == "exit")
                    break;

                if (input.Contains("how are you"))
                    Console.WriteLine("I'm operating correctly and ready to assist.");
                else if (input.Contains("purpose"))
                    Console.WriteLine("I provide guidance on cybersecurity fundamentals.");
                else if (input.Contains("topics") || input.Contains("what can i ask"))
                    Console.WriteLine("You can ask about phishing, password security, or browsing safely.");
                else if (input.Contains("phishing"))
                    Console.WriteLine("Phishing is a scam to steal personal data. Always verify sources.");
                else if (input.Contains("password"))
                    Console.WriteLine("Use long, unique passwords and consider password managers.");
                else if (input.Contains("browsing"))
                    Console.WriteLine("Use secure websites (https), keep browsers updated, and avoid pop-ups.");
                else
                    Console.WriteLine("I don't have information on that. Try another cybersecurity topic.");
            }
        }

        // Clean program termination
        static void EndSession()
        {
            Console.WriteLine("\nSession ended. Stay safe online.");
        }
    }
}

