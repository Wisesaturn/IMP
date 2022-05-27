using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3_Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();
    [SerializeField]
    float randomX;
    [SerializeField]
    float randomZ;

    void Awake()
    {
        randomX = this.transform.position.x;
        randomZ = this.transform.position.z;
    }

    void Start()
    {
        float originalX = this.transform.position.x;
        float originalZ = this.transform.position.z;

        foreach (GameObject obj in objects)
        {
            randomX = Random.Range(randomX - 1, randomX + 1);
            randomZ = Random.Range(randomZ - 1, randomZ + 1);
            Vector3 ranPosition = new Vector3(randomX, 0f, randomZ);

            GameObject spawnObject = Instantiate(obj, ranPosition, Quaternion.identity);
            GameObject.Find("TrashGroup").GetComponent<Task3_TrashCollider>().checkObj(spawnObject);
            spawnObject.transform.parent = GameObject.Find("TrashGroup").transform;

            randomX = originalX;
            randomZ = originalZ;
        }

    }
}
