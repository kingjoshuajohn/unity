using UnityEngine;
using System.Collections.Generic;


[ExecuteInEditMode()]
public class GridGenerator : MonoBehaviour
{

    public Transform tilesParent;
    public GameObject prefab;

    public int tileSize;

    public int height;
    public int width;

    private float terrainHeight = 2.0f;

    private float offsetX, offsetZ;

    public bool addPadding = false;

    public List<Tile> GenerateGrid()
    {

        float radius = tileSize / 2;

        float unitLength = (addPadding) ? (radius / (Mathf.Sqrt(3) / 2)) : radius;

        offsetX = unitLength * Mathf.Sqrt(3);
        offsetZ = unitLength * 1.5f;

        List<List<Tile>> outer = new List<List<Tile>>();
        for (int row = 0; row < height; row++)
        {
            List<Tile> inner = new List<Tile>();
            for (int col = 0; col < width; col++)
            {
                GameObject hexagon = Instantiate(prefab);
                hexagon.transform.position = hexPos(row, col);
                hexagon.transform.parent = tilesParent;
                hexagon.name = "row: " + row + " col: " + col;
                inner.Add(hexagon.GetComponent<Tile>());
            }
            outer.Add(inner);
        }

        assignNeighbors(outer);
        List<Tile> tiles = new List<Tile>();
        foreach(List<Tile> list in outer)
        {
            foreach(Tile tile in list)
            {
                tiles.Add(tile);
            }
        }
        this.gameObject.AddComponent<Grid>();
        this.gameObject.GetComponent<Grid>().grid = tiles;
        return tiles;
    }

    private Vector3 hexPos(int x, int z)
    {
        Vector3 position = Vector3.zero;
        position.y = terrainHeight;

        if (z % 2 == 0)
        {
            position.x = x * offsetX;
            position.z = z * offsetZ;
        }
        else
        {
            position.x = (x + 0.5f) * offsetX;
            position.z = z * offsetZ;
        }
        return position;
    }

    private void assignNeighbors(List<List<Tile>> tiles)
    {
        for (int x = 0; x < tiles.Count; x++)
        {
            List<Tile> list = tiles[x];
            for (int z = 0; z < list.Count; z++)
            {
                if (z % 2 == 0)
                {
                    assignEvenNeighbors(tiles, x, z);
                }
                else
                {
                    assignOddNeighbors(tiles, x, z);
                }
            }
        }
    }

    private void assignEvenNeighbors(List<List<Tile>> tiles, int x, int z)
    {
        try
        {
            tiles[x][z].tile1 = tiles[x][z + 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile2 = tiles[x + 1][z];
        }
        catch { }
        try
        {
            tiles[x][z].tile3 = tiles[x][z - 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile4 = tiles[x - 1][z - 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile5 = tiles[x - 1][z];
        }
        catch { }
        try
        {
            tiles[x][z].tile6 = tiles[x - 1][z + 1];
        }
        catch { }
    }

    private void assignOddNeighbors(List<List<Tile>> tiles, int x, int z)
    {
        try
        {
            tiles[x][z].tile1 = tiles[x + 1][z + 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile2 = tiles[x + 1][z];
        }
        catch { }
        try
        {
            tiles[x][z].tile3 = tiles[x + 1][z - 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile4 = tiles[x][z - 1];
        }
        catch { }
        try
        {
            tiles[x][z].tile5 = tiles[x - 1][z];
        }
        catch { }
        try
        {
            tiles[x][z].tile6 = tiles[x][z + 1];
        }
        catch { }
    }
}
