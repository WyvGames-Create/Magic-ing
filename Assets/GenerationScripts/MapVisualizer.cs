using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;
    /*[SerializeField]
    private TileBase[] floorTiles; //Array of floor tiles based on the element of the world, and pitfalls */
    [SerializeField]
    private TileBase correctFloorTile; //Select the correct tile to put down based on situation

    public void GenFloorTiles(IEnumerable<Vector2Int> floorPos)
    {
        PutTiles(floorPos, floorTilemap, correctFloorTile);
    }

    private void PutTiles(IEnumerable positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PutATile(tilemap, tile, position);
        }
    }

    private void PutATile(Tilemap tilemap, TileBase tile, object position)
    {
        if (position is Vector2Int pos2D)
        {
            Vector3Int tilePos = new Vector3Int(pos2D.x, pos2D.y, 0);
            tilemap.SetTile(tilePos, tile);
        }
    }
}
