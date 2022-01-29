using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
