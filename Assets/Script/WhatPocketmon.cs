using UnityEngine;

public class WhatPocketmon : MonoBehaviour
{
    public static bool isCheckPocketmon = false;
    public static bool isNoRotationRoulette = false;
    public static int PocketmonEncyNum = 0;
    public ButtonController ButtonController;

    private AudioSource audioSource;

    public AudioClip PocketmonVoice1;
    public AudioClip PocketmonVoice2;
    public AudioClip PocketmonVoice3;
    public AudioClip PocketmonVoice4;
    public AudioClip PocketmonVoice5;
    public AudioClip PocketmonVoice6;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(PocketmonVoice1);
            PocketmonEncyNum = 1;
            ButtonController.PocketmonEncy1.SetActive(true);
        }
        else if (angle >= 30 && angle < 90)
        {
            Debug.Log("2");
            audioSource.PlayOneShot(PocketmonVoice2);
            PocketmonEncyNum = 2;
            ButtonController.PocketmonEncy2.SetActive(true);
        }
        else if (angle >= 90 && angle < 150)
        {
            Debug.Log("3");
            audioSource.PlayOneShot(PocketmonVoice3);
            PocketmonEncyNum = 3;
            ButtonController.PocketmonEncy3.SetActive(true);
        }
        else if (angle >= 150 && angle < 210)
        {
            Debug.Log("4");
            audioSource.PlayOneShot(PocketmonVoice4);
            PocketmonEncyNum = 4;
            ButtonController.PocketmonEncy4.SetActive(true);
        }
        else if (angle >= 210 && angle < 270)
        {
            Debug.Log("5");
            audioSource.PlayOneShot(PocketmonVoice5);
            PocketmonEncyNum = 5;
            ButtonController.PocketmonEncy5.SetActive(true);
        }
        else if (angle >= 270 && angle < 330)
        {
            Debug.Log("6");
            audioSource.PlayOneShot(PocketmonVoice6);
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
