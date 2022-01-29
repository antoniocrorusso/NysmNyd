using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 10, time = 30f;
    private Score score;
    private int currentScore;
    private List<int> scoreNeeded;


    public GameObject recoverHeart;
    public GameObject upgradeBar;
    public int baseScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        score = this.gameObject.GetComponent<Score>();
        StartCoroutine(SpawnLifeRecover());

    }

    private void Update()
    {
        currentScore = score.scoreNumber;
        GenerateMultiples();

        //if (currentScore >= scoreNeeded.Count)
    }


    IEnumerator SpawnLifeRecover()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
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
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(upgradeBar, spawnPos, Quaternion.identity);
    }
}
