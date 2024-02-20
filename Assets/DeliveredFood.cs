using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveredFood : MonoBehaviour
{
    public TMP_Text DeliveredFoodText;
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

        DeliveredFoodText.text = "Delivered Food: " + gs.DeliveredFood;
    }
}
