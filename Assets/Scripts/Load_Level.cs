using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour
{
    public int number;
    public Transform finish_particles;
    public Transform sphere;

    public void Awake()
    {
        finish_particles.GetComponent<ParticleSystem>().Pause();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Sphere"))
        {
            var level_name = "LEVEL " + number.ToString();
            FindObjectOfType<Sphere>().GetComponent<Rigidbody>().velocity=Vector3.zero;
            enable_win_particles();
            Destroy(other.gameObject, 1f);
            PlayerPrefs.SetString("Level_Name", level_name);
            PlayerPrefs.DeleteKey("Max_Force");
            StartCoroutine(Wait(4f));
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("Loading_Scene");
    }
  
    public void enable_win_particles()
    {
        Vector3 v = sphere.transform.position;
        finish_particles.transform.position = v;
        finish_particles.GetComponent<ParticleSystem>().Play();
    }
}
