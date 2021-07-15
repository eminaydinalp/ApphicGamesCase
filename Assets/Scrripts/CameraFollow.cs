using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _player;

    [HideInInspector]
    public Vector3 distance;

    private Vector3 newPos;

    float distancey;
    float distancez;
    void Start()
    {
        distance = new Vector3(0f, 3f, -12f);

        transform.position = _player.position + distance;
    }


    private void FixedUpdate()
    {

        distancey = _player.position.y + distance.y;
        distancez = _player.position.z + distance.z;

        newPos = new Vector3(0f, distancey, distancez);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPos, 0.125f);

        transform.position = smoothedPosition;

    }
}
