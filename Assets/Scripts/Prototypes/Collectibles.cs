using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   public float value_of_collectible;
   private void Awake()
    {
        value_of_collectible = 1f;
    }
    public void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<Audio_sounds>().Play("collectible");
        FindObjectOfType<Sphere>().orb_count++;
        Destroy(this.gameObject);
    }
}
