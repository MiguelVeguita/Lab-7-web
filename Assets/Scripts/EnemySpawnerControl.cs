using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerControl : MonoBehaviour
{
    public float minXPosition;
    public float maxXPosition;
    public GameObject objEnemeyPref;
    public float minTime;
    public float maxTime;
    public GameManagerControlSS gameManager;

    void Start()
    {
        float time = Random.Range(minTime, maxTime);
        Invoke("CreateEnemy", time);
    }

    void CreateEnemy()
    {
        float x = Random.Range(minXPosition, maxXPosition);
        Vector2 position = new Vector2(x, 6.5f);
        GameObject enemy = Instantiate(objEnemeyPref,position, objEnemeyPref.transform.rotation);
        float time = Random.Range(minTime, maxTime);
        enemy.GetComponent<EnemiesControl>().SetGameManager(gameManager);
        Invoke("CreateEnemy", time);
    }
}