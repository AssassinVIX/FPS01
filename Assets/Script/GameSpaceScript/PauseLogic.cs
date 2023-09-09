using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLogic : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;

    public Button Pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause = PauseButton.GetComponent<Button>();
        Pause.onClick.AddListener(OnPauseClick);
    }

    public void OnPauseClick()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(false);
        PauseMenu.SetActive(true);
        Cursor.visible = true;
    }
}
