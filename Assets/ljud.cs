using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ljud : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource helikopter;

    private void Start()
    {
        //Spela helikopter ljud när man startar scenen
        helikopter.Play();
    }

    // Update is called once per frame
     private void Update()
    {

       
        //Hoppljud när man trycker space
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jump.Play();
        }
    }
}
