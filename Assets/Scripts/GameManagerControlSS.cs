using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerControlSS : MonoBehaviour
{
    public int points;
    public Text textPoints;
    private bool isPaused = false;
    public int lives;
    public Text textLives;
    public float victoryTime = 120f;  
    private float elapsedTime = 0f;
    public int numGuardar=0;
    
    public string name="progressdata";
 [SerializeField]private ProgressData progressData;
 
    public void SaveProgress()
    {
         string json = JsonUtility.ToJson(progressData);
       
          numGuardar++;
            name=name+numGuardar;
        SaveData.Save(name+".json", json);
         print("data saved");
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Save Progress"))
        {
            SaveProgress();
        }
    }

    public void LoadProgress()
    {
        progressData = JsonUtility.FromJson<ProgressData>(SaveData.Load("progressdata2.json"));
    }
    void Start()
    {
        UpdatePoints(0);
        UpdateLives();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneVictory()
    {
            SaveProgress();
        ChangeScene("VictoryScene");
    }

    public void ChangeSceneDefeat()
    {
            SaveProgress();

        ChangeScene("DefeatScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        elapsedTime = elapsedTime + Time.deltaTime;
        if (elapsedTime >= victoryTime)
        {
            
            ChangeSceneVictory();
        }

        progressData.tiempojugado+=Time.deltaTime;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void UpdatePoints(int score)
    {
        points = points + score;
       textPoints.text="Total xp:"+progressData.totalXP;
       // textPoints.text = "Puntaje: " + points;
        progressData.totalXP+=100;
        progressData.navesderrotados++;

    }

    public void UpdateLives()
    {
        lives = lives - 1;
        textLives.text = "Vidas: " + lives;
    }

    public void PlayerDefeated()
    {
        ChangeSceneDefeat();
    }
}