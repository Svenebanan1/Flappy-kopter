using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mat_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Powerup1;
    [SerializeField] GameObject Powerup2;
    [SerializeField] GameObject Mat1;
    [SerializeField] GameObject Mat2;
    [SerializeField] GameObject Mat3;
    [SerializeField] float Range;
    [SerializeField] float Spawn_Time;
    private float elapsedtime;
    private bool Spawn_Mat;
    private bool randompowerup;
    private float randommat;

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (elapsedtime > Spawn_Time)
        {
            Spawn_Mat = Random.value < 0.9f;
            if (Spawn_Mat == true)
            {
                randommat = Random.value;
                if (randommat > 0.6f)
                {
                     GameObject mat = Instantiate(Mat1);
                    mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                    elapsedtime = 0;
                }
                else if (randommat > 0.3f)
                {
                    GameObject mat = Instantiate(Mat2);
                    mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                    elapsedtime = 0;
                }
                else
                {
                    GameObject mat = Instantiate(Mat3);
                    mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                    elapsedtime = 0;
                }
            }
            else
            {
                randompowerup = Random.value > 0.5f;
                if (randompowerup == true)
                {
                    GameObject powerup = Instantiate(Powerup1);
                    powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                    elapsedtime = 0;
                }
                else
                {
                    GameObject powerup = Instantiate(Powerup2);
                    powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                    elapsedtime = 0;
                }
            }
        }
    }
}
