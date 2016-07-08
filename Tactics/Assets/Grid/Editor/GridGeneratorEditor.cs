using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(GridGenerator), true)]
public class GridGeneratorEditor : Editor
{

    private List<Tile> grid = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GridGenerator gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate Grid") && grid == null)
        {
            grid = gridGenerator.GenerateGrid();
        }
    }
}
