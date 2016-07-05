using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(GridGenerator), true)]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GridGenerator gridGenerator = (GridGenerator)target;

        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
    }
}
