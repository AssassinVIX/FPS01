using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuLogic : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject SettingMenu;

    public Button Back;
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

    private void OnBackClick()
    {
        SettingMenu.SetActive(false);
    }
}
