using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sceneload(3));
    }

    IEnumerator sceneload(float time)
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(PlayerPrefs.GetString("Level_Name"));
    }

 
}
