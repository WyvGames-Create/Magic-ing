using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

/* This will utilize our random walk algorithm we defined to generate the actual map
*/
public class MapGen_RandomWalk : MonoBehaviour
{
   [SerializeField] //Start position, and we use [SerializeField] to be able to set the starting position through the inspector
   protected Vector2Int startPos = Vector2Int.zero;

    [SerializeField] //Determining the number of iterations we are running the random walk
    private int iteration = 10;
    [SerializeField] //Determining the length of the traversal/walk
    public int walkingLength = 10;
    [SerializeField] //Should the iteration start randomly?
    public bool startIterationRandomly = true;
    [SerializeField] //The floor positions that will be generated will be visualized
    private MapVisualizer visualizer;

    //Function to run the random walk algorithm
    public void MapGen_Walk()
    {
        HashSet<Vector2Int> floorPos = DoWalk(); //This is the command that runs the random walk, storing all floor positions into a HashSet
        visualizer.GenFloorTiles(floorPos);
    }

    //Executing the random walk algorithm
    protected HashSet<Vector2Int> DoWalk()
    {
        var curPos = startPos; //Set current position to start position
        HashSet<Vector2Int> allFloorPos = new HashSet<Vector2Int>(); //Create a set of all the floor positions walked
        for (int i = 0; i < iteration; i++) //Utilizing a loop, checking each iteration, and performing the walk as such
        {
            var path = RandomWalkAlgorithm.Algorithm(curPos, walkingLength); //Generate the path using the defined algorithm
            allFloorPos.UnionWith(path); //Make sure the floor positions aren't duplicating
            if(startIterationRandomly) //Since want to branch out the iteration, we want now for the current position to also start randomly walking
                curPos = allFloorPos.ElementAt(Random.Range(0, allFloorPos.Count));
        }
        return allFloorPos;
    }
}
