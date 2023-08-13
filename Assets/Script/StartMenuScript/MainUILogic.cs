using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUILogic : MonoBehaviour
{
    //引用按钮及各个菜单的实例
    public GameObject StartButton;
    public GameObject QuitButton;
    public GameObject SettingButton;
    public GameObject SettingMenu;
    public GameObject StageChooseMenu;
    
    //引用主界面的三个按钮
    public Button Starting;
    public Button Setting;
    public Button Quitting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Starting = StartButton.GetComponent<Button>();
        Starting.onClick.AddListener(OnStartButtonClick);
        Setting = SettingButton.GetComponent<Button>();
        Setting.onClick.AddListener(OnSettingButtonClick);
        Quitting = QuitButton.GetComponent<Button>();
        Quitting.onClick.AddListener(OnQuittingClick);
    }

    private void OnQuittingClick()
    {
        UnityEngine.Application.Quit();
    }

    private void OnSettingButtonClick()
    {
        SettingMenu.SetActive(true);
    }

    private void OnStartButtonClick()
    {
        StageChooseMenu.SetActive(true);
    }
}
