using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATHSCREEN : MonoBehaviour
{
    [SerializeField] private AudioSource YOUDIED;
    [SerializeField] private AudioSource DED;
    [SerializeField] private AudioSource BOOM;
    private void audiosource()
    {
        YOUDIED.Play();
        DED.Play();
        BOOM.Play();
    }
}
