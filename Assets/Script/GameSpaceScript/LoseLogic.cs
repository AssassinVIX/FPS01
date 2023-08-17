using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseLogic : MonoBehaviour
{
    public GameObject QuitButton;
    public GameObject StageButton;
    public GameObject RetryButton;
    public GameObject StageChooseMenu;

    public Button Quit;
    public Button Stage;
    public Button Retry;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quit = QuitButton.GetComponent<Button>();
        Quit.onClick.AddListener(OnQuitClick);
        Stage = StageButton.GetComponent<Button>();
        Stage.onClick.AddListener(OnStageClick);
        Retry = RetryButton.GetComponent<Button>();
        Retry.onClick.AddListener(OnRetryClick);
    }

    private void OnQuitClick()
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void OnStageClick()
    {
        StageChooseMenu.SetActive(true);
    }

    private void OnRetryClick()
    {
        SceneManager.LoadScene("GameSpace");
    }
}
