using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightening : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        lightening();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public IEnumerator lightening()
    {
        //FindObjectOfType<Audio_sounds>().Play("Lightening");
        miniflash(0.5f);
        miniflash(1);
        miniflash(0.5f);
        miniflash(0.75f);
        miniflash(1);
        yield return new WaitForSecondsRealtime(10);
        lightening();

    }
    private IEnumerator miniflash(float a)
    {
        this.GetComponent<Light>().intensity = a;
        yield return new WaitForSecondsRealtime(1);
    }
}
