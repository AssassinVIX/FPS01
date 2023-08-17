using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseMenuLogic : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject BackButton;
    public GameObject StageButton;
    public GameObject StageMenu;
    public GameObject PauseButton;

    public Button Menu;
    public Button BackTo;
    public Button Stage;

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
        Menu = MenuButton.GetComponent<Button>();
        Menu.onClick.AddListener(OnMenuButtonClick);
        BackTo = BackButton.GetComponent<Button>();
        BackTo.onClick.AddListener(OnBackClick);
        Stage = StageButton.GetComponent<Button>();
        Stage.onClick.AddListener(OnStageClick);
    }

    public void OnStageClick()
    {
        StageMenu.SetActive(true);
    }

    public void OnBackClick()
    {
        this.gameObject.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void OnMenuButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
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
}
