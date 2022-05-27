using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();
    [SerializeField]
    float randomX;
    private bool Gameover;
    

    void Awake()
    {
        randomX = this.transform.position.x;
    }

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        float originalX = this.transform.position.x;
        Gameover = GameObject.Find("UTSController").GetComponent<Task4_UTSController>().Gameover;
        for (int i = 0; i < 1; i++)
        {
            if (!Gameover) {
                GameObject[] ob = new GameObject[7];
                int idx = 0;

                foreach (GameObject obj in objects)
                {
                    randomX = Random.Range(randomX - 3f, randomX + 1f);
                    Vector3 ranPosition = new Vector3(randomX, 0f, 20f);

                    GameObject spawnObject = Instantiate(obj, ranPosition, Quaternion.identity);
                    ob[idx] = spawnObject;
                    idx++;
                    spawnObject.transform.parent = GameObject.Find("TrashGroup").transform;

                    randomX = originalX;
                }
                GameObject.Find("TrashGroup").GetComponent<Task4_TrashCollider>().checkObj(ob);
            }
            yield return new WaitForSeconds(5f);
        }
        yield return null;
    }
}
