
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class RestartButton : MonoBehaviour
{
    public int currentSceneIndex;
    public int score;
    string gameId = "3978731";
  

    private void Start()
    {

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, false);
        }
        score = PlayerPrefs.GetInt("Score", score);

        }
    


    private void OnTriggerExit(Collider other)
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
        score++;
        Debug.Log(score);

        if (score == 4)
        {
            Reklama();
            Debug.Log("awdwdwdqwd");
        }
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();


    }

        public void Reklama()
        {
            if (Advertisement.IsReady("video"))
            {

                Advertisement.Show();


                score = 0;
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.Save();
            }
        }
    }
