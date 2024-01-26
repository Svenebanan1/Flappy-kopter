using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] float Range;
    [SerializeField] float Spawn_Time;
    private float elapsedtime;

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (elapsedtime > Spawn_Time)
        {
            GameObject obstacle = Instantiate(Obstacle);
            obstacle.transform.position = new Vector2(transform.position.x, Random.Range(-Range,Range));
            elapsedtime = 0;

            // Instantiatar en obstacle och ger den y positionen +/- Range
        }
    }
}
