using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Laser : Rotation_Handler
{
    public Material material;
    Laser_Beam beam;
    public int length;
    public GameObject Sphere;

    private void Awake()
    {
        length = 5;
    }
    private void Update()
    {
        Rotate();
        Destroy(GameObject.Find("Laser Beam")); 
        beam = new Laser_Beam(gameObject.transform.position,transform.forward,material,length);
        Set_Position();
    }
    public void Set_Position()
    {
        if(FindObjectOfType<Sphere_Maintainer>().player_Destroy_on_win==false)
            transform.position = Sphere.transform.position;
    }


   
}
