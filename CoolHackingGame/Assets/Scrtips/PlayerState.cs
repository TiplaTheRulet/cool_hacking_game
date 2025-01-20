using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using JetBrains.Annotations;

public class PlayerState : MonoBehaviour 
{
    public int playerMoney = 0;

    public GameObject guts;
    public GameObject phoenix;
    public GameObject foxgirl;

    public EventManager em;

    public bool gutsUnlocked = false;
    public bool phoenixUnlocked = false;
    public bool foxgirlUnlocked = false;

    public TMP_Text moneyCounter;

    public void Update()
    {
        if (gutsUnlocked) guts.SetActive(true);
        if (phoenixUnlocked) phoenix.SetActive(true);
        if (foxgirlUnlocked) foxgirl.SetActive(true);
        if (!gutsUnlocked) guts.SetActive(false);
        if (!phoenixUnlocked) phoenix.SetActive(false);
        if (!foxgirlUnlocked) foxgirl.SetActive(false);

        moneyCounter.SetText("Current Balance: " + playerMoney.ToString());
    }

    public void figureUnlocking()
    {
        if (em.selectedFigure == EventManager.Figure.foxgirl && !foxgirlUnlocked)
        {
            if (playerMoney >= 100)
            {
                foxgirlUnlocked = true;
                playerMoney -= 100;
            }
        }
        if (em.selectedFigure == EventManager.Figure.guts && !gutsUnlocked)
        {
            if (playerMoney >= 100)
            {
                gutsUnlocked = true;
                playerMoney -= 100;
            }
        }
        if (em.selectedFigure == EventManager.Figure.phoenix && !phoenixUnlocked)
        {
            if (playerMoney >= 100)
            {
                phoenixUnlocked = true;
                playerMoney -= 100;
            }
        }
    }
    public void moneyEarn(int money) { playerMoney += money; }
}
