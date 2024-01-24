using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WHATEVER : MonoBehaviour
{
    public int Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BackToMenu", 3.5f);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(Menu);
    }
}
