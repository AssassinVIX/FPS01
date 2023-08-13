using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // 相机旋转灵敏度
    public float Sensitivity = 2f;
    // 最小允许的上角度
    public float MinYAngle = -80f;
    // 最大允许的下角度
    public float MaxYAngle = 80f; 

    private float RotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标移动的偏移量
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;
        // 计算垂直方向的旋转
        RotationX -= mouseY;
        // 限制角度在设定范围内
        RotationX = Mathf.Clamp(RotationX, MinYAngle, MaxYAngle); 
        transform.localRotation = Quaternion.Euler(RotationX, 180f, 0f);
    }
}
