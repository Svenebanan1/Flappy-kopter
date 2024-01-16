using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Powerup1;
    [SerializeField] GameObject Powerup2;
    [SerializeField] float Range;
    [SerializeField] float Spawn_Time;
    private float elapsedtime;
    private bool randompowerup;
    void Update()
    {
        randompowerup = Random.value > 0.5;
        elapsedtime += Time.deltaTime;

        if (elapsedtime > Spawn_Time)
        {
            if (randompowerup == true)
            {
                GameObject powerup = Instantiate(Powerup1);
                powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                elapsedtime = 0;
            }
            if (randompowerup == false)
            {
                GameObject powerup = Instantiate(Powerup2);
                powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
                elapsedtime = 0;
            }
        }
    }
}
