using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouletteController : MonoBehaviour
{
    public float speed = 0f;
    // public: 외부에서도 접근 가능
    // float: 실수형 함수
    // speed: 룰렛의 회전 속도를 나타내는 변수
    // 0f: 초기값을 0.0(float형)으로 설정
    // 초기값 = 0, 즉 멈춘 상태

    public bool isStoped = false;
    // 멈춤을 진행할 건지 체크하는 변수
    // public: 외부에서도 접근 가능
    // bool: 논리형 자료형 (참, 거짓 입력 가능)
    // isStoped: 룰렛의 멈춤(감속) 과정이 진행 중인지 체크하는 변수
    // false: 거짓, 즉 시작 대기 혹은 회전 상태

    public AudioClip StopRingSound;
    // public: 외부에서도 접근 가능
    // AudioClip: Unity에서 사운드 파일을 저장하는 자료형
    // StopRingSound: 룰렛이 멈춤 상태일 때 재생할 효과음(사운드 클립)을 저장할 변수
    // 룰렛이 false(멈춤) 상태일 때 재생할 사운드 클립
    public AudioClip ResetRingSound;
    public AudioClip OSound;

    private AudioSource audioSource;
    // private: 클래스 내부에서만 접근 가능
    // AudioSource: 사운드를 재생하는 Unity 컴포넌트의 인스턴스를 저장할 변수

    void Start()
    {
        Application.targetFrameRate = 60; // FrameRate를 60으로 고정
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 참조
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WhatPocketmon.isNoRotationRoulette == false) // 왼쪽 마우스 버튼 클릭 시
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // UI 위에서 클릭된 경우
                return;
            }
            if (speed > 0) // speed가 0보다 클 시
            {
                isStoped = true; // 룰렛 멈춤 진행
                SoundController.isVolumeDown = true; // 사운드 크기를 천천히 줄임
                Debug.Log("True"); // 콘솔에 "True" 출력 (디버그 로그)
            }
            else
            {
                SoundController.isSoundRotaion = true; // 사운드 회전(재생)을 시작
                this.speed = 10.0f; // 속도를 10으로 설정, 룰렛 회전 시작
                audioSource.PlayOneShot(OSound);
                Debug.Log("속도 10 설정"); // 콘솔에 "속도 10 설정" 출력 (디버그 로그)
            }
        }

        if (isStoped == true) // 룰렛을 멈추는 중일 시
        {
            StopRoullet(isStoped); // StopRoullet 함수를 호출, 감속
        }

        transform.Rotate(0, 0, this.speed);
        // transform.Rotate(x, y, z): 게임 오브젝트의 x, y, z축을 변경
        // z축을 기준으로 현재 speed 값만큼 룰렛 회전



        if (ButtonController.Reset == true)
        {
            GetComponentInParent<ParticleSystem>().Play();
            speed = 0f; // 속도를 0으로 설정, 즉시 정지
            isStoped = false; // 멈춤 상태를 해제
            audioSource.PlayOneShot(ResetRingSound); // 정지 효과음을 재생
            transform.rotation = Quaternion.identity; // 월드 기준으로 회전값 리셋
            Debug.Log("리셋"); // 콘솔에 "리셋" 출력 (디버그 로그)
            ButtonController.Reset = false;
        }
    }

    // void: 반환형, 값을 반환하지 않음
    // StopRoullet: 룰렛을 멈추는(감속) 함수 이름
    // (bool isStoped): 이 함수가 호출될 때 전달받는 논리형(bool) 매개변수
    // 매개변수 이름이 변수와 동일, 이후 함수에서 오류가 나지 않게 하기 위해 this 포인터를 이용해 매개변수가 아닌 위쪽의 isStoped을 가리키게 만듦
    void StopRoullet(bool isStoped)
    {
        if (speed < 0.1f)
        // 현재 회전 속도가 0.1보다 작을 시
        {
            // 롤렛이 회전할 때 확 퍼지는 이펙트(파티클) 표시를 위해서 ParticleSystem 컴퍼넌트의 Play 메서드를 호출
            GetComponentInParent<ParticleSystem>().Play();
            speed = 0f; //속도를 0으로 설정
            SoundController.isVolumeDown = false; // 사운드 컨트롤러에 '사운드 멈춤' 신호 전달
            SoundController.isStopSound = true; // 사운드 재생 멈춤
            audioSource.PlayOneShot(StopRingSound); // 효과음 StopRingSound를 재생
            WhatPocketmon.isCheckPocketmon = true;
            this.isStoped = false; // 멈춤 정지
            Debug.Log("False"); // 콘솔에 "False" 출력 (디버그 로그)
        }

        if (isStoped == true) // 만약 룰렛이 움직이고 있을 시
        {
            speed *= 0.98f; // 현재 속도에 0.98을 곱해 속도 감속

        }
    }

}
