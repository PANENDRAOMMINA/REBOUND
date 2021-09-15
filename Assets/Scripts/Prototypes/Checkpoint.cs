using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Checkpoint instance;

    public bool is_checkpoint;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        PlayerPrefs.DeleteKey("Position_x");
        PlayerPrefs.DeleteKey("Position_y");
        PlayerPrefs.DeleteKey("Position_z");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Sphere"))
        {
            PlayerPrefs.SetFloat("Position_x",transform.position.x);
            PlayerPrefs.SetFloat("Position_y",transform.position.y);
            PlayerPrefs.SetFloat("Position_z",transform.position.z);
            is_checkpoint = true;
        }
    }
}
