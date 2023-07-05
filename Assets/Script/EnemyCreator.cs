using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform enemyHome;

    public float createInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("create", createInterval,createInterval);
    }

    public void create()
    {
        GameObject enemy = Instantiate(enemyPrefab,enemyHome);
        enemy.transform.position = enemyHome.position;
        enemy.transform.eulerAngles = new Vector3(0, 180, 0);
        float dx = Random.Range(50, -50);
        enemy.transform.Translate(dx, 0, 0, Space.Self);
    }
}
