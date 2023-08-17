using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DrawArc : MonoBehaviour
{
    //目标
    public GameObject target;
    //对MosterAI的引用
    public MonsterAI mosterAI;
    [Range(0, 180)]
    public int viewAngle;
    //视野半径
    public float viewRadius = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeeOther();
    }
    //DrawArc.cs
    //视野角度

    //void OnDrawGizmos()
    //{
    //    Color color = Handles.color;
    //    //设置画笔颜色
    //    Handles.color = Color.red;
    //    //求起使边
    //    int angle = viewAngle / 2;
    //    Vector3 startLine = Quaternion.Euler(0, -angle, 0) * this.transform.forward;
    //    //画扇形
    //    Handles.DrawSolidArc(this.transform.position, this.transform.up, startLine, viewAngle, viewRadius);
    //    //恢复颜色
    //    Handles.color = color;
    //}

    void SeeOther()
    {
        //计算距离
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        //求怪物指向角色的向量
        Vector3 myVector3 = target.transform.position - this.transform.position;
        //计算两个向量的角度
        float angle = Vector3.Angle(myVector3, this.transform.forward);
        //距离小于半径
        if (distance <= viewRadius &&  angle <= viewAngle / 2)
        {
            //在视线范围内
            mosterAI.viewFlag = true;
        }
        else
        {
            //不在视线范围内
            mosterAI.viewFlag = false;
        }
    }
}
