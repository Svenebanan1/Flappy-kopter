using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicopter_crash : MonoBehaviour
{
    public int backtomenu;
   public void OnCollisionEnter2D (Collision2D collision)
    {
        GameObject otherGameObject = collision.gameObject;
        Obstacle hitObstacle = otherGameObject.GetComponent<Obstacle>();

        if (hitObstacle != null)
        {
            SceneManager.LoadScene(backtomenu);
        }
    }


}