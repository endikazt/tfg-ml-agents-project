using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class CompanionArea : MonoBehaviour
{
    
    public GameObject player;
    public Transform playerStartPoint;
    public GameObject firstEnemy;
    public Transform firstEnemyStartPoint;
    public GameObject secondEnemy;
    public Transform secondEnemyStartPoint;
    public GameObject[] moveSpots;
    public GameObject lifeCube;
    public Text playerLifeText;
    public Text scoreText;
    public Text enemyKilledText;
    public float playerLifePoints;
    public float score;
    public float enemyKilledCounter; 
    public float lastEnemyKilledValue;
    public float lastScore;
    public float lastPlayerLifePoints;

    public void ResetArea()
    {
        score = 0;
        playerLifePoints = 100;
        enemyKilledCounter = 0;
        
        playerLifeText.text = "Player Life: " + playerLifePoints;
        scoreText.text = "Collectibles: " + score;
        enemyKilledText.text = "Enemy killed: " + enemyKilledCounter;

        lastScore = score;
        lastPlayerLifePoints = playerLifePoints;
        lastEnemyKilledValue = enemyKilledCounter;

         foreach (var spot in moveSpots)
        {
            spot.SetActive(true);
        }

        lifeCube.SetActive(true);

        DestroyLifeCubeThrowable();

        player.SetActive(true);
        player.transform.position = playerStartPoint.transform.position;
        firstEnemy.transform.position = firstEnemyStartPoint.transform.position;
        secondEnemy.transform.position = secondEnemyStartPoint.transform.position;

    }

    public void DestroyLifeCubeThrowable()
    {
        GameObject[] lifeCubes = GameObject.FindGameObjectsWithTag("Life Cube Throwable");
        foreach(GameObject lifeCube in lifeCubes)
        GameObject.Destroy(lifeCube);
    }

}
