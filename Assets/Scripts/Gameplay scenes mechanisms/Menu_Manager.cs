using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
   

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex > 4)
            Cursor.visible = false;
        else
            Cursor.visible = true;
    }

    public void Game_to_menu()
    {
        SceneManager.LoadScene("Levels scene");
        PlayerPrefs.DeleteKey("Force");
    }
    
    public void Level_win(int number)
    {
        if (PlayerPrefs.GetInt("Level_Number", 0) < number)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Level_Number", number);
        }
    }

    public void  Menu()
    {
        SceneManager.LoadScene("Main Menu");
        
       
    }
}
