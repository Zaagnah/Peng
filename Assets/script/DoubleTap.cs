using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
    [SerializeField] GameObject exitCanvas;
    [SerializeField] float waitTime;

    bool backPressedOnce;
    IEnumerator coroutine;
    void Start()
    {
        exitCanvas.SetActive(false);
        backPressedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !backPressedOnce)
        {
            ShowMessage();
        }
    }

    void ShowMessage()
    {
        backPressedOnce = true;
        exitCanvas.SetActive(true);
        coroutine = WaitCountdown();
        StartCoroutine(coroutine);

    }
    void HideMessage()
    {
        backPressedOnce = false;
        exitCanvas.SetActive(false);
        StopCoroutine(coroutine);
    }

    IEnumerator WaitCountdown()
    {
        yield return null;

        var tempTime = 0f;
        while(tempTime <= waitTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.touchCount > 0)
            {
                HideMessage();
            }
            tempTime += Time.deltaTime;
            yield return null;
        }
        HideMessage();
    }

}
