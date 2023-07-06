using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    public ToggleButton TGBMusic, TGBSound, TGBVibration;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        TGBMusic.OnToggleIdle(DataManager.GetInstance().isOnMusic);
        TGBSound.OnToggleIdle(DataManager.GetInstance().isOnSound);
        TGBVibration.OnToggleIdle(DataManager.GetInstance().isOnVibration);
    }
}
