using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountStars : MonoBehaviour
{
    public TMP_Text StarsText;
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

        StarsText.text = "Stars: " + gs.Stars;
    }
}
