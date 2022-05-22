using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Esta clase da la funcion de spawnear enemigos y moverse de un lado a otro (el spawn)
    public GameObject enemy;
    public float seg, cooldown;
    Rigidbody2D rigidSpawn;
    bool cambioLado;
    public float speed;
    [SerializeField] int i;
    public int numero_enemigos;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rigidSpawn = GetComponent<Rigidbody2D>();
        cambioLado = false;
        StartCoroutine(spawnEnemys());
    }

    private void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.menu || GameManager.sharedInstance.cambioNivel)
        {
            cooldown += Time.deltaTime;
            if (cooldown < 1.5)
            {
                i = 0;
            }
            else
            {
                GameManager.sharedInstance.cambioNivel = false;
            }
        }

        if (!GameManager.sharedInstance.cambioNivel)
        {
            cooldown = 0;
        }
    }

    IEnumerator spawnEnemys()
    {
        do
        {
            // Subrutina que spawnea los enemigos 
            yield return new WaitForSeconds(seg);

            if (GameManager.sharedInstance.currentGameState == GameState.inGame && i < numero_enemigos)
            {
                Instantiate(enemy, this.transform);
                i++;
            }
        }while (true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            if (!cambioLado)
            {
                cambioLado = true;
            }
            else
            {
                cambioLado = false;
            }
        }
    }
}
