using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser_Beam 
{
    Vector3 pos, dir;

    GameObject laserobj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();

    

   

   public Laser_Beam(Vector3 pos,Vector3 dir,Material material,int length)
   {
        this.laser = new LineRenderer();
        this.laserobj = new GameObject();
        this.laserobj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserobj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;

        Cast_Ray(pos,dir,laser,length);
   }

    void Cast_Ray(Vector3 pos,Vector3 dir,LineRenderer laser,int length)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        
        if(Physics.Raycast(ray,out hit,5,1))
        {
            check_Hit(hit, dir, laser,length);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(length));
           
            Update_Laser();
        }
    }

    void Update_Laser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach(Vector3 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void check_Hit(RaycastHit hitInfo,Vector3 direction,LineRenderer laser,int length)
    {
        if(hitInfo.collider.gameObject.tag=="Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction,hitInfo.normal);

            Cast_Ray(pos, dir, laser,length);
        }
       
    }

}
