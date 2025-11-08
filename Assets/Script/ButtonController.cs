using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject PocketmonEncy1;
    public GameObject PocketmonEncy2;
    public GameObject PocketmonEncy3;
    public GameObject PocketmonEncy4;
    public GameObject PocketmonEncy5;
    public GameObject PocketmonEncy6;
    public GameObject BackButton;
    public GameObject ReturnButton;
    public static bool Reset = false;

    public Button button;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ResetEncy()
    {
        int EncyNum = WhatPocketmon.PocketmonEncyNum;
        switch (EncyNum)
        {
            case 1: PocketmonEncy1.SetActive(false); break;
            case 2: PocketmonEncy2.SetActive(false); break;
            case 3: PocketmonEncy3.SetActive(false); break;
            case 4: PocketmonEncy4.SetActive(false); break;
            case 5: PocketmonEncy5.SetActive(false); break;
            case 6: PocketmonEncy6.SetActive(false); break;
        }

        WhatPocketmon.PocketmonEncyNum = 0;
        ReturnButton.SetActive(true);
        BackButton.SetActive(false);
        Reset = true;
        WhatPocketmon.noRotationRoulette = false;
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
