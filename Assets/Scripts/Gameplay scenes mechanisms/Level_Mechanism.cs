using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Level_Mechanism : MonoBehaviour
{
    public GameObject[] levels;
    private int level_number;


    public static Level_Mechanism _instance;

 
    // Start is called before the first frame update
    private void Awake()
    {
        level_number = PlayerPrefs.GetInt("Level_Number", 0);
        if(_instance!=null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
      
    }

    private void Start()
    {
        set_levels();
    }
    
    private void set_levels()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            switch (i > level_number)
            {
                case false:
                    levels[i].SetActive(true);
                    break;
                case true:
                    levels[i].SetActive(false);
                    break;
            }
        }
    }

}
