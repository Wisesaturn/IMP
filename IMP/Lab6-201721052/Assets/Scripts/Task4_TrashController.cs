using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_TrashController : MonoBehaviour
{
    private Transform destination;

    [SerializeField]
    private float speed = 0.2f;
    [SerializeField]
    private int life = 1;

    void Awake()
    {
        destination = GameObject.Find("XR Origin").transform;
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
    }

    public int lifeSet()
    {
        life--;
        return life;
    }
}
