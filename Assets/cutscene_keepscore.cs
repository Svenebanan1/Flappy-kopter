using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene_keepscore : MonoBehaviour
{
    public int STARVINGCHILDREN;
    public TMP_Text CollectedFoodText;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameStatus");
        if (go == null)
        {
            this.enabled = false;
            return;
        }
        GameStatus gs = go.GetComponent<GameStatus>();
        CollectedFoodText.text = "Collected Food: " + gs.MenuFood;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(STARVINGCHILDREN);
    }
}
