using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;

    public GameObject currentScreen;

    public GameObject endScreen;
    public GameObject gameScreen;
    public GameObject mainScreen;
    public GameObject returnScreen;

    public Button lengthButton;
    public Button strengthButton;
    public Button offlineButton;

    public Text gameScreenMoney;
    public Text lengthCostText;
    public Text lengthValueText;
    public Text strengthCostText;
    public Text strengthValueText;
    public Text offlineCostText;
    public Text offlineValueText;
    public Text endScreenMoney;
    public Text returnScreenMoney;


    private int gameCount;

    private void Awake()
    {
        if(ScreensManager.instance)
        {
            Destroy(base.gameObject);
        }

        else
        {
            ScreensManager.instance = this;
        }

        currentScreen = mainScreen;
    }

    private void Start()
    {
        CheckIdles();
        UpdateTexts();
    }

    public void ChangeScreens(Screens screen)
    {
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentScreen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                currentScreen = gameScreen;
                gameCount++
                break;

            case Screens.END:
                currentScreen = endScreen;
                //SetEndScreenMoney();
                break;

            case Screens.RETURN:
                currentScreen = returnScreen;
                //SetReturnScreenMoney();
                break;

        }
    }

    public void UpdateTexts()
    {

    }

    public void CheckIdles()
    {

    }
}
