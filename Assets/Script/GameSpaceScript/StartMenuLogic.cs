using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuLogic : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject StartMenu;
    public GameObject GameUI;
    public GameObject Gun;

    public Button StartBtn;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartBtn = StartButton.GetComponent<Button>();
        StartBtn.onClick.AddListener(OnStartBtnClick);
    }

    public void OnStartBtnClick()
    {
        Gun.SetActive(true);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        GameUI.SetActive(true);
        Cursor.visible = false;
    }
}
