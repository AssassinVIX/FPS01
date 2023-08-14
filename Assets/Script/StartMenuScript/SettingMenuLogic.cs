using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenuLogic : MonoBehaviour
{
    //引用两个按钮的实例
    public GameObject BackButton;
    public GameObject SettingMenu;

    //引用按钮
    public Button Back;

    //引用滑动条节点
    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Back = BackButton.GetComponent<Button>();
        Back.onClick.AddListener(OnBackClick);
        
    }
    //SldOnClick：传递参数以触发AudioManager的SldOnClick
    public void MasterSldOnClick(GameObject image)
    {
        AudioManager.Instance.MasterSldOnClick(image, MasterSlider);
    }
    public void BgmSldOnClick(GameObject image)
    {
        AudioManager.Instance.BgmSldOnClick(image, BgmSlider);
    }
    public void SeSldOnClick(GameObject image)
    {
        AudioManager.Instance.SeSldOnClick(image, SeSlider);
    }

    private void OnBackClick()
    {
        SettingMenu.SetActive(false);
    }
}
