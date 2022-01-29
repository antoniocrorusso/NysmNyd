using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //For effect later
    //public GameObject hit;

    Vector2 initialPos;
    public Vector2 range;


    private GameObject manager;
    private Score score;

    private void Start()
    {
        initialPos = this.transform.position;
        manager = GameObject.FindGameObjectWithTag("Manager");
        score = manager.GetComponent<Score>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            //GameObject effect = Instantiate(hit, transform.position, Quaternion.identity);
            score.increaseScore(5);
            Destroy(this.gameObject);
            //Destroy(effect, 5f);
        }

    }

    private void Update()
    {
        if (Vector2.Distance(initialPos, this.transform.position) > Vector2.Distance(initialPos, range))
        {
            Destroy(this.gameObject);
        }
    }
}
