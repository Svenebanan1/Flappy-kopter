using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public int STARVINGCHILDREN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BacktoMenu", 3.15f);
    }

    void BacktoMenu()
    {
        SceneManager.LoadScene(STARVINGCHILDREN);
    }
}
