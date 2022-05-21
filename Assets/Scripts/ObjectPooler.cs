using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public List<GameObject> balas; 
    public GameObject balasPool;
    public int numBalas;

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
        for (int i=0; i < numBalas; i++)
        {
            GameObject obj = (GameObject)Instantiate(balasPool);
            obj.SetActive(false);
            balas.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
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
}
