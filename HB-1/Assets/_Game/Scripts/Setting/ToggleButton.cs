using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] Animator Anim;
    [SerializeField] bool Toggle = true;
    public void OnToggle()
    {
        Anim.SetTrigger(Toggle ?  "ToggleOff" : "ToggleOn");
        Debug.Log("Touch Toggle" + Toggle);
        Toggle = !Toggle;
    }
    public void OnToggleIdle(bool toggle)
    {
        //Anim.SetTrigger(!toggle ? "ToggleOffIdle" : "ToggleOnIdle");
        Anim.SetTrigger(!toggle ? "ToggleOff" : "ToggleOn");
        Toggle = toggle;
    }
    public void OnToggleSFX()
    {
       
        AudioManager.GetInstance().EnableSFX(Toggle);
        DataManager.GetInstance().isOnSound = Toggle;
    }
    public void OnToggleBGM()
    {
        
        AudioManager.GetInstance().EnableAudioGame(Toggle);
        DataManager.GetInstance().isOnMusic = Toggle;

    }
    public void OnToggleVIB()
    {
        DataManager.GetInstance().isOnVibration = Toggle;
    }
}
