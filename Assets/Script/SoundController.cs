using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static bool sRotation; //사운드를 플레이할 지점을 알려주는 변수
    public static bool volumeDown; //볼륨다운 지점을 알려주는 변수
    public static bool stopSound; //소리가 멈춰야 하는 지점을 알려주는 변수
    public float VolSound = 1f; //볼륨에 대입시킬 변수
    private AudioSource audioSource; //audioSource 사운드 클립
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //컴포넌트 참조
    }

    void Update()
    {
        audioSource.volume = VolSound; //볼륨을 매 프레임마다 설정

        if (sRotation == true)
        {
            VolSound = 1f; //볼륨을 최대로 초기화
            audioSource.loop = true; //반복설정값을 true로 변경
            audioSource.Play(); //음악재생
            sRotation = false;
        }

        if (volumeDown == true)
        {
            VolSound *= 0.993f; //볼륨다운
        }
        else if (stopSound == true)
        {
            VolSound = 0f; //볼륨을 최저로 설정
            audioSource.Stop(); //음악재생 정지
            stopSound = false;
        }
    }
}