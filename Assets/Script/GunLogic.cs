using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    //引用子弹节点
    public GameObject Bullet;
    //初始化子弹位置
    public Transform firePoint;
    //子弹发射间隔
    public float fireInterval;
    //弹夹内子弹数
    public float maxbullet = 30;
    //当前子弹数
    private float bulletnum = 30;
    //引用开火点节点
    public GameObject firepoint;
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
        if(bulletnum > 0)
        {
            if (Input.GetMouseButtonDown(0) )
            {
                
                if (!IsInvoking("Fire"))
                {
                    InvokeRepeating("Fire", fireInterval, fireInterval);
                }
            }
        }
        if (bulletnum <= 0)
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
        if (bulletnum <= 0)
        {
            CancelFire();
        }
    }

    public void Reload()
    {
        Debug.Log("换弹中...");
        //按下换弹键后将当前弹药数强制更改为弹匣最大弹药数实现换弹
        bulletnum = maxbullet;
        Debug.Log("当前弹药" + bulletnum);
    }

    public void Fire()
    {
        //初始化子弹实例
        GameObject bullet = Instantiate(Bullet, firePoint);
        //初始化子弹位置及角度
        bullet.transform.position = firePoint.position;
        bullet.transform.eulerAngles = firePoint.transform.eulerAngles;
        //开火后减少当前子弹数
        bulletnum = bulletnum - 1;
        Debug.Log("当前弹药" + bulletnum);
    }

    public void CancelFire()
    {
        CancelInvoke("Fire");
    }
}
