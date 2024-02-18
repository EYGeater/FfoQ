using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("General")]
    public ObjectPool enemyPool;
    public EnemySpawner[] spawners;

    [Header("Enemies")]
    [Tooltip("The amount of enemies that can be alive at one time.")]
    public int concurrentEnemyLimit;
    public int round1EnemyHealth;
    public int roundEnemyCountConstant;
    [Tooltip("Every X rounds, the enemy health will increase by the roundHPIncreaseMultiplier.")]
    public int roundHPIncreaseIntervals;
    public float hpIncreaseMultiplier;
    [Tooltip("[(roundCountMultiplier * round] + round1Count) enemies spawn per round")]
    public float roundCountMultiplier;

    [Header("Spawning")]
    [Tooltip("Time in seconds between spawns")]
    public float startingSpawnRate;
    public float spawnRateDecrement;
    public float minimumSpawnRate;

    [Header("Extra")]
    public float timeBetweenRounds;
    public float timeBeforeFirstRound;

    private float spawnRate;

    private int roundEnemyHealth;
    private int roundEnemyCount;

    private int enemiesRemaining;
    private int enemiesSpawned;

    private int round = 0;

    //data
    private const string TOTAL_ROUNDS = "TOTAL_ROUNDS";
    private const string HIGHEST_ROUND = "HIGHEST_ROUND";

    private void Start()
    {
        //roundEnemyHealth = round1EnemyHealth;
        //roundEnemyCount = round1EnemyCount;

        spawnRate = startingSpawnRate;
        if (minimumSpawnRate <= 0) minimumSpawnRate = 0.1f;

        Invoke(nameof(StartRound), timeBeforeFirstRound);
    }

    public void StartRound()
    {
        round++;
        //interval round
        if(round % roundHPIncreaseIntervals == 0)
        {
            roundEnemyHealth = (int)(roundEnemyHealth * hpIncreaseMultiplier);
        }
        roundEnemyCount = roundEnemyCountConstant + (int)(round * roundCountMultiplier);

        spawnRate -= spawnRateDecrement;
        if (spawnRate < minimumSpawnRate) spawnRate = minimumSpawnRate;

        enemiesRemaining = roundEnemyCount;
        enemiesSpawned = 0;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (enemiesSpawned < roundEnemyCount)
        {
            yield return new WaitForSeconds(spawnRate);
            if (enemiesSpawned < concurrentEnemyLimit)
                SpawnEnemy();
            else
                yield return new WaitForSeconds(spawnRate);
        }
    }

    public void SpawnEnemy()
    {
        enemiesSpawned++;
        GameObject enemy = enemyPool.PullFromPool();
        enemy.SetActive(true);
        enemy.GetComponent<BaseEnemy>().ResetEnemy(roundEnemyHealth);

        EnemySpawner tmp = spawners[Random.Range(0, spawners.Length - 1)];

        enemy.transform.position = tmp.spawnPoint.transform.position;
    }

    public void EnemyDied()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        Debug.Log("Round ended");
        PlayerPrefs.SetInt(TOTAL_ROUNDS, PlayerPrefs.GetInt(TOTAL_ROUNDS, 0) + 1);
        if (round > PlayerPrefs.GetInt(HIGHEST_ROUND, 0)) PlayerPrefs.SetInt(HIGHEST_ROUND, round);
        StartCoroutine(EndRoundRoutine());
    }

    private IEnumerator EndRoundRoutine()
    {
        StopAllCoroutines();
        //play end round music

        //update round counter

        yield return new WaitForSeconds(timeBetweenRounds);
        StartRound();
    }
}
