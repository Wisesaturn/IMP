using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2_TrashCollider : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();
    [SerializeField]
    private AudioSource source = new AudioSource();
    private int score = 0;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject obj in objects)
        {
            if (collision.gameObject == obj)
            {
                objects.Remove(obj);
                break;
            }
        }

        Destroy(collision.gameObject);
        score++;
        Debug.Log("Trash Destroyed! Points now : " + score);
        Debug.Log("Trash Left : " + objects.Count);
        source.Play();

        if (objects.Count == 0)
        {
            Debug.Log("Level 1 Cleared!");
            Time.timeScale = 0;
        }
    }
}
