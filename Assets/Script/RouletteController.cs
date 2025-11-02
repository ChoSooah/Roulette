using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float speed = 0f;
    public bool isStop = false;
    //멈춤을 진행할건지 체크하는 변수

    public AudioClip RingSound; //RingSound 사운드 클립
    private AudioSource audioSource; //객체생성
    void StopRoullet(bool isStop)
    {
        if (speed < 0.1f)
        {
            speed = 0f; //속도를 0으로 설정
            SoundController.volumeDown = false;
            SoundController.stopSound = true;
            audioSource.PlayOneShot(RingSound); //효과음 링사운드를 한번 재생
            this.isStop = false; //멈춤정지
            Debug.Log("False");
        }

        if (isStop == true)
        {
            speed *= 0.98f; //속도 줄어들기
        }
    }

    void Start()
    {
        //프레임레이트를 60으로 고정한다
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //왼쪽마우스버튼이 눌리면
        {
            if (speed > 0) //스피드가 0보다 크면
            {
                isStop = true; //멈춤진행
                SoundController.volumeDown = true;
                Debug.Log("True");
                //사운드 크기 천천히 줄이기
            }
            else
            {
                SoundController.sRotation = true;
                this.speed = 10.0f; //속도를 10으로 설정
                Debug.Log("속도 10 설정");
            }
        }

        if (isStop == true)
        {
            StopRoullet(isStop);
        }

        //회전 속도만큼 룰렛을 회전시킨다.
        transform.Rotate(0, 0, this.speed);


        if (Input.GetKeyDown("q")) //q버튼을 누르면
        {
            speed = 0f;
            isStop = false;
            audioSource.PlayOneShot(RingSound);
            transform.rotation = Quaternion.identity; //월드 기준으로 회전도를 리셋
            Debug.Log("리셋");
        }
    }


}