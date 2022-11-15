using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public float startDelay = 1.5f;
    public float spawnMultiplier = 0;

    [Space]

    public bool spawnRedEnemies = true;
    public float redEnemySpawnDelayMin = 0.5f;
    public float redEnemySpawnDelayMax = 1;

    [Space]

    public bool spawnPurpleEnemies = true;
    public float purpleEnemySpawnDelayMin = 5;
    public float purpleEnemySpawnDelayMax = 10;

    [Space]

    public bool spawnOrangeEnemies = true;
    public float orangeEnemySpawnDelayMin = 5;
    public float orangeEnemySpawnDelayMax = 10;

    [Space]

    public bool spawnCyanEnemies = true;
    public float cyanEnemySpawnDelayMin = 5;
    public float cyanEnemySpawnDelayMax = 10;

    [Space]

    public bool spawnPinkEnemies = true;
    public float pinkEnemySpawnDelayMin = 5;
    public float pinkEnemySpawnDelayMax = 10;

    [Space]

    public bool spawnPowerups = true;
    public float powerupSpawnDelayMin = 5;
    public float powerupSpawnDelayMax = 10;

    [Space]

    public bool spawnBadStuff = true;
    public float badStuffSpawnDelayMin = 5;
    public float badStuffSpawnDelayMax = 10;

    [Space]

    public GameObject redEnemyPrefab;
    public GameObject purpleEnemyPrefab;
    public GameObject orangeEnemyPrefab;
    public GameObject cyanEnemyPrefab;
    public GameObject pinkEnemyPrefab;
    public GameObject powerupDonut;
    public GameObject badStuffPrefab;

    Player player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(SpawnRedEnemies());
        StartCoroutine(SpawnPurpleEnemies());
        StartCoroutine(SpawnOrangeEnemies());
        StartCoroutine(SpawnCyanEnemies());
        StartCoroutine(SpawnPinkEnemies());
        StartCoroutine(SpawnPowerups());
        StartCoroutine(SpawnBadStuff());
    }

    private IEnumerator SpawnRedEnemies() {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            float randomDelay = Random.Range(redEnemySpawnDelayMin, redEnemySpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnRedEnemies) StartCoroutine(Spawn(redEnemyPrefab, true));
        }
    }

    private IEnumerator SpawnPurpleEnemies() {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            float randomDelay = Random.Range(purpleEnemySpawnDelayMin, purpleEnemySpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnPurpleEnemies && player.points > 50) StartCoroutine(Spawn(purpleEnemyPrefab));
        }
    }

    private IEnumerator SpawnOrangeEnemies() {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            float randomDelay = Random.Range(orangeEnemySpawnDelayMin, orangeEnemySpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnOrangeEnemies && player.points > 100) StartCoroutine(Spawn(orangeEnemyPrefab));
        }
    }

    private IEnumerator SpawnCyanEnemies() {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            float randomDelay = Random.Range(cyanEnemySpawnDelayMin, cyanEnemySpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnCyanEnemies && player.points > 150) StartCoroutine(Spawn(cyanEnemyPrefab));
        }
    }

    private IEnumerator SpawnPinkEnemies() {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            float randomDelay = Random.Range(pinkEnemySpawnDelayMin, pinkEnemySpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnPinkEnemies && player.points >= 200) StartCoroutine(Spawn(pinkEnemyPrefab));
        }
    }

    private IEnumerator SpawnPowerups() {
        while (true)
        {
            float randomDelay = Random.Range(powerupSpawnDelayMin, powerupSpawnDelayMax);
            yield return new WaitForSeconds(randomDelay);
            if (spawnPowerups) StartCoroutine(Spawn(powerupDonut));
        }
    }

    private IEnumerator SpawnBadStuff() {
        while (true)
        {
            float randomDelay = Random.Range(badStuffSpawnDelayMin, badStuffSpawnDelayMax * spawnMultiplier);
            yield return new WaitForSeconds(randomDelay);
            if (spawnBadStuff) StartCoroutine(Spawn(badStuffPrefab));
        }
    }

    private IEnumerator Spawn(GameObject enemyType, bool multipleSpawn = false) {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPosition = spawnPoints[randomIndex].position;
        Vector2 direction = player.transform.position - randomPosition;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);

        Instantiate(enemyType, randomPosition, rotation);

        if (multipleSpawn)
        {
            if (Random.Range(1, 5) == 1) {
                yield return new WaitForSeconds(0.2f);
                Instantiate(enemyType, randomPosition, rotation);
                if (Random.Range(1, 4) == 1) {
                    yield return new WaitForSeconds(0.2f);
                    Instantiate(enemyType, randomPosition, rotation);
                    if (Random.Range(1, 3) == 1) {
                        yield return new WaitForSeconds(0.2f);
                        Instantiate(enemyType, randomPosition, rotation);
                    }
                }
            }
        }
    }
}
