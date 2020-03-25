using System;
using System.Collections.Generic;

namespace CoronaKitty.World
{
    public class Navigation
    {

        public static Dictionary<string, float> cardinalAngles {get;} = new Dictionary<string, float>{{"NORTH", 0f},
                                                                                                {"NORTHEAST", 45f},
                                                                                                {"EAST", 90f},
                                                                                                {"SOUTHEAST", 135f},
                                                                                                {"SOUTH", 180f},
                                                                                                {"SOUTHWEST", 225f},
                                                                                                {"WEST", 270f},
                                                                                                {"NORTHWEST", 315f}}; 
    }
}