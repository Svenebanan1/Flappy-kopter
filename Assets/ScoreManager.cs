using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private void Update()
    {
        GameObject go = GameObject.Find("GameStatus");


        GameStatus gs = go.GetComponent<GameStatus>();

        scoreText.text = "Collected Food: " + gs.Score;
    }



}
