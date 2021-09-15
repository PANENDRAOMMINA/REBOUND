using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Handler : MonoBehaviour
{
    public GameObject mouse,Origin;
    public Vector3 mouse_position, Origin_Position;


    public void Rotate()
    {
        mouse_position = mouse.transform.position;
        Origin_Position = Origin.transform.position;
        Quaternion Target_Rotation = Quaternion.LookRotation(mouse_position - Origin_Position);
        Target_Rotation.x = 0;
        Target_Rotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Target_Rotation, 5f * Time.deltaTime);
    }
   
}
