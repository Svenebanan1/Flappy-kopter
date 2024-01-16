using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat_Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject Mat;

    private float elapsedtime;
    private void Update()
    {
        elapsedtime += Time.deltaTime;

        if (elapsedtime > 4)
        {
            SpawnObject();

            elapsedtime = 0;
        }
    }
    private void SpawnObject()
    {
        GameObject mat = Instantiate(Mat);
        mat.transform.position = new Vector2(transform.position.x, Random.Range(-4, 4));
    }
}
