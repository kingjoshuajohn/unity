using UnityEngine;
using System.Collections;

public class ObjectSelector : MonoBehaviour {

    public LayerMask layerMask;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && Utilities.isInLayerMask(hitInfo.transform.gameObject,layerMask))
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            }
        }
    }
}
