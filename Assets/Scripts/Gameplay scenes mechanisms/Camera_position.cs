using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_position : MonoBehaviour
{

    public float Min_x,Max_x;
    public float Min_z,Max_z;
    public float Height;
    public Transform Finish;
    [SerializeField]
    private bool _show_finish;
    private Vector3 _finish;

    public float time;

    public float show_time;

    public float far_distance;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _finish = new Vector3(Finish.position.x, Height, Finish.position.z);
        if (SceneManager.GetActiveScene().buildIndex>1)
            StartCoroutine(Show_Finish(show_time));
    }


    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<Sphere_Maintainer>().player_Destroy||(!FindObjectOfType<Win_Stone>().win&&FindObjectOfType<Win_Stone>()!=null))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {

                Vector3 v = FindObjectOfType<Sphere>().transform.position;

                if (v.x < Max_x && v.x > Min_x && v.z > Min_z && v.z < Max_z)
                {
                    Vector3 camera_position = v + new Vector3(0, Height, -2);
                    transform.position = camera_position;
                }
                if (_show_finish)
                {
                    time += Time.deltaTime;
                    transform.position = Vector3.Lerp(v + new Vector3(0, Height, far_distance), _finish, time);
                }
                else
                {
                    time += Time.deltaTime;
                    transform.position = Vector3.Lerp(_finish, v + new Vector3(0, Height, far_distance), time);
                }
            }
            else
            {
                Vector3 v = FindObjectOfType<Sphere>().transform.position;
                if (v.x < Max_x && v.x > Min_x && v.z > Min_z && v.z < Max_z)
                {
                    Vector3 camera_position = v + new Vector3(0, Height, 0);
                    transform.position = camera_position;
                }
            }
        }
      
    }

 

    IEnumerator Show_Finish(float time)
    {
        _show_finish = true;
        yield return new WaitForSecondsRealtime(time);
        Set_time_zero();
        _show_finish = false;
    }

    public void Set_time_zero()
    {
        time = 0;
    }

}
