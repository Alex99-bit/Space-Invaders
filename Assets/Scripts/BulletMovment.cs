using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovment : MonoBehaviour
{
    Rigidbody2D bulletRB;
    public float speed;
    public bool bulletPlayer;

    private void OnEnable()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        Dispara();
    }

    private void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.menu)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Dispara()
    {
        if (bulletPlayer)
        {
            bulletRB.velocity = new Vector2(0, 1) * speed;
        }
        else
        {
            bulletRB.velocity = new Vector2(0, -1) * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletPlayer)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Limit") || collision.gameObject.CompareTag("BulletEnemy"))
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Limit") || collision.gameObject.CompareTag("Bullet"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
