using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Wall : MonoBehaviour
{
    public Vector3 last_velocity;

    public void Update()
    {
        if(FindObjectOfType<Sphere>()!=null)
            last_velocity = FindObjectOfType<Sphere>().GetComponent<Rigidbody>().velocity;
    }



    public void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.CompareTag("Sphere"))
        {
            var speed = last_velocity.magnitude;
            var direction = Vector3.Reflect(last_velocity.normalized,collision.contacts[0].normal);
            FindObjectOfType<Audio_sounds>().Play("Bounce");
            FindObjectOfType<Sphere>().GetComponent<Rigidbody>().velocity=direction*Mathf.Max(speed,0f);
         }
    }
}
