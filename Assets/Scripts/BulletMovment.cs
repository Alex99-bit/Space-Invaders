using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovment : MonoBehaviour
{
    Rigidbody2D bulletRB;
    public float speed;

    private void OnEnable()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        Dispara();
    }

    void Dispara()
    {
        bulletRB.velocity = new Vector2(0, 1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Limit"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
