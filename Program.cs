using System;

namespace TIc_Tac_Toe
{
    class Program
    {




        static void Main(string[] args)
        {
            int GameStatus = 0;
            int CurrentPlayer = -1;

            char[] GameSpace = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
             

            
            do
            {
                Console.Clear();
                CurrentPlayer = ChangePlayer(CurrentPlayer); //----------1

                RulesandCurrentPlayer(CurrentPlayer);  //---------------2

                GameBoard(GameSpace);                   //---------------3


                GameEngine(GameSpace, CurrentPlayer);     //-------------4

                GameStatus = CheckforBoth(GameSpace);     //-------------5


            } while(GameStatus == 0);
            Console.Clear();


            RulesandCurrentPlayer(CurrentPlayer);

            GameBoard(GameSpace);

            if (GameStatus.Equals(1))
            {
                Console.WriteLine($"\nPlayer {CurrentPlayer} is Winner");

            }
            if (GameStatus.Equals(2))
            {
                Console.WriteLine("\nOops Game is Draw!");
            }


        }   


        public static int ChangePlayer(int player) //2
        {
            if (player.Equals(1))
            {
                return 2;
            }
            return 1;
        }


        public static void RulesandCurrentPlayer(int player)
        {

            Console.WriteLine("Welcome to Tic Tac Toe\n ");
            Console.WriteLine("Player 1 : O ");
            Console.WriteLine("Player 2 : X ");

            Console.WriteLine(" ");

            Console.WriteLine($"Player {player} Choose between 1-9 To Mark. ");


        }

        public static void GameBoard(char[] GameSpace)
        {
            Console.WriteLine(" ");

            Console.WriteLine($"\t{GameSpace[0]} | {GameSpace[1]} | {GameSpace[2]} ");
            Console.WriteLine("\t--|---|--");
            Console.WriteLine($"\t{GameSpace[3]} | {GameSpace[4]} | {GameSpace[5]} ");
            Console.WriteLine("\t--|---|--");
            Console.WriteLine($"\t{GameSpace[6]} | {GameSpace[7]} | {GameSpace[8]} ");


        }

        //2.
            
        private static char MarkPosition(int CurrentPlayer) //O
        {
            if((CurrentPlayer % 2) == 0)
            {
                return 'X';
            }
            else
            {
                return 'O';
            }
        }


        private static void GameEngine(char[] tryGameSpace, int CurrentPlayer)
        {

            bool RunTillValid = true;

            do
            {
                string userinput = Console.ReadLine();
                int.TryParse(userinput, out int PlusOneExtra);
                if(!string.IsNullOrEmpty(userinput)&&
                    userinput.Equals("1") ||
                    userinput.Equals("2") ||
                    userinput.Equals("3") ||
                    userinput.Equals("4") ||
                    userinput.Equals("5") ||
                    userinput.Equals("6") ||
                    userinput.Equals("7") ||
                    userinput.Equals("8") ||
                    userinput.Equals("9")
                    )
                {
                    if(tryGameSpace[PlusOneExtra -1].Equals('X') || tryGameSpace[PlusOneExtra - 1].Equals('O'))
                    {
                        Console.WriteLine("This Position is Already Marked !. Try different one. ");
                    }
                    else
                    {
                        tryGameSpace[PlusOneExtra - 1] = MarkPosition(CurrentPlayer); //O
                        RunTillValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Choose Valid Option !");
                }


            } while (RunTillValid);

        }

        //3.


       private static bool CheckWinnerOptions(char[]tryGameSpace, int pos1,int pos2,int pos3)
       {
            return tryGameSpace[pos1].Equals(tryGameSpace[pos2]) && tryGameSpace[pos2].Equals(tryGameSpace[pos3]);
       }

       private static bool CheckWinner(char[] GameSpace)
        {
            if (CheckWinnerOptions(GameSpace, 0, 1, 2))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 3, 4, 5))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 6,7,8))
            {
                return true;
            }

            if (CheckWinnerOptions(GameSpace, 0,3,6))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 1,4,7))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 2,5,8))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 0, 4, 8))
            {
                return true;
            }
            if (CheckWinnerOptions(GameSpace, 2, 4, 6))
            {
                return true;
            }
            return false;

       }    

        private static bool CheckDraw(char[] GameSpace)
        {

            return (GameSpace[0] != '1' &&
                GameSpace[1] != '2' &&
                GameSpace[2] != '3' &&
                GameSpace[3] != '4' &&
                GameSpace[4] != '5' &&
                GameSpace[5] != '6' &&
                GameSpace[6] != '7' &&
                GameSpace[7] != '8' &&
                GameSpace[8] != '9');

        }



        private static int CheckforBoth(Char[] GameSpace)
        {
            if (CheckWinner(GameSpace))
            {
                return 1;
            }
            if (CheckDraw(GameSpace))
            {
                return 2;
            }
            return 0;
        }



    }

       

}
