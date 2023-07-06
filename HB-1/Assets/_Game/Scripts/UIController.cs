using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : GOSingleton<UIController>
{
    public GameObject settingPanel;
    public void OnOpen()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void OnClose()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
