using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    //鼠标灵敏度
    public float sensitivity = 100.0f; 
    public float upperBound = 10f; // 上边界
    public float lowerBound = -10f; // 下边界
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //获取鼠标移动距离
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //根据鼠标灵敏度和移动距离计算旋转角度，并应用于目标物体上
        this.transform.Rotate(-mouseY, 0, 0);
        if (mouseY > 80)
        {
            this.transform.Rotate(80, 0, 0);
        }
        if (mouseY < -80)
        {
            this.transform.Rotate(-80, 0, 0);
        }
    }
}
