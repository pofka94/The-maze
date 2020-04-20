using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheMaze
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public static Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Rooms.GRooms();     //Generates the rooms at the start of the execution
            Rooms.Walking();    //Used to set all the values for the program to use
            ColouringRooms();   //Colours the block that you start on
        }

        public void ColouringRooms()
        {
            var colour = Brushes.LightGray; //Used for quick colour changing
            int yAxis = Rooms.yAxis;        //Used to define yAxis from Rooms class
            int xAxis = Rooms.xAxis;        //Used to define xAxis from Rooms class

            //All of this is used to check on what block is the player standing on and will repaint it to a certain colour
            if (yAxis == 1 && xAxis == 1) _1_1.Background = colour;
            if (yAxis == 1 && xAxis == 2) _1_2.Background = colour;
            if (yAxis == 1 && xAxis == 3) _1_3.Background = colour;
            if (yAxis == 1 && xAxis == 4) _1_4.Background = colour;
            if (yAxis == 1 && xAxis == 5) _1_5.Background = colour;
                                                                           
            if (yAxis == 2 && xAxis == 1) _2_1.Background = colour;
            if (yAxis == 2 && xAxis == 2) _2_2.Background = colour;
            if (yAxis == 2 && xAxis == 3) _2_3.Background = colour;
            if (yAxis == 2 && xAxis == 4) _2_4.Background = colour;
            if (yAxis == 2 && xAxis == 5) _2_5.Background = colour;
                                                                        
            if (yAxis == 3 && xAxis == 1) _3_1.Background = colour;
            if (yAxis == 3 && xAxis == 2) _3_2.Background = colour;
            if (yAxis == 3 && xAxis == 3) _3_3.Background = colour;
            if (yAxis == 3 && xAxis == 4) _3_4.Background = colour;
            if (yAxis == 3 && xAxis == 5) _3_5.Background = colour;
                                                                             
            if (yAxis == 4 && xAxis == 1) _4_1.Background = colour;
            if (yAxis == 4 && xAxis == 2) _4_2.Background = colour;
            if (yAxis == 4 && xAxis == 3) _4_3.Background = colour;
            if (yAxis == 4 && xAxis == 4) _4_4.Background = colour;
            if (yAxis == 4 && xAxis == 5) _4_5.Background = colour;
                                                                             
            if (yAxis == 5 && xAxis == 1) _5_1.Background = colour;
            if (yAxis == 5 && xAxis == 2) _5_2.Background = colour;
            if (yAxis == 5 && xAxis == 3) _5_3.Background = colour;
            if (yAxis == 5 && xAxis == 4) _5_4.Background = colour;
            if (yAxis == 5 && xAxis == 5) _5_5.Background = colour;
        }   //Repaints blocks that have been discovered/been in

        public void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            //Most of this code is repeated to other buttons but with different booleans and such
            Rooms.canUp = true; //Sets a boolean canUp to true in the Room class to see if the player can move up
            Rooms.Walking();    //Does all of the walking
            ColouringRooms();   //Does all of the repainting on the UI

            //Gets random text for an impossible move (trying to move to a wall) It will be sent to the black textbox
            if (Rooms.cantMove == true) TextBlock.Text = Rooms.WallText(rng.Next(0, 2));
            else TextBlock.Text = "";

            Rooms.cantMove = true;  //Resets the boolean
        }       //Does things when the Up button is clicked

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            Rooms.canDown = true;
            Rooms.Walking();
            ColouringRooms();

            if (Rooms.cantMove == true) TextBlock.Text = Rooms.WallText(rng.Next(0, 2));
            else TextBlock.Text = "";

            Rooms.cantMove = true;
            if (Rooms.Win)
            {
                MessageBox.Show(Rooms.winningMessage(rng.Next(0, 2))); //Gets random winning message that will be sent to the message box
                System.Windows.Application.Current.Shutdown();
            }
        }    //Does things when the Down button is clicked

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            Rooms.canRight = true;
            Rooms.Walking();
            ColouringRooms();

            if (Rooms.cantMove == true) TextBlock.Text = Rooms.WallText(rng.Next(0, 2));
            else TextBlock.Text = "";

            Rooms.cantMove = true;
            if (Rooms.Win)
            {
                MessageBox.Show(Rooms.winningMessage(rng.Next(0, 2))); //Gets random winning message that will be sent to the message box
                System.Windows.Application.Current.Shutdown();
            }
        }   //Does things when the Right button is clicked

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            Rooms.canLeft = true;
            Rooms.Walking();
            ColouringRooms();

            if (Rooms.cantMove == true) TextBlock.Text = Rooms.WallText(rng.Next(0, 2));
            else TextBlock.Text = "";

            Rooms.cantMove = true;
        }    //Does things when the Left button is clicked

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "1. Use the buttons to Move! \n" +
                "2. Your goal is to get to the green block (exit) \n" +
                "3. Track where you are going by seeing where you move to,\n" +
                "    because you can get lost."
                );
        }
    }
}