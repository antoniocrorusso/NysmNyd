using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : MonoBehaviour
{
    private GameObject manager;
    private Health health;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        health = manager.GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            health.increaseHealthbar();
            //Efeitinho
            Destroy(this.gameObject);
        }
    }
}