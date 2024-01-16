using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATHSCREEN : MonoBehaviour
{
    [SerializeField] private AudioSource YOUDIED;
    [SerializeField] private AudioSource DED;
    private void audiosource()
    {
        YOUDIED.Play();
        DED.Play();
    }
}
