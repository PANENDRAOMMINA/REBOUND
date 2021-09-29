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
            StartCoroutine(enable_respawn(3));
        }
    }
    
    IEnumerator enable_respawn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        FindObjectOfType<Sphere_Maintainer>().player_Destroy=true;
    }

}
