using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {


//-----------------------------------------------------------------------RUN GAME METHOD------------------------------------------------------------------------
        static void runGame(ref Ship Destroyer, ref Ship Cruiser, ref Ship Submarine, ref Ship Battleship, ref Ship Aircraft_Carrier, ref int[,] gameGrid)
        {
            int x = 0, y = 0;
            string attackPosition; //attackPosition is created for comparison to the position array of each ship
    
             

            do
            {


                //Get user input for attack coordinates
                do
                {
                    Console.WriteLine("Choose your X attack coordinate.");
                    try  //Try-Catch structre, used to try to execute a piece of code, if there is a format error, the catch block is entered which will re-do the loop
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException)
                    {
                        x = -1;
                        continue;
                    }
                }
                while (x <= 0 || x > 10); //check coordinates for out of bounds

                do
                {
                    Console.WriteLine("Choose your Y attack coordinate.");
                    try
                    {
                        y = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException)
                    {
                        y = -1;
                        continue;
                    }
                }
                while (y <= 0 || y > 10);

                if (gameGrid[x, y] == 1) //if the coordinate is a 1 on the game grid, it's a hit
                {
                    gameGrid[x, y] = 0;
                    Console.WriteLine("\nHIT!\n---------------------------------\n");
                }
                else
                    Console.WriteLine("\nMISS.\n---------------------------------\n"); // otherwise it is a miss








//=============Decrement hitpoints upon HIT and erase the position in the postion array, as well as check for sunken ship==================

                attackPosition = (x + ", " + y); 
                if (Destroyer.position.Contains(attackPosition))
                {
                    Destroyer.hitpoints -= 1;

                    for (int j = 0; j < 2; j++)
                    {
                        if (Destroyer.position[j] == attackPosition)
                            Destroyer.position[j] = "0, 0";
                    }

                    if (Destroyer.hitpoints == 0)
                        Destroyer.sunkenShip = true;
                }

                if (Cruiser.position.Contains(attackPosition))
                {
                    Cruiser.hitpoints -= 1;

                    for (int j = 0; j < 3; j++)
                    {
                        if (Cruiser.position[j] == attackPosition)
                            Cruiser.position[j] = "0, 0";
                    }

                    if (Cruiser.hitpoints == 0)
                        Cruiser.sunkenShip = true;
                }

                if (Submarine.position.Contains(attackPosition))
                {
                    Submarine.hitpoints -= 1;

                    for (int j = 0; j < 3; j++)
                    {
                        if (Submarine.position[j] == attackPosition)
                            Submarine.position[j] = "0, 0";
                    }

                    if (Submarine.hitpoints == 0)
                        Submarine.sunkenShip = true;
                }

                if (Battleship.position.Contains(attackPosition))
                {
                    Battleship.hitpoints -= 1;

                    for (int j = 0; j < 4; j++)
                    {
                        if (Battleship.position[j] == attackPosition)
                            Battleship.position[j] = "0, 0";
                    }

                    if (Battleship.hitpoints == 0)
                        Battleship.sunkenShip = true;
                }

                if (Aircraft_Carrier.position.Contains(attackPosition))
                {
                    Aircraft_Carrier.hitpoints -= 1;

                    for (int j = 0; j < 5; j++)
                    {
                        if (Aircraft_Carrier.position[j] == attackPosition)
                            Aircraft_Carrier.position[j] = "0, 0";
                    }

                    if (Aircraft_Carrier.hitpoints == 0)
                        Aircraft_Carrier.sunkenShip = true;
                }


//============================================================================================================


                if (Destroyer.sunkenShip == true && Destroyer.sunkenDisplay==false)
                {
                    Console.WriteLine("Destroyer has been sunk!\n");
                    Destroyer.sunkenDisplay = true; 
                }
                if (Cruiser.sunkenShip == true && Cruiser.sunkenDisplay==false)
                {
                    Console.WriteLine("Cruiser has been sunk!\n");
                    Cruiser.sunkenDisplay = true;
                }
                if (Submarine.sunkenShip == true && Submarine.sunkenDisplay == false)
                {
                    Console.WriteLine("Submarine has been sunk!\n");
                    Submarine.sunkenDisplay = true;
                }
                if (Aircraft_Carrier.sunkenShip == true && Aircraft_Carrier.sunkenDisplay == false)
                {
                    Console.WriteLine("Aircraft Carrier has been sunk!\n");
                    Aircraft_Carrier.sunkenDisplay = true;
                }
                if (Battleship.sunkenShip == true && Battleship.sunkenDisplay == false)
                {
                    Console.WriteLine("Battleship has been sunk!\n");
                    Battleship.sunkenDisplay = true;
                }


            } while (Destroyer.sunkenShip == false || Cruiser.sunkenShip == false || Submarine.sunkenShip == false || Battleship.sunkenShip == false || Aircraft_Carrier.sunkenShip == false);

            //Once all ships sunken property is set to true, the game is over
            Console.WriteLine("GAME OVER. ALL SHIPS DESTROYED.");
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------



//-----------------------------------------------------------------------SETUP METHOD---------------------------------------------------------------------------
        static void setup(ref Ship Ship_Placement, ref int[,] gameGrid)
        {
            bool spotTaken=false;
            int spots_to_delete=0;
            do
            {
                spotTaken = false;
                spots_to_delete = 0;
                Random random = new Random();
                int x_Coordinate = 0, y_Coordinate = 0;
                
                do
                {
                    x_Coordinate = random.Next(1, 10);
                } while (x_Coordinate <= 0 || x_Coordinate > 10);

                do
                {
                    y_Coordinate = random.Next(1, 10);
                } while (y_Coordinate <= 0 || y_Coordinate > 10);
                
                //int x_Coordinate = 0, y_Coordinate = 0;
                //Check each input for out of bounds before moving onto the next
                //do
                //{
                //    Console.WriteLine("Enter the X coordinate for the " + Ship_Placement.name + ".");
                //    x_Coordinate = Convert.ToInt32(Console.ReadLine());

                //    //Notifies the user that the input is out of range.
                //    if (x_Coordinate <= 0 || x_Coordinate > 10)
                //        Console.WriteLine("You entered a coordinate outside the range.");
                //}
                //while (x_Coordinate <= 0 || x_Coordinate > 10);

                //do
                //{
                //    Console.WriteLine("Enter the Y coordinate for the " + Ship_Placement.name + ".");
                //    y_Coordinate = Convert.ToInt32(Console.ReadLine());

                //    if (y_Coordinate <= 0 || x_Coordinate > 10)
                //        Console.WriteLine("You entered a coordinate outside the range.");

                //} while (y_Coordinate <= 0 || y_Coordinate > 10);


                //Flag variable to test for placing the ship in a direction that would lead it being out of bounds.
                bool outOfBoundsTest=false;

                Random r = new Random();
                string[] direction = { "up", "down", "left", "right" };
                string shipDirection = "";


                //string shipDirection = "";

                do
                {
                    //Console.WriteLine("Which direction are you placing your " + Ship_Placement.name + "?" + "\n(Up, Down, Left, Right)"); //Get the direction the ship is to be placed in
                    //shipDirection = Console.ReadLine();
                    outOfBoundsTest = false;

                    shipDirection = "";                  
                    shipDirection = direction[r.Next(0, direction.Length)];

                    //Check each direction against the out of bounds case
                    if ((shipDirection.ToUpper() == "UP") && ((y_Coordinate - Ship_Placement.length) <= 0))
                        outOfBoundsTest = true;
                    else if ((shipDirection.ToUpper() == "DOWN") && ((y_Coordinate + Ship_Placement.length) > 10))
                        outOfBoundsTest = true;
                    else if ((shipDirection.ToUpper() == "LEFT") && ((x_Coordinate - Ship_Placement.length) <= 0))
                        outOfBoundsTest = true;
                    else if ((shipDirection.ToUpper() == "RIGHT") && ((x_Coordinate + Ship_Placement.length) > 10))
                        outOfBoundsTest = true;
                    else
                        outOfBoundsTest = false;

                } while (outOfBoundsTest == true); //Loop will continue to ask for a direction until the ship is placed in bounds


                //First position is set in the position array and set on the game grid
                Ship_Placement.position[0] = x_Coordinate + ", " + y_Coordinate;

                if (gameGrid[x_Coordinate, y_Coordinate] == 1)
                {
                    spotTaken = true;
                    /* for (int j = 1; j < Ship_Placement.length; j++)
                     {

                         if (shipDirection.ToUpper() == "UP")
                         {
                             Ship_Placement.position[j] = "0" + ", " + "0";
                             gameGrid[x_Coordinate, y_Coordinate] = 0;
                             y_Coordinate--;
                         }
                         else if (shipDirection.ToUpper() == "DOWN")
                         {
                             Ship_Placement.position[j] = "0" + ", " + "0";
                             gameGrid[x_Coordinate, y_Coordinate] = 0;
                             y_Coordinate++;
                         }
                         else if (shipDirection.ToUpper() == "LEFT")
                         {
                             Ship_Placement.position[j] = "0" + ", " + "0";
                             gameGrid[x_Coordinate, y_Coordinate] = 0;
                             x_Coordinate--;
                         }
                         else if (shipDirection.ToUpper() == "RIGHT")
                         {
                             Ship_Placement.position[j] = "0" + ", " + "0";
                             gameGrid[x_Coordinate, y_Coordinate] = 0;
                             x_Coordinate++;
                         }
                     }*/
                }
                else
                {
                    gameGrid[x_Coordinate, y_Coordinate] = 1;
                    spots_to_delete++;
                }
              

                for (int i = 1; i < Ship_Placement.length; i++)
                {
                    //Places the ship in the appropriate space in the position array
                    if (shipDirection.ToUpper() == "UP")
                    {
                        Ship_Placement.position[i] = x_Coordinate + ", " + (y_Coordinate - 1);
                        y_Coordinate--;
                    }
                    else if (shipDirection.ToUpper() == "DOWN")
                    {
                        Ship_Placement.position[i] = x_Coordinate + ", " + (y_Coordinate + 1);
                        y_Coordinate++;
                    }
                    else if (shipDirection.ToUpper() == "LEFT")
                    {
                        Ship_Placement.position[i] = (x_Coordinate - 1) + ", " + y_Coordinate;
                        x_Coordinate--;
                    }
                    else if (shipDirection.ToUpper() == "RIGHT")
                    {
                        Ship_Placement.position[i] = (x_Coordinate + 1) + ", " + y_Coordinate;
                        x_Coordinate++;
                    }
                    else
                        Console.WriteLine("You entered an invalid direction.");
                

                    //Ship is placed on the game grid
                    if (gameGrid[x_Coordinate, y_Coordinate] == 1)
                    {
                        spotTaken = true;
                        for (int k = 0; k < spots_to_delete; k++)
                        {
                            if (shipDirection.ToUpper() == "UP")
                            {
                                Ship_Placement.position[k] = "0" + ", " + "0";
                                gameGrid[x_Coordinate, y_Coordinate + 1] = 0;
                                y_Coordinate++;
                            }
                            else if (shipDirection.ToUpper() == "DOWN")
                            {
                                Ship_Placement.position[k] = "0" + ", " + "0";
                                gameGrid[x_Coordinate, y_Coordinate-1] = 0;
                                y_Coordinate--;
                            }
                            else if (shipDirection.ToUpper() == "LEFT")
                            {
                                Ship_Placement.position[k] = "0" + ", " + "0";
                                gameGrid[x_Coordinate+1, y_Coordinate] = 0;
                                x_Coordinate++;
                            }
                            else if (shipDirection.ToUpper() == "RIGHT")
                            {
                                Ship_Placement.position[k] = "0" + ", " + "0";
                                gameGrid[x_Coordinate-1, y_Coordinate] = 0;
                                x_Coordinate--;
                            }
                        }
                    }
                    else
                    {
                        gameGrid[x_Coordinate, y_Coordinate] = 1;
                        spots_to_delete++;
                    }
                }

                //if (spotTaken == true)
                //{
                //    for (int i = 1; i <= Ship_Placement.length; i++)
                //    {
                //        Ship_Placement.position[i] = "0" + "," + "0";
                //    }
                //}
                //else
                //{
                //    break;
                //}

            } while (spotTaken == true);

        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------     



//-----------------------------------------------------------------------MAIN METHOD----------------------------------------------------------------------------
        static void Main(string[] args)
        {
            //Game grid is initialized
            int[,] gameGrid = new int[11, 11];



            //Create new ship objects for each ship type
            Ship Destroyer = new Ship();
            Destroyer.length = 2;
            Destroyer.hitpoints = 2;
            Destroyer.sunkenShip = false;
            Destroyer.sunkenDisplay = false;
            Destroyer.name = "Destroyer";

            Ship Cruiser = new Ship();
            Cruiser.length = 3;
            Cruiser.hitpoints = 3;
            Cruiser.sunkenShip = false;
            Cruiser.sunkenDisplay = false;
            Cruiser.name = "Cruiser";

            Ship Submarine = new Ship();
            Submarine.length = 3;
            Submarine.hitpoints = 3;
            Submarine.sunkenShip = false;
            Submarine.sunkenDisplay = false;
            Submarine.name = "Submarine";

            Ship Battleship = new Ship();
            Battleship.length = 4;
            Battleship.hitpoints = 4;
            Battleship.sunkenShip = false;
            Battleship.sunkenDisplay = false;
            Battleship.name = "Battleship";

            Ship Aircraft_Carrier = new Ship();
            Aircraft_Carrier.length = 5;
            Aircraft_Carrier.hitpoints = 5;
            Aircraft_Carrier.sunkenShip = false;
            Aircraft_Carrier.sunkenDisplay = false;
            Aircraft_Carrier.name = "Aircraft Carrier";

           

            //Set each ship piece on the "board" or "grid"
            setup(ref Destroyer, ref gameGrid);
            setup(ref Cruiser, ref gameGrid);                           
            setup(ref Submarine, ref gameGrid);
            setup(ref Battleship, ref gameGrid);
            setup(ref Aircraft_Carrier, ref gameGrid);



           int counter = 0;
            foreach(int x in gameGrid)
            {
                if(x==1)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);



            runGame(ref Destroyer, ref Cruiser, ref Submarine, ref Battleship, ref Aircraft_Carrier, ref gameGrid);
            
            Console.ReadLine();
        }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------- 

        class Ship
        {
            public string name;
            public int length;
            public int hitpoints;
            public bool sunkenShip;
            public bool sunkenDisplay; //Catch to prevent multiple outputs when sinking a ship.
            public string[] position = new string[5];
        }
    }
}
