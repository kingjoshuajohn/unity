using UnityEngine;
using System.Collections.Generic;


[ExecuteInEditMode()]
public class GridGenerator : MonoBehaviour {

    public Transform tilesParent;
    public GameObject prefab;

    public int tileSize;

    public int height;
    public int width;

    private float offsetX, offsetZ;

    public bool addPadding = false;

    public List<List<Tile>> GenerateGrid()
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
        return outer;
    }

    private Vector3 hexPos(int x, int z)
    {
        Vector3 position = Vector3.zero;

        if( z % 2 == 0)
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
        for(int x = 0; x < tiles.Count; x++)
        {
            List<Tile> list = tiles[x];
            for(int y =0; y < list.Count; y++)
            {
                try
                {
                    Tile neighbor = tiles[x+1][y + 1];
                    tiles[x][y].tile1 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x + 1][y];
                    tiles[x][y].tile2 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x + 1][y - 1];
                    tiles[x][y].tile3 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x][y - 1];
                    tiles[x][y].tile4 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x - 1][y];
                    tiles[x][y].tile5 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x][y + 1];
                    tiles[x][y].tile6 = neighbor;
                }
                catch { }
            }
        }
    }
}
