using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed;

    private GameObject manager;
    private Score score;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Light").GetComponent<Transform>();
        manager = GameObject.FindGameObjectWithTag("Manager");
        score = manager.GetComponent<Score>();
        health = manager.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //Add stop distance?
        //if (Vector2.Distance(transform.position, target.position) > 3)
        //{
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //Add explosion effects later.
            //GameObject effect = Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //Destroy(effect, 5f);
        }

        if (collision.gameObject.layer == 10)
        {
            //Add explosion effects later.
            //GameObject effect = Instantiate(hit, transform.position, Quaternion.identity);

            score.decreaseScore(3);
            health.damageHeart();
            Destroy(this.gameObject);
            //Destroy(effect, 5f);
        }

    }
}
