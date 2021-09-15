using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Transform particles;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Sphere"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Sphere_Maintainer>().enable_lose_particles();
            FindObjectOfType<Sphere_Maintainer>().player_Destroy = true;
        }
    }
    

}
