using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f, speed = 0.5f;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        GameObject enemyClone;

        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        enemyClone = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        enemyClone.SetActive(true);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }

    public void upSpeed()
    {
        speed += 0.5f;
        enemies[0].GetComponent<Enemy>().setSpeed(speed);
        enemies[1].GetComponent<Enemy2>().setSpeed(speed);
    }
}
