using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordGameV1.Models;

namespace WordGameV1
{
    class Program
    {
        wordGameV1Context context;

        public Program()
        {
            context = new wordGameV1Context();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintMenu();
            Console.ReadKey();
        }

        void PrintMenu()
        {
            int ichoice = 0;
            do
            {
                Console.WriteLine("Please select the Option \n" +
                   "1. Login \n" +
                   "2. Register \n"

                   );
                //To handle the format exception
                try
                {
                    ichoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }


                switch (ichoice)
                {
                    case 1:
                        UserLogin();
                        break;
                    case 2:
                        RegisterUser();
                        break;

                    default:
                        Console.WriteLine("Please Select the correct choice");
                        break;
                }

            } while (true);
        }

        private void RegisterUser()
        {
            Console.WriteLine("Enter your details");
            Console.WriteLine("Enter Your Name");
            string UName = Console.ReadLine();
            if (UName.Equals(""))
            {
                Console.WriteLine("UserName Entered is Empty");
                RegisterUser();
            }
            for (int i = 0; i < UName.Length; i++)
            {
                if (Char.IsDigit((UName[i])))
                {
                    Console.WriteLine("Numbers is not Allowed in Name");
                    RegisterUser();
                }

            }
            Console.WriteLine("Enter Email");
            string UUser_Email = Console.ReadLine();
            if (UUser_Email.Equals(""))
            {
                Console.WriteLine("UserEmail is Empty");
                RegisterUser();
            }
            int counter = 0;
            foreach (var item in context.Users)
            {
                if (item.UserEmail.Equals(UUser_Email))
                {
                    counter++;
                }

            }
            if (counter != 0)
            {
                Console.WriteLine("User Already Exists");
                Console.WriteLine("Try Logging In");
                PrintMenu();
            }


            Console.WriteLine("Enter Your Password");
            string UPassword = Console.ReadLine();
            if (UPassword.Equals(""))
            {
                Console.WriteLine("Password Entered is Empty");
                RegisterUser();
            }

            Console.WriteLine("Enter your Phone");
            string UPhone = Console.ReadLine();
            if (UPhone.Equals(""))
            {
                Console.WriteLine("UserPhone Entered is Empty");
                RegisterUser();
            }
            for (int i = 0; i < UPhone.Length; i++)
            {
                if (!(Char.IsDigit((UPhone[i]))))
                {
                    Console.WriteLine("Characters Not Allowed in Phone");
                    RegisterUser();
                }

            }
            SaveUser(UName, UUser_Email, UPassword, UPhone);
            Console.WriteLine("User Registeration Completed");
            foreach (var item in context.Users)
            {
                if (item.UserEmail == UUser_Email)
                {
                    Console.WriteLine("Your Email ID : " + UUser_Email);
                    Console.WriteLine("Try This to log In");
                }

            }

            AddUserScore(context.Users.OrderBy(a => a.UserId).Last().UserId);
        }
        void SaveUser(string name, string email, string password, string phone)
        {
            User user = new User();
            user.UserName = name;
            user.UserEmail = email;
            user.UserPassword = password;
            user.Phone = phone;
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UserLogin()
        {
            User user = new User();
            Console.WriteLine("Enter Your Email");
            string Email1 = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string Pass1 = Console.ReadLine();

            List<User> details = context.Users.Where(e => e.UserEmail == Email1 && e.UserPassword == Pass1).ToList();
            bool isEmpty = !details.Any();
            if (isEmpty)
            {
                Console.WriteLine("Invalid input please enter valid Email and Password");
            }
            else
            {
                Console.WriteLine("Welcome to Word Game");
                PlayGameMenu(Email1);
            }
        }

        private int GetUserId(string email)
        {
            int userid = 0;

            foreach (var item in context.Users)
            {
                // Console.WriteLine("User"+item.UserEmail);
                if (item.UserEmail == email)
                {
                    userid = item.UserId;
                    break;
                }

            }
            return userid;
        }

        public void PlayGameMenu(string email)
        {
            int ichoice = 0;
            int userid = GetUserId(email);

            do
            {
                Console.WriteLine("Please select the Option \n" +
                   "1.Words Ready for you to Play \n" +
                   "2. Assign Word for another player \n" +
                   "3. See Score Board \n" +
                   "0. Exit"

                   );
                //To handle the format exception
                try
                {
                    ichoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again");
                }


                switch (ichoice)
                {
                    case 1:
                        InitGame(userid);
                        break;
                    case 2:
                        AssignWordsForAnotherPlayer(userid);
                        break;
                    case 3:
                        PrintScoreBoard();
                        break;
                    case 0:
                        Console.WriteLine("You have decided to exit");
                        break;

                    default:
                        Console.WriteLine("Please Select the correct choice");
                        break;
                }

            } while (ichoice != 0);

        }
        /*void InitGame(int userId)
        {
            Dictionary<int, UsersWord> wordsDict = WordsReadyToPlay(userId);
            string selectedWord = ChooseWordToPlay(wordsDict);
            MainGame(selectedWord, userId);
        }*/
        void InitGame(int userId)
        {
            Dictionary<int, UsersWord> wordsDict = WordsReadyToPlay(userId);
            if (wordsDict.Count <= 0)
            {
                Console.WriteLine("There is no words to play!");
                string usermail = context.Users.Find(userId).UserEmail;
                PlayGameMenu(usermail);
            }

            string selectedWord = ChooseWordToPlay(wordsDict);
            MainGame(selectedWord, userId);
        }

        void MainGame(String UserPlayWord, int userId)
        {
            int cow = 0;
            int bull = 0;
            String str1 = UserPlayWord;
            int LengthOfWordToGuess = str1.Length;

            while (true)
            {
                Console.WriteLine("Enter your guess");
                string str2 = WordValidation(Console.ReadLine().Trim()).ToUpper();
                if (str2 == string.Empty)
                {
                    Console.WriteLine("Oop.. Incorrect Input! Please try again!");
                    MainGame(UserPlayWord, userId);
                }
                char[] char1 = str1.ToCharArray();  //weather
                char[] char2 = str2.ToCharArray();  //weather
                for (int i = 0; i < char1.Length; i++)
                {

                    for (int j = 0; j < char2.Length; j++)
                    {
                        if (char1[i] == char2[j])
                        {

                            if (i == j)
                            {
                                cow++;

                            }
                            else
                                bull++;
                        }
                    }
                }

                if (cow == LengthOfWordToGuess)
                {
                    bull = 0;
                    Console.WriteLine("You got this right!!!");
                    UpdateUserScore(userId);
                    RemoveWonWord(str1, userId);
                    break;
                }
                Console.WriteLine($"The word you entered is {str2}- COW:{cow},BULL:{bull}");
                cow = 0;
                bull = 0;

            }
        }

        void PrintScoreBoard()
        {
            UserScoreBoard scoreBoard = new UserScoreBoard();
            Console.WriteLine("User\tScore");
            foreach (var item in context.UserScoreBoards.Include(item => item.User).OrderByDescending(item => item.Score))
            {
                Console.WriteLine(item.User.UserName + "\t" + item.Score.ToString());

            }

        }
        void RemoveWonWord(string word, int userId)
        {
            UsersWord wonWord = context.UsersWords.Find(userId, word);
            if (wonWord is null) return;
            context.UsersWords.Remove(wonWord);
            context.SaveChanges();
        }
        void AddUserScore(int userId)
        {
            UserScoreBoard scoreBoard = new UserScoreBoard();
            scoreBoard.UserId = userId;
            scoreBoard.Score = 0;
            context.UserScoreBoards.Add(scoreBoard);
            context.SaveChanges();
        }
        void UpdateUserScore(int userId)
        {
            UserScoreBoard scoreBoard = context.UserScoreBoards.Find(userId);
            if (!(scoreBoard is null))
            {
                scoreBoard.Score = scoreBoard.Score + 10;
                context.UserScoreBoards.Update(scoreBoard);
                context.SaveChanges();
            }
            else
            {
                AddUserScore(userId);
                UpdateUserScore(userId);
            }


        }


        // Creates and prints a Dictionary of user's words
        private Dictionary<int, UsersWord> WordsReadyToPlay(int userId)
        {
            int counter = 0;
            Dictionary<int, UsersWord> userWordsDict = new Dictionary<int, UsersWord>();
            Console.WriteLine("The Words Given to u are ");
            foreach (var item in context.UsersWords)
            {
                if (item.UserId == userId)
                {
                    Console.Write($"{counter + 1}) ");
                    foreach (int i in item.Words)
                        Console.Write("X");
                    Console.WriteLine();
                    userWordsDict.Add(counter, item);
                    counter++;

                }
            }
            return userWordsDict;
        }

        string ChooseWordToPlay(Dictionary<int, UsersWord> availableWords)
        {
            string selectedWord = "";
            int wordChoice = 1;
            try
            {
                Console.WriteLine("Enter Your Choice");
                wordChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ChooseWordToPlay(availableWords);
            }
            if (!availableWords.ContainsKey(wordChoice - 1))
            {
                Console.WriteLine("Oops... invalid input! Please try again.");
                ChooseWordToPlay(availableWords);
            }

            // Console.WriteLine(availableWords[wordChoice-1].Words); //JUST for check, delete before release
            selectedWord = availableWords[wordChoice - 1].Words;


            return selectedWord;

        }

        bool IsExist(int userId, string word)
        {
            if (word == string.Empty) return false;
            UsersWord userWord = context.UsersWords.Find(userId, word);
            return userWord is null ? false : true;
        }
        private static string WordValidation(string validate)
        {
            return new Regex("^[a-zA-Z-]*$").IsMatch(validate) ?
               validate : string.Empty;


        }

        static void PrintAvailableUsers(Dictionary<int, User> users)
        {
            if (users is null)
            {
                Console.WriteLine("Oops ... no available users!");
                return;
            }
            int counter = 1;
            Console.WriteLine("The available users are given bellow");
            foreach (var item in users)
                Console.WriteLine((counter++) + ") " + item.Value.UserName.ToUpper());
        }

        int SelectUserInput()
        {
            int userChoise = 0;
            try
            {
                Console.WriteLine("Select the user");
                userChoise = Convert.ToInt32(Console.ReadLine());
                if (userChoise <= 0)
                {
                    Console.WriteLine("There is no such user!");
                    SelectUserInput();

                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return userChoise;
        }

        void SaveUserWord(int userChoise, string word, string userName)
        {
            UsersWord userNewWord = new UsersWord();
            userNewWord.UserId = userChoise;
            userNewWord.Words = word;
            context.Add(userNewWord);

            context.SaveChanges();
            Console.WriteLine($"Your word {word} has been added to user { userNewWord.UserId } - " +
                    $"{userName}'s word list");
        }

        string WordInput()
        {
            Console.WriteLine("Enter the word");
            string word = WordValidation(Console.ReadLine().Trim()).ToUpper();
            if (word == string.Empty)
            {
                Console.WriteLine("Oops... incorrect input!");
                WordInput();

            }
            return word;
        }
        private void AssignWordsForAnotherPlayer(int userId)
        {

            string word = WordInput();

            Dictionary<int, User> availableUsers = new Dictionary<int, User>();
            int counter = 0;
            int edge = 0;
            foreach (var item in context.Users)
            {
                if (item.UserId != userId)
                {
                    availableUsers.Add(counter, item);
                    counter++;
                    Console.WriteLine((counter) + ") " + item.UserName.ToUpper());
                }
                else
                {
                    edge = counter;

                }

            }

            //PrintAvailableUsers(availableUsers);
            int idModifier;

            int userChoise = SelectUserInput();

            if (edge < userChoise)
                idModifier = 101;
            else if (edge == userChoise)
                idModifier = 100;
            else
                idModifier = 102;

            if (IsExist(userChoise + idModifier, word))
            {
                Console.WriteLine($"{availableUsers[userChoise - 1].UserName} already has the word '{word}'");
                AssignWordsForAnotherPlayer(userId);
            }
            string userName = availableUsers[userChoise - 1].UserName.ToUpper();
            SaveUserWord(userChoise + idModifier, word, userName);
        }


    }
}