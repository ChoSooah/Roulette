using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static bool sRotation;
    // 사운드 재생 지점을 알려주는 변수
    // public static: 외부에서 '클래스 이름.변수이름'으로 접근, 수정 가능
    // sRotation: 룰렛 회전 시작에 맞춰 사운드를 재생할 시. 'true'로 설정

    public static bool volumeDown;
    // 볼륨 감소 지점을 알려주는 변수
    // public static: 외부에서 '클래스 이름.변수이름'으로 접근, 수정 가능
    // volumeDown: 룰렛 멈춤 시작에 맞춰 볼륨 감소 시, 'true'로 설정

    public static bool stopSound;
    // 사운드 종료 지점을 알려주는 변수
    // public static: 외부에서 '클래스 이름.변수이름'으로 접근, 수정 가능
    // stopSound: 룰렛이 완전히 멈췄을 때 사운드 종료 시, 'true'로 설정

    public float VolSound = 1f;
    // 현재 볼륨 값을 저장하고 제어하는 실수형 변수
    // public: 외부에서 접근 가능
    // 1f: 초기값을 1.0으로 설정, 최대 볼륨

    private AudioSource audioSource;
    // AudioSource 컴포넌트 인스턴스를 저장할 변수
    // private: 클래스 내부에서만 접근 가능
    // AudioSource: 사운드를 재생하는 Unity 컴포넌트

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 참조
    }

    void Update()
    {
        audioSource.volume = VolSound; //볼륨을 매 프레임마다 설정

        if (sRotation == true)
        // 사운드 재생 시작 시 (룰렛이 회전할 시)
        {
            VolSound = 1f; //볼륨을 1f(최대 볼륨)으로 초기화
            audioSource.loop = true; //사운드를 반복 재생
            audioSource.Play(); //AudioSource에 있는 음악 재생
            sRotation = false; // 플래그를 false로 리셋
        }

        if (volumeDown == true)
        // 볼륨 감소 시 (룰렛이 멈추기 시작할 시)
        {
            VolSound *= 0.993f; //현재 볼륨에서 0.993을 곱해 볼륨 감소
        }
        else if (stopSound == true)
        // 사운드 종료 시 (룰렛이 완전히 멈출 시)
        {
            VolSound = 0f; //볼륨을 0f(최저 볼륨)으로 설정
            audioSource.Stop(); //음악 재생 정지
            stopSound = false; // 플래그를 false로 리셋
        }
    }
}
