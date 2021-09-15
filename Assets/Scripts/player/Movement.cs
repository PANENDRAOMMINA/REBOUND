using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 v;
    public Camera cam;
 

    //game object 
   
   
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        v = new Vector3(transform.position.x,0,transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray= cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        { 
            transform.position = raycastHit.point; 
        }

    }
}
