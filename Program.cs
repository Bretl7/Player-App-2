
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace Player_App_2
{
	/// <summary>
	/// This Class Program contains the Main method,
	/// as well as local methods created by developer,
	/// that drive the console app
	/// </summary>
	public class Program
	{
		/// <summary>
		/// This method prints out Bot's info
		/// This method uses delegate from Bot.cs
		/// </summary>
		/// <param name="b"></param>
        private static void PrintBot(APlayer b)
		{
			Console.WriteLine("\nBot Name: " + b.Name +
							  "\nBot ID: " + b.Id);
		}

		/// <summary>
		/// This method prints out player's info
		/// This method uses delegate from UserPlayer.cs
		/// </summary>
		/// <param name="a"></param>
		private static void PrintUserPlayerInfo(UserPlayer a)
        {
			Console.WriteLine("\nPlayer Name: " + a.Name + " -- " + ClassExtension.NumOfLetters(a.Name) + " characters" +
							  "\nPlayer ID: " + a.Id +
							  "\nPlayer Email " + a.Email);
		}
		

		/// <summary>
		/// This method allows users to search for a player(s) by name
		/// This method uses a delegate in UserPlayer.cs
		/// </summary>
		/// <param name="a"></param>
		public static void SearchByName(ArrayList players)
		{
			Console.Write("Enter a name to search: ");
			string searchName = Console.ReadLine().Trim(); // Trims off exterior whitespaces, if any

			// This for loop traverses through all Players in the ArrayList and
			// prints out any Player info that matches with the name provided by the user
			bool foundUser = false;
			int size = players.Count;
			int count = 1;
			foreach (UserPlayer p in players)
            {
				if (p.Name == searchName)
                {
					p.Print(PrintUserPlayerInfo, p);
					foundUser = true;
                }
				// If name is not in arrListOfPlayers
				if (!foundUser && (count == size)) Console.WriteLine("User " + "\'" + searchName + "\' does not exit");
				count++;
			}
		}

		/// <summary>
		/// This method prints out all Bots' info and all user's name, email and ID
		/// </summary>
		/// <param name="a"></param>
		public static void PrintAllUsersAndBots(ArrayList players, ArrayList bots)
		{
			foreach (UserPlayer p in players)
            {
				//((UserPlayer)a[p]).Print(PrintPlayerNameAndEmailAndID, ((UserPlayer)a[p]));
				p.Print(PrintUserPlayerInfo, p);
				Console.WriteLine("---------------------------");
			}
			foreach (Bot bot in bots)
			{
				//((UserPlayer)a[p]).Print(PrintPlayerNameAndEmailAndID, ((UserPlayer)a[p]));
				bot.Print(PrintBot, bot);
				Console.WriteLine("---------------------------");
			}
			Console.WriteLine("-------------End of List-------------");
		}


		/// <summary>
		/// MAIN PROGRAM
		/// </summary>
		public static void Main()
		{
			Console.Write("Welcome to Player creator. Please enter the number of players you would like to create (0 - 10): ");
			byte numOfPlayers = 0;
			string userEntry = Console.ReadLine(); // User enters a number between 1-10 (hopefully)

			// This try/catch block ensures that the user enters a number between 1-10 only.
			// It will keep prompting the user until the requirements are met
			try
			{
				byte.TryParse(userEntry, out numOfPlayers); // This will try to parse the string into a number and store it in numOfPlayers

				// The while loop will keep prompting user to enter number between 1-10 until requirements met
				while (numOfPlayers < 1 || numOfPlayers > 10 || !byte.TryParse(userEntry, out numOfPlayers))
				{
					Console.WriteLine("An error occured in TRY, please ensure you enter a number between 1 and 10");
					userEntry = Console.ReadLine();
					byte.TryParse(userEntry, out numOfPlayers);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("An error occured, please ensure you enter a number between 1 and 10");
				numOfPlayers = 0;
				userEntry = Console.ReadLine();
				while (numOfPlayers < 1 && numOfPlayers > 10 && byte.TryParse(userEntry, out numOfPlayers))
				{
					Console.WriteLine("An error occured, please ensure you enter a number between 1 and 10");
					userEntry = Console.ReadLine();
					byte.TryParse(userEntry, out numOfPlayers);
				}
			}

			// Creating a ArrayList of Players and Bots instead of using a regular array
			ArrayList arrListOfPlayers = new ArrayList();
			ArrayList arrListOfBots = new ArrayList();

			byte count = 0;
			// This loop will prompt user to enter in email address for a player.
			// It will keep prompting user to enter emial until valid
			while (count < numOfPlayers)
			{
				bool isValidEmail = false;
				string userName = "";
				string userEmail = "";
				Console.Write("Please enter a name for Player " + (count + 1) + ": ");
				userName = Console.ReadLine();

				Console.Write("Please enter an email for Player " + (count + 1) + ": ");
				while (!isValidEmail)
				{
					isValidEmail = false;

					userEmail = Console.ReadLine();
					Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); // Ensures '@[a-z].com' is included
					Match match = regex.Match(userEmail);


					if (match.Success) isValidEmail = true;
					else Console.WriteLine("Invalid Email address, please enter valid email: ");
				}
				arrListOfPlayers.Add(new UserPlayer(userName, userEmail));
				arrListOfBots.Add(new Bot());

				count++;
			}

			// Reads text file data...stores 4 more players (and their email addresses)
			FileStream fs = new FileStream("C://Users//bretl//source//repos//Quintrix//Wk 1//Player App 2//ReadPlayerInfo.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
			StreamReader sr = new StreamReader(fs);
			string str = "";
			do
            {
				str = sr.ReadLine();
				arrListOfPlayers.Add(new UserPlayer(str, sr.ReadLine()));
            } while (!sr.EndOfStream);
			sr.Close();
			fs.Close();

			// Writes all Players info to text file
			FileStream fw = new FileStream("C://Users//bretl//source//repos//Quintrix//Wk 1//Player App 2//WritePlayerInfo.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
			StreamWriter sw = new StreamWriter(fw);
			int playerCount = 1;
            foreach (UserPlayer player in arrListOfPlayers)
            {
				sw.Write("Player Name: " + player.Name + " -- " + ClassExtension.NumOfLetters(player.Name) + " characters" +
						 "\nPlayer ID: " + player.Id +
						 "\nPlayer Email " + player.Email);
				sw.Flush(); // clears sw buffer
				if (playerCount != arrListOfPlayers.Count) sw.WriteLine("\n"); // Adds extra space if not end of ArrayList

				playerCount++;
            }
			sw.Close();
			fw.Close();

			// Removes unused elements to save memory space
			arrListOfPlayers.TrimToSize();
			arrListOfBots.TrimToSize();


			// This loop will prompt the user for three actions:
			bool isDone = false;
			while (!isDone)
			{
				Console.WriteLine("\nPlease choose one of the following options:\n" +
					"\ta - Search Player by name\n" +
					"\tb - Print out all Players' data\n" +
					"\tc - Terminate program");
				string choice = Console.ReadLine().Trim().ToLower();

				// Options for user
				switch (choice)
				{
					case "a":
						SearchByName(arrListOfPlayers);
						break;
					case "b":
						PrintAllUsersAndBots(arrListOfPlayers, arrListOfBots);
						break;
					case "c":
						isDone = true;
						Console.WriteLine("-----------End of Program-----------");
						break;
					default:
						Console.WriteLine("Invalid entry...");
						break;
				}

			}
		}
    }
}
