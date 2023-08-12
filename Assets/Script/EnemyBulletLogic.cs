using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public float Speed = 100f;

    public float Lifetime = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Selfdestory", Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, Speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Selfdestory()
    {
        Destroy(this.gameObject, Lifetime);
    }
}
