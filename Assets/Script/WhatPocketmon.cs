using UnityEngine;

public class WhatPocketmon : MonoBehaviour
{
    public static bool checkPocketmon = false;
    public static bool noRotationRoulette = false;
    public static int PocketmonEncyNum = 0;
    public ButtonController ButtonController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkPocketmon == true)
        {
            noRotationRoulette = true;
            PrintPocketMon();
        }


    }

    void PrintPocketMon()
    {
        float offset = 0f;
        float angle = (transform.eulerAngles.z + offset) % 360f;
        Debug.Log(angle);

        if (angle >= 0 && angle < 60)
        {
            Debug.Log("1");
            PocketmonEncyNum = 1;
            ButtonController.PocketmonEncy1.SetActive(true);
        }
        else if (angle >= 60 && angle < 120)
        {
            Debug.Log("2");
            PocketmonEncyNum = 2;
            ButtonController.PocketmonEncy2.SetActive(true);
        }
        else if (angle >= 120 && angle < 180)
        {
            Debug.Log("3");
            PocketmonEncyNum = 3;
            ButtonController.PocketmonEncy3.SetActive(true);
        }
        else if (angle >= 180 && angle < 240)
        {
            Debug.Log("4");
            PocketmonEncyNum = 4;
            ButtonController.PocketmonEncy4.SetActive(true);
        }
        else if (angle >= 240 && angle < 300)
        {
            Debug.Log("5");
            PocketmonEncyNum = 5;
            ButtonController.PocketmonEncy5.SetActive(true);
        }
        else if (angle >= 300 && angle < 360)
        {
            Debug.Log("6");
            PocketmonEncyNum = 6;
            ButtonController.PocketmonEncy6.SetActive(true);
        }
        else
        {
            Debug.Log("오류");
        }
        ButtonController.ReturnButton.SetActive(false);
        ButtonController.BackButton.SetActive(true);
        checkPocketmon = false;
    }
}
