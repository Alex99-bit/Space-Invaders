using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMecha : MonoBehaviour
{
    Rigidbody2D playerRB;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        speed = 9.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Solo se ejecuta en caso de que este en modo jugar
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            Movimiento();
            Disparo();
        }
        else if(GameManager.sharedInstance.currentGameState == GameState.menu)
        {
            // Si esta en el menu inicial, restaura todo
            GameManager.sharedInstance.SetVida(5);
            GameManager.sharedInstance.SetScore(0);
        }
    }

    void Movimiento()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);
    }

    void Disparo()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject bullet = ObjectPooler.instance.GetPooledObjectPlayer();
            if (bullet != null)
            {
                bullet.transform.position = this.transform.position;
                //bullet.transform.rotation = this.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            // Daño
            GameManager.sharedInstance.SetVida(GameManager.sharedInstance.GetVida() - 1);
        }

        if(GameManager.sharedInstance.GetVida() <= 0)
        {
            // Game over
            GameManager.sharedInstance.currentGameState = GameState.gameOver;
        }
    }
}
