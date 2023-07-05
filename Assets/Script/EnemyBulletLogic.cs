using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public float speed = 100f;

    public float lifetime = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfdestory", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void selfdestory()
    {
        Destroy(this.gameObject, lifetime);
    }
}
