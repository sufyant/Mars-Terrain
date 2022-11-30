using System;

namespace Mars_Terrain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inputs
       string plateauSize = Console.ReadLine();
       string commands = Console.ReadLine();
       
       //Initialize the robot at (1,1) and facing North
       int xPos = 1;
       int yPos = 1;
       char facingDirection = 'N';
       
       //Split the plateau size into individual values
       string[] plateauSizeArray = plateauSize.Split('x');
       int plateauWidth = int.Parse(plateauSizeArray[0]);
       int plateauHeight = int.Parse(plateauSizeArray[1]);
       
       //Loop through the commands and execute them
       foreach (char command in commands)
       {
           //Check to see if the command is to turn left or right
           if (command == 'L' || command == 'R')
           {
               //Rotate the direction the robot is facing
               facingDirection = Rotate(facingDirection, command);
           }
           //Check to see if the command is to move forward
           else if (command == 'F')
           {
               //Move the robot forward
               (xPos, yPos) = Move(xPos, yPos, facingDirection, plateauWidth, plateauHeight);
           }
       }
       
       //Print the final position of the robot
       Console.WriteLine("-----Result-----");
       Console.WriteLine($"{xPos},{yPos},{facingDirection}");
   }
   
   //Rotate the direction the robot is facing
   public static char Rotate(char facingDirection, char command)
   {
       //If the command is to turn left
       if (command == 'L')
       {
           //Check to see which direction the robot is facing
           switch (facingDirection)
           {
               case 'N':
                   facingDirection = 'W';
                   break;
               case 'W':
                   facingDirection = 'S';
                   break;
               case 'S':
                   facingDirection = 'E';
                   break;
               case 'E':
                   facingDirection = 'N';
                   break;
        }
    }
       //If the command is to turn right
       else if (command == 'R')
       {
           //Check to see which direction the robot is facing
           switch (facingDirection)
           {
               case 'N':
                   facingDirection = 'E';
                   break;
               case 'E':
                   facingDirection = 'S';
                   break;
               case 'S':
                   facingDirection = 'W';
                   break;
               case 'W':
                   facingDirection = 'N';
                   break;
           }
       }
       
       //Return the new direction the robot is facing
       return facingDirection;
   }
   //Move the robot in the direction it is facing
   public static (int, int) Move(int xPos, int yPos, char facingDirection, int plateauWidth, int plateauHeight)
   {
       //Check to see which direction the robot is facing
       switch (facingDirection)
       {
           case 'N':
               if (yPos + 1 <= plateauHeight)
               {
                   yPos++;
               }
               break;
           case 'W':
               if (xPos - 1 >= 0)
               {
                   xPos--;
               }
               break;
           case 'S':
               if (yPos - 1 >= 0)
               {
                   yPos--;
               }
               break;
           case 'E':
               if (xPos + 1 <= plateauWidth)
               {
                   xPos++;
               }
               break;
       }
       
       //Return the new position of the robot
       return (xPos, yPos);
   }
    }
}
   
   
