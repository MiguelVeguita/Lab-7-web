using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerControlDS : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeSceneMenu()
    {
        ChangeScene("OpeningScene");
    }

    public void ChangeSceneGame()
    {
        ChangeScene("SampleScene");
    }
}