using UnityEngine;
using System.Collections.Generic;


[ExecuteInEditMode()]
public class GridGenerator : MonoBehaviour {

    public Transform tilesParent;
    public GameObject prefab;
    public int size;

    public int width;
    public int height;

    public List<List<Tile>> GenerateGrid()
    {
        List<List<Tile>> outer = new List<List<Tile>>();
        

        for (int i = 0; i < width; i++)
        {
            List<Tile> inner = new List<Tile>();
            for (int j = 0; j < height; j++)
            {
                var square = Instantiate(prefab);

                square.transform.position = new Vector3(i * size, 0, j * size);
                inner.Add(square.GetComponent<Tile>());

                square.transform.parent = tilesParent;
            }
            outer.Add(inner);
        }
        assignNeighbors(outer);
        return outer;
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
                    Tile neighbor = tiles[x][y + 1];
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
                    Tile neighbor = tiles[x][y - 1];
                    tiles[x][y].tile3 = neighbor;
                }
                catch { }
                try
                {
                    Tile neighbor = tiles[x - 1][y];
                    tiles[x][y].tile4 = neighbor;
                }
                catch { }
            }
        }
    }
}
