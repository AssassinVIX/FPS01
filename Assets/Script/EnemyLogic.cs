using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float enemylife = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Bullet"))
        {
            enemylife = enemylife - 1;
            Destroy(other.gameObject);
            if (enemylife <= 0)
            {
                Destroy(this.gameObject);
                GameObject.Find("Player").SendMessage("value");
            }
        }
        
    }
}
