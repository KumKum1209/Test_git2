using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : GOSingleton<UIManager>
{
    public static UIManager instance;


    private void Awake()
    {
        GetInstance();
    }
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI liveText;

    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
    public void SetLive(int live)
    {
        liveText.text = "X " + live.ToString();

    }
}
