using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    private GameObject manager;
    private ControlledPlayer cplayer;

    public Transform player;
    public Transform light;

    private Transform target;
    public Vector2 offset;

    [Range(1, 10)] public float smoothFactor;

    public Vector2 minPosition;
    public Vector2 maxPosition;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        cplayer = manager.GetComponent<ControlledPlayer>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (cplayer.isPlayer)
        {
            target = player;
        } else
        {
            target = light;
        }

        Vector2 tar = new Vector2(target.position.x, target.position.y);
        Vector2 targetPosition = tar + offset;

        Vector2 bounds = new Vector2(
            Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y));

        Vector2 Positioning = Vector2.Lerp(transform.position, bounds, smoothFactor * Time.fixedDeltaTime);

        transform.position = Positioning;

    }
}
