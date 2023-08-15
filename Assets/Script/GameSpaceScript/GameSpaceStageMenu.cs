using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameSpaceStageMenu : MonoBehaviour
{
    public GameObject StageButton;
    public GameObject BackButton;
    public GameObject StageMenu;
    public GameObject PauseMenu;

    public Button StageChoosing;
    public Button Back;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageChoosing = StageButton.GetComponent<Button>();
        StageChoosing.onClick.AddListener(OnStageChoosingClick);
        Back = BackButton.GetComponent<Button>();
        Back.onClick.AddListener(OnBackClick);
    }

    private void OnBackClick()
    {
        StageMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    private void OnStageChoosingClick()
    {
        SceneManager.LoadScene("GameSpace");
    }
}
