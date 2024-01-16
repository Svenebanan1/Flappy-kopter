using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mat_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Mat;
    [SerializeField] float Range;
    [SerializeField] float Spawn_Time;
    private float elapsedtime;

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (elapsedtime > Spawn_Time)
        {
            GameObject mat = Instantiate(Mat);
            mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range,Range));
            elapsedtime = 0;
        }
    }
}
