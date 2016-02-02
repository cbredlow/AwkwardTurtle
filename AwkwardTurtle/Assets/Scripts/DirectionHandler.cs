using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
namespace Assets.Scripts
{
    public class DirectionHandler
    {
        
        /// <summary>
        /// Has the gravity been inverted?
        /// false = normal gravity
        /// true = inverted gravity
        /// </summary>
        private static Boolean flipped = false;


        public static void flip()
        {
            flipped = !flipped;//just need to invert the current flippedState
        }
        /// <summary>
        /// Sets the player vector based off of the flipped status and the current room direction
        /// </summary>
        /// <param name="forward">Direction of room creation</param>
        public static void updateDirection(Direction forward)
        {
            switch(forward)
            {
                case (Direction.UP):
                    if(flipped)
                    {
                        Player.UpdateDirection(Constants.VECTOR_LEFT, Constants.VECTOR_UP);
                    }
                    else
                    {
                        Player.UpdateDirection(Constants.VECTOR_RIGHT, Constants.VECTOR_UP);
                    }
                    break;
                case (Direction.RIGHT):
                    if(flipped)
                    {
                        Player.UpdateDirection(Constants.VECTOR_RIGHT, Constants.VECTOR_UP);
                    }
                    else
                    {
                        Player.UpdateDirection(Constants.VECTOR_RIGHT, Constants.VECTOR_DOWN);
                    }
                    break;
                case (Direction.DOWN):
                    if (flipped)
                    {
                        Player.UpdateDirection(Constants.VECTOR_LEFT, Constants.VECTOR_DOWN);
                    }
                    else
                    {
                        Player.UpdateDirection(Constants.VECTOR_RIGHT, Constants.VECTOR_DOWN);
                    }
                    break;
                case (Direction.LEFT):
                    if (flipped)
                    {
                        Player.UpdateDirection(Constants.VECTOR_LEFT, Constants.VECTOR_UP);
                    }
                    else
                    {
                        Player.UpdateDirection(Constants.VECTOR_LEFT, Constants.VECTOR_DOWN);
                    }
                    break;
            }
        }
    }
}
