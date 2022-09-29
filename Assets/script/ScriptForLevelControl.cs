using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptForLevelControl : MonoBehaviour
{
    public int level;
    public void LoadFirstLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(1);
    }

    public void LoadLevel()
    {
        level = PlayerPrefs.GetInt("Level", level);
        SceneManager.LoadScene(level);
    }
}
