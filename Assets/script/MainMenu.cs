using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    public void LoadFirstLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(1);
    }
    public MainMenu(RestartButton player)
    {
        level = player.currentSceneIndex;
    }

    public void SavePlayer()
    {
        
       PlayerPrefs.SetInt("Level", level);
    }
    public void LoadPlayer()
    {
        //PlayerData data = SaveSystem.LoadPlayer();
        //level = data.level;
        PlayerPrefs.GetInt("Level", level).ToString();
        SceneManager.LoadScene(level);
        //SceneManager.LoadScene(data.level);
    }
    void Update()
    {
     
        
    }

}
