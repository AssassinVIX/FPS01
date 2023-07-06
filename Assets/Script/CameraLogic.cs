using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // 相机旋转灵敏度
    public float sensitivity = 2f;
    // 最小允许的上角度
    public float minYAngle = -80f;
    // 最大允许的下角度
    public float maxYAngle = 80f; 

    private float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标移动的偏移量
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        // 计算垂直方向的旋转
        rotationX -= mouseY;
        // 限制角度在设定范围内
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle); 
        transform.localRotation = Quaternion.Euler(rotationX, 180f, 0f);
    }
}
