using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_TrashCollider : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    private int score = 0;

    public void checkObj(GameObject[] input)
    {
        foreach (GameObject obj in input)
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
            //
            Debug.Log("Victory!");
            Debug.Log("Level 3 Cleared!");
            Time.timeScale = 0;
        }
    }

    public void objectsDeleted(GameObject obj)
    {
        objects.Remove(obj);
    }
}
