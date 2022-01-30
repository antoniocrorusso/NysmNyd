using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    [Header("SpawnRange")]
    private float spawnRadiusX = 11, spawnRadiusY = 9, time = 1f;
    private Vector3 size;
    
    private Score score;
    private int currentScore;
    private List<int> scoreNeeded;

    [Header("Spawned Items")]
    public GameObject recoverHeart;
    public GameObject upgradeBar;

    [Header("Base Number for Spawn Up")]
    public int baseScoreNumber;

    [Header("Difficulty Increase")]
    public GameObject enemySpawner;
    private EnemySpawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        size = new Vector3(22, 18, 0f);
        scoreNeeded = new List<int>();
        score = this.gameObject.GetComponent<Score>();
        spawn = enemySpawner.GetComponent<EnemySpawner>();
        StartCoroutine(SpawnLifeRecover());

    }

    private void Update()
    {
        currentScore = score.scoreNumber;
        GenerateMultiples();

        if (scoreNeeded.Count > 0)
        {
            if (currentScore >= scoreNeeded[0])
            {
                spawn.upSpeed();
                SpawnUpgrade();
                scoreNeeded.Remove(scoreNeeded[0]);
            }
        }
    }


    IEnumerator SpawnLifeRecover()
    {
        Vector3 origin = transform.position;
        Vector3 randomRange = new Vector3(Random.Range(-spawnRadiusX, spawnRadiusX),
                                          Random.Range(-spawnRadiusY, spawnRadiusY),
                                          0);

        Vector3 spawnPos = origin + randomRange;
        Instantiate(recoverHeart, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnLifeRecover());
    }

    void GenerateMultiples()
    {
        for (int i = 1; i <= 10; i++)
        {
            int mult = baseScoreNumber * i;
            scoreNeeded.Add(mult);
        }
    }

    void SpawnUpgrade()
    {
        Vector3 origin = transform.position;
        Vector3 randomRange = new Vector3(Random.Range(-spawnRadiusX, spawnRadiusX),
                                          Random.Range(-spawnRadiusY, spawnRadiusY),
                                          0);

        Vector3 spawnPos = origin + randomRange;
        Instantiate(upgradeBar, spawnPos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
