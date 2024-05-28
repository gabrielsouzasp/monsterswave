using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Controller : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject EnemyLv2Prefab;
    public GameObject EnemyLv3Prefab;
    public GameObject BossPrefab;
    public GameObject BossLv2Prefab;
    public GameObject BossLv3Prefab;
    public GameObject BoardPrefab;
    public GameObject PlayerLifeObject;
    public GameObject InfiniteObject;
    public GameObject GameOverObject;
    public GameObject GameNextLevelObject;
    public GameObject GameFinishedObject;
    public float enemyNextSpawn = 0f;
    public float boardNextSpawn = 0f;
    private float roadNextSpawn = 0f;
    List<Vector3> boardPositions = new()
    {
        new Vector3(-12.62f, 0.805f, 1.68f),
        new Vector3(-12.62f, 0.805f, -1.68f),
    };
    private static int totalEnemiesSpawned = 0;
    private float currentSpawnInterval = 0.2f;
    public int maxSpawn = 51;
    public static int PlayerLifeCount = 10;
    private bool spawnedBoss = false;
    public static bool GameOver = false;
    public static bool BossDefeated = false;
    private GameObject currentRailObjectInstance;
    public static bool GameFinished = false;
    public static bool LastLevel = false;
    public static string LoadLevelScene = "Level1";
    public static int BossHp = 0;

    private void Start()
    {
        BoardController.playerCount = 1;
        PlayerLifeCount = 20;
        spawnedBoss = false;
        GameOver = false;
        BossDefeated = false;
        BossHp = 11000;
        BaseScript.LoadLevelScene = "Level3";
    }

    private void Update()
    {
        SpawnEnemy();
        SpawnBoard();
        ShowLifeText();
        SpawnRoad();

        if (PlayerLifeCount <= 0)
            GameOver = true;

        if (GameOver)
        {
            GameOverObject.SetActive(true);
            BaseScript.LoadLevelScene = "Level1";
            Invoke("LoadMenuScene", 2f);
        }
        else
            GameOverObject.SetActive(false);


        if (!GameObject.FindGameObjectsWithTag("Player").Any())
            GameOver = true;

        if (BossDefeated)
        {
            GameNextLevelObject.SetActive(true);
            Invoke("LoadLoadingScene", 6f);
        }
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    void LoadLoadingScene()
    {
        SceneManager.LoadScene("Loading");
    }

    void SpawnEnemy()
    {
        if (Time.time >= enemyNextSpawn)
        {

            if (totalEnemiesSpawned == maxSpawn)
            {
                if (!spawnedBoss)
                {
                    StartCoroutine(SpawnBossAfterDelay(5f));
                    spawnedBoss = true;
                }
            }

            if (!spawnedBoss)
            {
                Instantiate(EnemyLv2Prefab, new Vector3(Random.Range(-10f, -20.5f), 0.5f, Random.Range(-2.2f, 2.2f)), Quaternion.Euler(0, 90, 0));

                totalEnemiesSpawned++;

                if (totalEnemiesSpawned % 50 == 0)
                {
                    currentSpawnInterval -= 0.05f;
                    if (currentSpawnInterval < 0.01f)
                    {
                        currentSpawnInterval = 0.01f;
                    }
                }

                enemyNextSpawn = Time.time + currentSpawnInterval;
            }
        }
    }

    IEnumerator SpawnBossAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(BossLv2Prefab, new Vector3(-13f, 0.5f, 0.08f), Quaternion.Euler(0, 90, 0));
    }

    void SpawnBoard()
    {
        if (Time.time >= boardNextSpawn)
        {
            if (BoardController.playerCount > 23 || spawnedBoss)
                return;

            var boardPosition = boardPositions[Random.Range(0, boardPositions.Count)];
            Instantiate(BoardPrefab, boardPosition, Quaternion.Euler(0, 0, 0));
            boardNextSpawn = Time.time + 1.5f;
        }
    }

    void SpawnRoad()
    {
        if (Time.time >= roadNextSpawn)
        {
            if (currentRailObjectInstance != null)
                if (currentRailObjectInstance.transform.position.x > 32)
                    Destroy(currentRailObjectInstance);

            currentRailObjectInstance = Instantiate(InfiniteObject, new Vector3(-66.12f, 0.658f, 3.22f), Quaternion.Euler(0, 0, 0));
            roadNextSpawn = Time.time + 9.6f;
        }
    }

    void ShowLifeText()
    {
        var lifesText = PlayerLifeObject.GetComponent<TMP_Text>();
        var lifeCount = PlayerLifeCount < 0 ? 0 : PlayerLifeCount;

        if (lifesText != null)
            lifesText.text = $"Lifes : {lifeCount}";

    }
}
