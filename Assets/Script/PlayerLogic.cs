using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    //角色跳跃时被施加的力，必须拥有刚体组件
    public readonly float jumpForce = 5f;
    //角色移动速度
    public float movespeed;
    //鼠标灵敏度
    public float sensitivity = 100.0f;
    //允许两次按下空格键之间的最短时间间隔
    public float spaceInterval = 2f; 
    private float lastSpaceTime = 0f;
    //玩家得分
    public float score = 0;
    //玩家生命
    public float playerlife = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float dx = 0;
        float dz = 0;
        //通过获取W,A,S,D四个按键事件改变x、y两个方向的速度
        if (Input.GetKey(KeyCode.A))
        {
            dx = movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dx = -movespeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dz = -movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dz = movespeed;
        }

        //获取空格事件，并引用物体刚体组件
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSpaceTime < spaceInterval)
            {
                //判断两次按下空格键时间间隔是否足够长
                return;
            }

            //执行按下空格键操作
            lastSpaceTime = Time.time;
            //引用刚体组件，对物体施加向上的力
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //物体移动
        this.transform.Translate(dx * Time.deltaTime, 0, dz * Time.deltaTime);

        //获取鼠标移动距离
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //根据鼠标灵敏度和移动距离计算旋转角度，并应用于目标物体上
        this.transform.Rotate(0, mouseX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("enemyBullet"))
        {
            Destroy(other.gameObject);
            SendMessage("unvalue");
        }
    }
    public void unvalue()
    {
        if (score > 0)
        {
            score = score - 1;
        }
        playerlife = playerlife - 1;
        if (playerlife <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    public void value()
    {
        score = score + 1;
    }
}
