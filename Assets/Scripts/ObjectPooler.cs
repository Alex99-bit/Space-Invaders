using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public List<GameObject> balas;
    public List<GameObject> balasEnemy;
    public GameObject balasPool;
    public GameObject balasPoolEnemy;
    public int numBalas;
    public int numBalasEnemy;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Codigo para hacer un pool de balas (una piscina, esto ahorra recursos)
        balas = new List<GameObject>();
        balasEnemy = new List<GameObject>();
        for (int i=0; i < numBalas; i++)
        {
            GameObject obj = (GameObject)Instantiate(balasPool);
            obj.SetActive(false);
            balas.Add(obj);
        }

        for(int i=0; i < numBalasEnemy; i++)
        {
            GameObject obj2 = (GameObject)Instantiate(balasPoolEnemy);
            obj2.SetActive(false);
            balasEnemy.Add(obj2);
        }
    }

    public GameObject GetPooledObjectPlayer()
    {
        for(int i = 0; i < balas.Count; i++)
        {
            if (!balas[i].activeInHierarchy)
            {
                return balas[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObjectEnemy()
    {
        for (int i = 0; i < balasEnemy.Count; i++)
        {
            if (!balasEnemy[i].activeInHierarchy)
            {
                return balasEnemy[i];
            }
        }
        return null;
    }
}
