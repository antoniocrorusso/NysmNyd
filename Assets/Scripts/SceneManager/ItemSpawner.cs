using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    [Header("SpawnRate")]
    private float spawnRadius = 10, time = 30f;
    
    private Score score;
    private int currentScore;
    private List<int> scoreNeeded;

    [Header("Spawned Items")]
    public GameObject recoverHeart;
    public GameObject upgradeBar;

    [Header("Base Number for Spawn Up")]
    public int baseScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        scoreNeeded = new List<int>();
        score = this.gameObject.GetComponent<Score>();
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
                SpawnUpgrade();
                scoreNeeded.Remove(scoreNeeded[0]);
            }
        }
    }


    IEnumerator SpawnLifeRecover()
    {
        Vector2 spawnPos = this.gameObject.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

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
        Vector2 spawnPos = this.gameObject.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(upgradeBar, spawnPos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
