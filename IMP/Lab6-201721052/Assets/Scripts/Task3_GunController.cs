using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Task3_GunController : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    private bool GameOver = false;

    // public void OnHoverEntered(HoverEnterEventArgs args)
    // {
    //     // Debug.Log("Ray is : " + args.interactableObject.transform.gameObject.name);
    // }

    public void OnShoot(SelectEnterEventArgs args)
    {
        // Debug.Log("Selected : " + args.interactableObject.transform.gameObject.name);
        if (!GameOver)
        {
            if (args.interactableObject.transform.gameObject.tag == "Trash")
                Destroy(args.interactableObject.transform.gameObject);
            GameObject.Find("TrashGroup").GetComponent<Task3_TrashCollider>().objectsDeleted(args.interactableObject.transform.gameObject);
            GameObject.Find("TrashGroup").GetComponent<Task3_TrashCollider>().ScoreSet();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Time.timeScale = 0;
            Debug.Log("Game is Over!");
            source.Play();
            GameOver = true;
        }
    }
}
