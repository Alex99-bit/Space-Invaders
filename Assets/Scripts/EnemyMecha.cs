using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMecha : MonoBehaviour
{
    Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        StartCoroutine(enemyShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemyShoot()
    {
        while (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            yield return new WaitForSeconds(1);
            Disparo();
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