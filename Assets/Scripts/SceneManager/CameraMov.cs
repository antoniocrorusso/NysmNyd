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
    public Vector3 offset;

    [Range(1, 10)] public float smoothFactor;

    public Vector3 minPosition;
    public Vector3 maxPosition;


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

        Vector3 tar = new Vector3(target.position.x, target.position.y, -10f);
        Vector3 targetPosition = tar + offset;

        Vector3 bounds = new Vector3(
            Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(targetPosition.z, minPosition.z, maxPosition.z));

        Vector3 Positioning = Vector3.Lerp(transform.position, bounds, smoothFactor * Time.fixedDeltaTime);

        transform.position = Positioning;

    }
}
