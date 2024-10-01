using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerControl : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject howtoplayContainer;
    public GameObject creditsContainer;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneGame()
    {
        ChangeScene("SampleScene");
    }

    public void ChangeStateHowToPlayContainer()
    {
        if (howtoplayContainer.activeSelf == true)
        {
            howtoplayContainer.SetActive(false);
            menuContainer.SetActive(true);
        }
        else
        {
            howtoplayContainer.SetActive(true);
            menuContainer.SetActive(false);
        }
    }

    public void ChangeStateCreditsContainer()
    {
        if (creditsContainer.activeSelf == true)
        {
            creditsContainer.SetActive(false);
            menuContainer.SetActive(true);
        }
        else
        {
            creditsContainer.SetActive(true);
            menuContainer.SetActive(false);
        }
    }
}