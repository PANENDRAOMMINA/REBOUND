using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Sphere : Rotation_Handler
{ 

    
    
    public bool is_released, increase_force, is_auto_lock = true, wait_turn;

    public Vector3 initial_position;

    public double force_amount;
    public int level_number;
  
    public Vector3  repulse_force;

    public TMP_Text count_text;
    public int orb_count;

    public Image Fill_Amount;

    public float force_index;
   
  
    public int Force_index
    {
        get
        {
            return PlayerPrefs.GetInt("Force",20);
        }
        set
        {
            PlayerPrefs.SetInt("Force", value);
        }
    }

    public Rigidbody rb;

    public float level_meter;
    private void Awake()
    {
       
        wait_turn = false;
        initial_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        increase_force = true;

        if (FindObjectOfType<Checkpoint>() == null)
            return;
        else
            FindObjectOfType<Checkpoint>().is_checkpoint = false;
    }

  

    void Update()
    {
        Rotate();
        Release_The_Ball();
        Add_Force();
        Check_the_speed();
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (FindObjectOfType<Checkpoint>() == null)
            {
                transform.position = transform.position = FindObjectOfType<Sphere_Maintainer>().initial_position; 
                rb.velocity = Vector3.zero;
            }
            else
            {
                if (FindObjectOfType<Checkpoint>().is_checkpoint)
                {
                    transform.position = new Vector3(PlayerPrefs.GetFloat("Position_x"), PlayerPrefs.GetFloat("Position_y"), PlayerPrefs.GetFloat("Position_z"));
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    transform.position = FindObjectOfType<Sphere_Maintainer>().initial_position;
                    rb.velocity = Vector3.zero;
                }
            }
              
        }
       
      
        if(SceneManager.GetActiveScene().buildIndex>1)
        {
            var coin = "ORBS : " + orb_count.ToString();
            count_text.text = coin;
        }
    }

    private void Release_The_Ball()
    {
        if (Input.GetKey(KeyCode.Space) && !wait_turn)
        {
            is_released = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) && !wait_turn)
        {
            is_released = false;
            is_auto_lock = false;
        }
    }

   

   

    public void Add_Force()
    {
        if (is_released && is_auto_lock)
            Tune_the_force();
        else if (!is_auto_lock)
        {
            rb.AddForce(transform.forward*(float)force_amount,ForceMode.Impulse);
            is_auto_lock = true;
            Fill_Amount.fillAmount = 0.5f;
            force_amount = 0;
        }
    }
    public void Tune_the_force()
    {
        if (Fill_Amount.fillAmount < 1 && increase_force)
        {
            Fill_Amount.fillAmount += Time.deltaTime;
            force_amount = Fill_Amount.fillAmount*Force_index+3;
        }   
        else
            increase_force = false;

        if (Fill_Amount.fillAmount>0 && !increase_force)
        {
            Fill_Amount.fillAmount -= Time.deltaTime;
            force_amount = Fill_Amount.fillAmount*Force_index+3;
        }  
        else
            increase_force = true;

    }

    public void Check_the_speed()
    {
        if (rb.velocity == Vector3.zero)
        {
            wait_turn = false;
        }
        else
        {
            wait_turn = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Attractor"))
        {
            Vector3 v = Vector3.MoveTowards(new Vector3(transform.position.x,transform.position.y,transform.position.z),new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z), 0.08f);
            transform.position = v;
            Debug.Log(rb.velocity);
        }
        if(other.gameObject.CompareTag("Play")) SceneManager.LoadScene("Levels-Scene");
        if (other.gameObject.CompareTag("End"))
        {
            Application.Quit();
            Debug.Log("Exit");
        }
        if (other.gameObject.CompareTag("Settings"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (other.gameObject.CompareTag ("About")) SceneManager.LoadScene("About");
        if (other.gameObject.CompareTag("Repulsor")) 
        {
            rb.AddForce(transform.forward *4*-1*0.05f, ForceMode.Impulse);
        }
        if(other.gameObject.CompareTag("Main_Menu"))
        {
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.CompareTag("Level_tag"))
        {
            SceneManager.LoadScene("Levels Scene");
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Settings"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
