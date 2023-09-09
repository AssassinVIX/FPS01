using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float enemylife = 3;
    //寻路坐标点数组
    public Transform[] points;
    //坐标索引
    public int pointIndex;
    public float moveSpeed;
    public GameObject target;
    public bool viewFlag;
    public float attackDis;
    public float FireInterval = 5;
    public Transform FirePoint;
    public GameObject Bullet;
    public int IndexNum;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MosterGO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("RealBullet"))
        {
            enemylife = enemylife - 1;
            Destroy(other.gameObject);
            if (enemylife <= 0)
            {
                Destroy(this.gameObject);
                GameObject.Find("Player").SendMessage("Value");
            }
        }
    }



    void MoveSelf()
    {
        //看向选定坐标点
        Vector3 nextPosition = points[pointIndex].position;
        this.transform.LookAt(nextPosition);
        //前进,自身坐标系，使用Vector3.forward即可
        this.transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.Self);
        //判断距离
        if (Vector3.Distance(this.transform.position, nextPosition) < 0.1)
        {
            //更换下一个坐标点
            pointIndex = Random.Range(0, IndexNum);//随机范围{0,1,2,3}
        }
    }
    void FollowTarget()
    {
        //获取调用时目标坐标
        Vector3 targetPostion = target.transform.position;
        this.transform.LookAt(targetPostion);
        this.transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime, Space.Self);
    }


    IEnumerator MosterGO()
    {
        while (true)
        {
            //等待固定帧更新完成
            yield return new WaitForFixedUpdate();
            if (viewFlag)
            {
                //求二者距离
                float distance = Vector3.Distance(target.transform.position, this.transform.position);
                if (distance <= attackDis) {
                    if (!IsInvoking("Fire"))
                    {
                        InvokeRepeating("Fire", FireInterval, FireInterval);
                    }
                    continue;
                }
                FollowTarget();
                continue;
            }
            //没有看到目标，自由移动
            MoveSelf();
            if (IsInvoking("Fire"))
            {
                CancelInvoke("Fire");
            }
        }
    }
    public void Fire()
    {
        //初始化子弹实例
        GameObject bullet = Instantiate(Bullet, FirePoint);
        //初始化子弹位置及角度
        bullet.transform.position = FirePoint.position;
        bullet.transform.eulerAngles = FirePoint.transform.eulerAngles;
    }
}
