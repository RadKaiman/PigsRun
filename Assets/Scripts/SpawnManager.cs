using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstacleRockPrefab;
    public GameObject obstacleTreePrefab;
    public GameObject acornPrefab;
    public GameObject finishPrefab;
    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(5, 0.1f, 1);
    private Vector3 spawnPosBee = new Vector3(5, 3f, 1);
    private Vector3 spawnPosAcorn = new Vector3(5, 3, 1);
    private float startDelay = 2;
    private float startDelayObstacle = 9;
    private float startDelayRock = 4;
    private float startDelayTree = 7;
    private float startDelayFinish = 30;
    private float repeatRateObstacle = 3.3f;
    private float repeatRateObstacleRock = 5.8f;
    private float repeatRateObstacleTree = 9.2f;
    private float repeatRateAcorn = 2.6f;
    private int choice;

    public bool pauseSpawn = false;
    void Start()
    {
        repeatRateObstacle = Random.Range(3.6f, 4.4f);
        repeatRateObstacleRock = Random.Range(5.2f, 6.4f);
        repeatRateObstacleTree = Random.Range(8.6f, 9.8f);
        repeatRateAcorn = Random.Range(2.3f, 3.3f);
        playerControllerScript = GameObject.Find("pigHero").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelayObstacle, repeatRateObstacle);
        InvokeRepeating("SpawnObstacleRock", startDelayRock, repeatRateObstacleRock);
        InvokeRepeating("SpawnObstacleTree", startDelayTree, repeatRateObstacleTree);
        InvokeRepeating("SpawnArcon", startDelay, repeatRateAcorn);
        Invoke("SpawnFinish", startDelayFinish);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseSpawn == false)
        {
                Instantiate(obstaclePrefab, spawnPosBee, obstaclePrefab.transform.rotation);
        }
    }

    void SpawnObstacleRock()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseSpawn == false)
        {
            Instantiate(obstacleRockPrefab, spawnPos, obstacleRockPrefab.transform.rotation);
        }
    }

    void SpawnObstacleTree()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseSpawn == false)
        {
            Instantiate(obstacleTreePrefab, spawnPos, obstacleTreePrefab.transform.rotation);
        }
    }

    void SpawnArcon()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseSpawn == false)
        {
                Instantiate(acornPrefab, spawnPosAcorn, acornPrefab.transform.rotation);
        }
    }

    void SpawnFinish()
    {
        if (playerControllerScript.gameOver == false && playerControllerScript.win == false && pauseSpawn == false)
        {
                Instantiate(finishPrefab, spawnPos, finishPrefab.transform.rotation);
        }
    }
}
