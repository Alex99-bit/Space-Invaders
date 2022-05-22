using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMecha : MonoBehaviour
{
    Rigidbody2D enemyRB;
    float cooldownMove;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        StartCoroutine(enemyShoot());
        cooldownMove = 0;
    }

    private void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) 
        {
            // Movimiento de los enemigos
            cooldownMove += Time.deltaTime;
            if (cooldownMove >= 3f)
            {
                //playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);
                // Aqui baja el enemigo
                enemyRB.velocity = new Vector2(0 * speed, -2 * speed);
                cooldownMove = 0;
            }
            else
            {
                enemyRB.velocity = new Vector2(0 * speed, 0 * speed);
            }
        }
        else if(GameManager.sharedInstance.currentGameState == GameState.menu)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator enemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (GameManager.sharedInstance.currentGameState == GameState.inGame)
            {
                Disparo();
            }
        }
    }

    void Disparo()
    {
        //Esta función toma el objeto desactivado disponible
        //Para utilizarlo al gusto
        GameObject bullet = ObjectPooler.instance.GetPooledObjectEnemy();
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
            bullet.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Se destruye y se da 12 pts
            Destroy(gameObject);
            GameManager.sharedInstance.SetScore(GameManager.sharedInstance.GetScore() + 12);
        }
    }
}