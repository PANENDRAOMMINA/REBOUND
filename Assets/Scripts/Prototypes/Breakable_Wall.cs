using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Wall : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Sphere")
        {
            Destroy(this.gameObject);
        }
    }

}
