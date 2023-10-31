using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GunLogic : MonoBehaviour
{
    //引用子弹节点
    public GameObject Bullet;
    public GameObject RealBullet;
    //初始化子弹位置
    public Transform FirePoint;
    public Transform RealFirepoint;
    //子弹发射间隔
    public float FireInterval;
    //弹夹内子弹数
    public float MaxBullet = 30;
    //当前子弹数
    private float BulletNum = 30;
    //发射出的总子弹数
    private float Count = 0;
    //初始总备弹量
    public float Amno = 360;
    //当前弹匣内发射出去的子弹
    private float OutAmno = 0;
    public float RemainingAmno = 360;
    public Text BulletText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if(BulletNum > 0)
        {
            if (Input.GetMouseButtonDown(0) )
            {
                if (!IsInvoking("Fire"))
                {
                    InvokeRepeating("Fire", FireInterval, FireInterval);
                }
            }
        }
        if (BulletNum <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("弹药已空！！！");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelFire();
        }
        //当前弹药量小于等于0时强制阻止开火
        if (BulletNum <= 0)
        {
            CancelFire();
        }
    }

    public void Reload()
    {
        if (Count <= RemainingAmno)
        {
            Debug.Log("换弹中...");
            //按下换弹键后将当前弹药数强制更改为弹匣最大弹药数实现换弹
            BulletNum = MaxBullet;
            RemainingAmno = RemainingAmno - OutAmno;
            OutAmno = 0;
            Thread.Sleep(1000);
            BulletText.text = "当前弹药：" + BulletNum + "/" + RemainingAmno;
            Debug.Log("当前弹药" + BulletNum);
        }
        else
        {
            Debug.Log("没子弹了！！！");
        }
    }

    public void Fire()
    {
        //初始化子弹实例
        GameObject bullet = Instantiate(Bullet, FirePoint);
        GameObject realbullet = Instantiate(RealBullet, RealFirepoint);
        //初始化子弹位置及角度
        bullet.transform.position = FirePoint.position;
        bullet.transform.eulerAngles = FirePoint.transform.eulerAngles;
        realbullet.transform.position = RealFirepoint.position;
        realbullet.transform.eulerAngles = RealFirepoint.transform.eulerAngles;
        //开火后减少当前子弹数
        BulletNum = BulletNum - 1;
        Count += 1;
        OutAmno += 1;
        BulletText.text = "当前弹药：" + BulletNum + "/" + RemainingAmno;
        Debug.Log("当前弹药：" + BulletNum + "/" + RemainingAmno);
    }

    public void CancelFire()
    {
        CancelInvoke("Fire");
    }
}
