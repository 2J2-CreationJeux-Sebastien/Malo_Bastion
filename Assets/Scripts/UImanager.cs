using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI goldUI;
    public TextMeshProUGUI livesUI;
    public TextMeshProUGUI wavesUI;
    public int number;
    void Update()
    {
        goldUI.text = Click.gold.ToString();
        livesUI.text = Click.lives.ToString();
        wavesUI.text = Click.currentWave.ToString();
    }
}
