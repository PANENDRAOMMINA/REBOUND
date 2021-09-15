using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Sphere_Maintainer : MonoBehaviour
{
    public GameObject Prefab_Sphere;
    public GameObject Sphere;

    public bool player_Destroy;

    public GameObject Pause_Canvas;

    public Vector3 initial_position;

    public Transform lose_particles;


    public Image fill_amount;
    public GameObject mouse;
    public TMP_Text count_text;


    public void Awake()
    {
        initial_position = Sphere.transform.position;
       
    }
    public void Start()
    {
        lose_particles.GetComponent<ParticleSystem>().Pause();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&player_Destroy)
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            { 
                if (FindObjectOfType<Checkpoint>() == null) {
                    GameObject sphere = Instantiate(Prefab_Sphere, initial_position, Quaternion.identity);
                    sphere.GetComponent<Sphere>().mouse = mouse;
                    sphere.GetComponent<Sphere>().count_text = count_text;
                    sphere.GetComponent<Sphere>().Fill_Amount = fill_amount;
                    sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else 
                {
                     if(FindObjectOfType<Checkpoint>().is_checkpoint) {
                        GameObject sphere = Instantiate(Prefab_Sphere, new Vector3(PlayerPrefs.GetFloat("Position_x"), PlayerPrefs.GetFloat("Position_y"), PlayerPrefs.GetFloat("Position_z")), Quaternion.identity);
                        sphere.GetComponent<Sphere>().mouse = mouse;
                        sphere.GetComponent<Sphere>().count_text = count_text;
                        sphere.GetComponent<Sphere>().Fill_Amount = fill_amount;
                        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
                     }
                     else
                    {
                        GameObject sphere = Instantiate(Prefab_Sphere, initial_position, Quaternion.identity);
                        sphere.GetComponent<Sphere>().mouse = mouse;
                        sphere.GetComponent<Sphere>().count_text = count_text;
                        sphere.GetComponent<Sphere>().Fill_Amount = fill_amount;
                        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                player_Destroy = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex > 0&&!FindObjectOfType<Win_Stone>().win)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Pause_Canvas.SetActive(true);
                Time.timeScale = 0.05f;
            }
        }
    }


    public void Resume()
    {
        Cursor.visible = false;
        Pause_Canvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void enable_lose_particles()
    {
        Vector3 v = Sphere.transform.position;
        lose_particles.transform.position = v;
        lose_particles.GetComponent<ParticleSystem>().Play();
    }

}
