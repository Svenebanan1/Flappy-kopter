using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text CollectedFoodText;
    private void Update()
    {
        GameObject go = GameObject.Find("GameStatus");

        if (go == null)
        {
            this.enabled = false;
            return;
        }

        GameStatus gs = go.GetComponent<GameStatus>();

        CollectedFoodText.text = "Collected Food: " + gs.CollectedFood;
    }



}
