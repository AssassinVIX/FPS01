using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    //角色跳跃时被施加的力，必须拥有刚体组件
    public readonly float JumpForce = 5f;
    //角色移动速度
    public float MoveSpeed = 5;
    //鼠标灵敏度
    public float Sensitivity = 100.0f;
    //允许两次按下空格键之间的最短时间间隔
    public float SpaceInterval = 2f; 
    private float LastSpaceTime = 0f;
    //玩家得分
    public float Score = 0;
    //玩家生命
    public float Playerlife = 5;
    public Text HealthText;
    public Text ScoreText;
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
            dx = MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dx = -MoveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dz = -MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dz = MoveSpeed;
        }

        //获取空格事件，并引用物体刚体组件
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - LastSpaceTime < SpaceInterval)
            {
                //判断两次按下空格键时间间隔是否足够长
                return;
            }

            //执行按下空格键操作
            LastSpaceTime = Time.time;
            //引用刚体组件，对物体施加向上的力
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        //物体移动
        this.transform.Translate(dx * Time.deltaTime, 0, dz * Time.deltaTime);

        //获取鼠标移动距离
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;

        //根据鼠标灵敏度和移动距离计算旋转角度，并应用于目标物体上
        this.transform.Rotate(0, mouseX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("enemyBullet"))
        {
            Destroy(other.gameObject);
            SendMessage("Unvalue");
        }
    }
    public void Unvalue()
    {
        if (Score > 0)
        {
            Score = Score - 1;
        }
        Playerlife = Playerlife - 1; 
        HealthText.text = "当前血量：" + Playerlife;
        if (Playerlife <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Value()
    {
        Score = Score + 1;
        ScoreText.text = "玩家得分：" + Score;
    }

    private bool IsSlope(Rigidbody rb)
    {
        float slopeHeightMaxDistance = 2f;
        float heightOffset = 2f;

        RaycastHit hit;
        if (Physics.Raycast(rb.position + Vector3.up * heightOffset, Vector3.down, out hit, slopeHeightMaxDistance))
        {
            return hit.normal != Vector3.up;
        }

        return false;
    }
}
