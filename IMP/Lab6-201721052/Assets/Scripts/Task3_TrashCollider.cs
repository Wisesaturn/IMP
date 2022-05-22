using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3_TrashCollider : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    [SerializeField]
    private AudioSource source;
    private int score = 0;

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash"))
            objects.Add(obj);
    }

    public void ScoreSet()
    {
        score++;
        Debug.Log("Killed an enemy! Points : " + score);
        Debug.Log("Remaining points : " + objects.Count);

        // Game End
        if (objects.Count == 0)
        {
            source.Play();
            Debug.Log("Victory!");
            Debug.Log("Level 2 Cleared!");
            Time.timeScale = 0;
        }
    }

    public void objectsDeleted(GameObject obj)
    {
        objects.Remove(obj);
    }


}
