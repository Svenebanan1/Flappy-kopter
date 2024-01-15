using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DÖD : MonoBehaviour
{
    int hp = 1;
    // Start is called before the first frame update

    void Start()

    {

    }
    public void TakeDamage()
    {
        hp -= 1;
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGameObject3 = collision.gameObject;
        nr hitnr = otherGameObject3.GetComponent<nr>();
        if (hitnr != null)
        {
            hitnr.TakeDamage();
        }
    }
}
