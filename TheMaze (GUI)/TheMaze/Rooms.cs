using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze
{
    class Rooms
    {
        public static Random rng = new Random();

        public static int person = 5;       //Players coordination number

        public static int rows = 7;     //total number of rows in the grid
        public static int collumns = 7; //total number of collumns in the grid

        public static int[,] grid = new int[rows, collumns];    //creates an empty grid

        public static bool canUp = false;
        public static bool canDown = false;
        public static bool canLeft = false;
        public static bool canRight = false;
        public static bool Win = false;

        public static bool cantMove = false;

        public static int yAxis = 1;    //for WPF to recognize where the player's yAxis is
        public static int xAxis = 1;    //for WPF to recognize where the player's xAxis is

        public static void GRooms()     //creates a custom/semi-random maze maze grid
        {
            int none = 0;
            int exit = 4;

            grid[0, 0] = none;  grid[0, 1] = none;              grid[0, 2] = none;              grid[0, 3] = none;              grid[0, 4] = none;              grid[0, 5] = none;              grid[0, 6] = none;
            grid[1, 0] = none;  grid[1, 1] = 1;                 grid[1, 2] = 1;                 grid[1, 3] = rng.Next(0, 2);    grid[1, 4] = rng.Next(0, 2);    grid[1, 5] = rng.Next(0, 2);    grid[1, 6] = none;
            grid[2, 0] = none;  grid[2, 1] = rng.Next(0, 2);    grid[2, 2] = 1;                 grid[2, 3] = 1;                 grid[2, 4] = 1;                 grid[2, 5] = 1;                 grid[2, 6] = none;
            grid[3, 0] = none;  grid[3, 1] = rng.Next(0, 2);    grid[3, 2] = rng.Next(0, 2);    grid[3, 3] = rng.Next(0, 2);    grid[3, 4] = rng.Next(0, 2);    grid[3, 5] = 1;                 grid[3, 6] = none;
            grid[4, 0] = none;  grid[4, 1] = rng.Next(0, 2);    grid[4, 2] = rng.Next(0, 2);    grid[4, 3] = rng.Next(0, 2);    grid[4, 4] = rng.Next(0, 2);    grid[4, 5] = 1;                 grid[4, 6] = none;
            grid[5, 0] = none;  grid[5, 1] = rng.Next(0, 2);    grid[5, 2] = rng.Next(0, 2);    grid[5, 3] = rng.Next(0, 2);    grid[5, 4] = rng.Next(0, 2);    grid[5, 5] = exit;              grid[5, 6] = none;
            grid[6, 0] = none;  grid[6, 1] = none;              grid[6, 2] = none;              grid[6, 3] = none;              grid[6, 4] = none;              grid[6, 5] = none;              grid[6, 6] = none;
        }

        public static void Walking()    //Allows the player to move
        {
            int pastRoomNumber = 0;

            bool loopDone = false;

            for (int y = yAxis; !loopDone && !Win;)          //creates a loop for the y axis
            {
                for (int x = xAxis; !loopDone && !Win;)      //creates a loop for the x axis
                {
                    pastRoomNumber = grid[y, x];
                    if (grid[y, x] == grid[5, 5]) Win = true;

                    string move = null;
                    if (canUp) move = "u";      //Gets the boolean from the button and uses it on switch
                    if (canDown) move = "d";
                    if (canLeft) move = "l";
                    if (canRight) move = "r";

                    switch (move)
                    {
                        case "r":
                            if (grid[y, x + 1] != 0)    //Checks if the room on the right is not empty
                            {
                                x++;    //moves to the right
                                canRight = false;   //Resets all of the booleans for later use
                                cantMove = false;
                                //all other methods does same thing but with different rooms
                            }
                            else
                            {
                                canRight = false;
                                cantMove = true;
                            }
                            break;

                        case "l":
                            if (grid[y, x - 1] != 0)
                            {
                                x--;
                                canLeft = false;
                                cantMove = false;
                            }
                            else
                            {
                                canLeft = false;
                                cantMove = true;
                            }
                            break;

                        case "u":
                            if (grid[y - 1, x] != 0)
                            {
                                y--;
                                canUp = false;
                                cantMove = false;
                            }
                            else
                            {
                                canUp = false;
                                cantMove = true;
                            }
                            break;

                        case "d":
                            if (grid[y + 1, x] != 0) 
                            {
                                y++;
                                canDown = false;
                                cantMove = false;
                            }
                            else
                            {
                                canDown = false;
                                cantMove = true;
                            }
                            break;
                    }       //Checks which boolean is true and executes the relevant code

                    yAxis = y;  //Sets the yAxis as the current possition
                    xAxis = x;  //Same here for the xAxis

                    loopDone = true;    //It sets it to true so the loop could finish
                }
            }   //These 2 for loops are used to move and know where the player is standing
        }

        public static string WallText(int pickText)
        {
            string aWall = null;

            switch (pickText)
            {
                case 0: aWall = "You see a wall in front of you.";
                    break;

                case 1: aWall = "There is a Wall... You can't pass through it.";
                    break;
            }

            return aWall;
        }   //Get's a random text if you were to try to move into a wall

        public static string winningMessage(int pickWinText)
        {
            string win = null;

            switch (pickWinText)
            {
                case 0:
                    win = "You won!";
                    break;

                case 1:
                    win = "Pff, I guess you won this time!";
                    break;
            }

            return win;
        }   //Get's a random winning message when you reach the finishing line
    }
}