using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class foodEatMums : MonoBehaviour
{
    [SerializeField] public AudioSource eatingSound;

    // Start is called before the first frame update
    void Start()
    {
        eatingSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
