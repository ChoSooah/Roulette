using UnityEngine;

public class WhatPocketmon : MonoBehaviour
{
    public static bool isCheckPocketmon = false;
    public static bool isNoRotationRoulette = false;
    public static int PocketmonEncyNum = 0;
    public ButtonController ButtonController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckPocketmon == true)
        {
            isNoRotationRoulette = true;
            PrintPocketMon();
        }


    }

    void PrintPocketMon()
    {
        float offset = 0f;
        float angle = (transform.eulerAngles.z + offset) % 360f;
        Debug.Log(angle);

        if (angle >= 330 && angle < 360 || angle >= 0 && angle < 30)
        {
            Debug.Log("1");
            PocketmonEncyNum = 1;
            ButtonController.PocketmonEncy1.SetActive(true);
        }
        else if (angle >= 30 && angle < 90)
        {
            Debug.Log("2");
            PocketmonEncyNum = 2;
            ButtonController.PocketmonEncy2.SetActive(true);
        }
        else if (angle >= 90 && angle < 150)
        {
            Debug.Log("3");
            PocketmonEncyNum = 3;
            ButtonController.PocketmonEncy3.SetActive(true);
        }
        else if (angle >= 150 && angle < 210)
        {
            Debug.Log("4");
            PocketmonEncyNum = 4;
            ButtonController.PocketmonEncy4.SetActive(true);
        }
        else if (angle >= 210 && angle < 270)
        {
            Debug.Log("5");
            PocketmonEncyNum = 5;
            ButtonController.PocketmonEncy5.SetActive(true);
        }
        else if (angle >= 270 && angle < 330)
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
        isCheckPocketmon = false;
    }
}
