using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mat_Spawner : MonoBehaviour
{
    [SerializeField] GameObject Powerup1;
    [SerializeField] GameObject Powerup2;
    [SerializeField] GameObject MatObject;

    public SpriteRenderer MatSpriteRenderer;
    public Sprite Mat1Sprite;
    public Sprite Mat2Sprite;
    public Sprite Mat3Sprite;
    public Sprite Mat4Sprite;
    public Sprite Mat5Sprite;

    public float Range;
    public float Spawn_Time;

    private float elapsedtime;
    private bool Spawn_Mat;

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (elapsedtime > Spawn_Time)
        {
            Spawn_Mat = Random.value < 0.9f;
            if (Spawn_Mat == true)
            {
                SpawnMat();
            }
            else
            {
                SpawnPowerup();
            }
        }
    }

    void SpawnMat()
    {
        float randommat = Random.value;
        GameObject mat = Instantiate(MatObject);
        mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range)); ;
        if (randommat > 0.8f)
        {
            MatSpriteRenderer.sprite = Mat1Sprite;
        }
        else if (randommat > 0.6f)
        {
            MatSpriteRenderer.sprite = Mat2Sprite;
        }
        else if (randommat > 0.4f)
        {
            MatSpriteRenderer.sprite = Mat3Sprite;
        }
        else if (randommat > 0.2f)
        {
            MatSpriteRenderer.sprite = Mat4Sprite;
        }
        else
        {
            MatSpriteRenderer.sprite = Mat5Sprite;
        }
        elapsedtime = 0;
    }

    void SpawnPowerup() 
    {
        bool randompowerup = Random.value > 0.5f;
        if (randompowerup == true)
        {
            GameObject powerup = Instantiate(Powerup1);
            powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
        }
        else
        {
            GameObject powerup = Instantiate(Powerup2);
            powerup.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
        }
        elapsedtime = 0;
    }

}
