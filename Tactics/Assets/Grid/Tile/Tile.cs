using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public Tile tile1;

    public Tile tile2;

    public Tile tile3;

    public Tile tile4;

    public Tile tile5;

    public Tile tile6;

    public int height = 0;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        drawDebugInfo();
    }

    private void drawDebugInfo()
    {
        float extraHeight = 8.0f;
        float x = this.transform.position.x;
        float y = this.transform.position.y + extraHeight;
        float z = this.transform.position.z;
        try
        {
            Debug.DrawLine(new Vector3(x,y,z), new Vector3(tile1.transform.position.x,tile1.transform.position.y+ extraHeight, tile1.transform.position.z), Color.red);
        }
        catch { }
        try
        {
            Debug.DrawLine(new Vector3(x, y, z), new Vector3(tile2.transform.position.x, tile2.transform.position.y + extraHeight, tile2.transform.position.z), Color.red);
        }
        catch { }
        try
        {
            Debug.DrawLine(new Vector3(x, y, z), new Vector3(tile3.transform.position.x, tile3.transform.position.y + extraHeight, tile3.transform.position.z), Color.red);
        }
        catch { }
        try
        {
            Debug.DrawLine(new Vector3(x, y, z), new Vector3(tile4.transform.position.x, tile4.transform.position.y + extraHeight, tile4.transform.position.z), Color.red);
        }
        catch { }
        try
        {
            Debug.DrawLine(new Vector3(x, y, z), new Vector3(tile5.transform.position.x, tile5.transform.position.y + extraHeight, tile5.transform.position.z), Color.red);
        }
        catch { }
        try
        {
            Debug.DrawLine(new Vector3(x, y, z), new Vector3(tile6.transform.position.x, tile6.transform.position.y + extraHeight, tile6.transform.position.z), Color.red);
        }
        catch { }
    }
}
