using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_UTSController : MonoBehaviour
{
    public bool Gameover = false;

    public void GrabUTS() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Trash");
        foreach (GameObject obj in objects)
            Destroy(obj);
        
        Debug.Log("Level 3 Cleared!");
        Gameover = true;
        // Time.timeScale = 0;
        Application.Quit();
    }
}
