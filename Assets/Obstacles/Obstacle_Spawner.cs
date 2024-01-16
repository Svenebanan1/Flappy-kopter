using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject Obstacle;

    private float elapsedtime;

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;

        if (elapsedtime > 2)
        {
            SpawnObject();

            elapsedtime = 0;
        }
    }

    private void SpawnObject()
    {
        GameObject obstacle = Instantiate(Obstacle);
        obstacle.transform.position = new Vector2(transform.position.x, Random.Range(-3, 3));
    }
}
