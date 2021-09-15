using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    
    public Transform exit;
    public GameObject sphere;

    // Update is called once per frame
    

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Sphere")
        {
            Vector3 v = exit.transform.position;
            sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sphere.GetComponent<Transform>().position = v;

        }
    }
}
