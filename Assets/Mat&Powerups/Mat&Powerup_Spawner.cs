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
            // 90% chans att skripten spawnar mat och 10% chans att den spawnar en powerup

            elapsedtime = 0;
        }
    }

    void SpawnMat()
    {
        GameObject mat = Instantiate(MatObject);
        mat.transform.position = new Vector2(transform.position.x, Random.Range(-Range, Range));
        // Instantiatar mat objectet och sätter dens y position till +/- Range.

        float randommat = Random.value;
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
        // Mat objectets sprite har en 20% chans att ändras till respektive mat sprite.
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
        // Instantaiatar Powerup1 eller Powerup2 med en 50/50 chans
    }

}
