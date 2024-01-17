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
    public Sprite MatSprite;
    public Sprite Mat2Sprite;
    public Sprite Mat3Sprite;
    [SerializeField] float Range;
    [SerializeField] float Spawn_Time;
    private float elapsedtime;
    private bool Spawn_Mat;
    private bool randompowerup;
    private float randommat;

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (elapsedtime > Spawn_Time)
        {
            Spawn_Mat = Random.value < 0.9f;
            if (Spawn_Mat == true)
            {
                randommat = Random.value;
                GameObject mat = Instantiate(MatObject);
                mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));;
                if (randommat > 2/3f)
                {
                    MatSpriteRenderer.sprite = Mat2Sprite; 
                }
                else if (randommat > 1/3f)
                {
                    MatSpriteRenderer.sprite = Mat3Sprite;
                }
                else
                {
                    MatSpriteRenderer.sprite = MatSprite;
                }
                elapsedtime = 0;
            }
            else
            {
                randompowerup = Random.value > 0.5f;
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
    }
}
