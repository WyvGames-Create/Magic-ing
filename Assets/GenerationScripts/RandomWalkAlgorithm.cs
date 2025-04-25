using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public static class RandomWalkAlgorithm
{
    /*We are implementing a random walk algorithm in order to traverse a given space to generate a room
      For this, we want to use a HashSet, as the random walk could walk onto the same space again, and using a HashSet would prevent the duplicate space to be an option to be walked on
      We have a certain starting position for the generation, along with the length of the walk (used to see how large we want the room to be)
    */
    public static HashSet<Vector2Int> Algorithm(Vector2Int startPos, int walkLength)
    {
        //This will be the return path of the data
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        
        //We intially add the starting position
        path.Add(startPos);
        var prevPos = startPos; //Initialize the previous position as the first position on path (startPos)

        for(int i = 0; i < walkLength; i++)
        {
            var newPos = prevPos + DirectionIn2D.randomDirection(); //Use previous position and randomly generated direction to determine new position
            path.Add(newPos); //Add new position to final path
            prevPos = newPos; //Set previous position to new position to continue to create the path
        }
        return path;
    }

}

//Getting a direction in 2D for random walk
public static class DirectionIn2D
{
    //A list of all possible directions for the random walk to generate
    public static List<Vector2Int> directionList = new List<Vector2Int>
    {
        new Vector2Int(1,0), //Right
        new Vector2Int(0,-1), //Down
        new Vector2Int(-1,0), //Left
        new Vector2Int(0,1) //Up
    };

    //A function to generate randomness in selection of the direction
    public static Vector2Int randomDirection()
    {
        return directionList[Random.Range(0, directionList.Count)];
    }
}