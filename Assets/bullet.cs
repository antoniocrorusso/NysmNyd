using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //For effect later
    //public GameObject hit;

    Vector2 initialPos;
    public Vector2 range;

    private void Start()
    {
        initialPos = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //GameObject effect = Instantiate(hit, transform.position, Quaternion.identity);
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
