using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Stone : MonoBehaviour
{

    
    public int level_number;
    public GameObject win_canvas;
    public bool win;
    private GameObject sphere;

    public Transform finish_particles;

    private void Awake()
    {
        win = false;
        sphere = GameObject.Find("Sphere");
        finish_particles.GetComponent<ParticleSystem>().Pause();
    }

    public void OnCollisionEnter(Collision collision)  
    {
        if(collision.gameObject.CompareTag("Sphere"))
        {
            win = true;
            Cursor.visible = true;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            FindObjectOfType<Sphere_Maintainer>().player_Destroy_on_win = true;
            FindObjectOfType<Sphere_Maintainer>().player_Destroy = false;
            enable_win_particles();
            Destroy(collision.gameObject, 0.6f);
            StartCoroutine(Enable_win_canvas(2f));
        }
    }

    IEnumerator Enable_win_canvas(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        win_canvas.SetActive(true);
    }
    public void enable_win_particles()
    {
        Vector3 v = sphere.transform.position;
        finish_particles.transform.position = v;
        finish_particles.GetComponent<ParticleSystem>().Play();
    }

}
