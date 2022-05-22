using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3_TrashController : MonoBehaviour
{
    private Transform destination;

    [SerializeField]
    private float speed = 0.2f;

    void Awake()
    {
        destination = GameObject.Find("XR Origin").transform;
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
    }
}
