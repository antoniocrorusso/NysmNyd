using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject Player;

    Vector2 mov;

    private GameObject manager;
    private ControlledPlayer controlled;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        controlled = manager.GetComponent<ControlledPlayer>();
    }

    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            controlled.setValue(1);
            SwitchCharacter();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + mov * speed * Time.fixedDeltaTime);

    }

    public void SwitchCharacter()
    {
        Player.GetComponent<Shoot>().enabled = true;
        Player.GetComponent<Movement>().enabled = true;
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<LightMovement>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
