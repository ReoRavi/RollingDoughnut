using UnityEngine;
using System.Collections;

//=======================================
// SoundKeep : 배경음악이 이어지도록 한다.
public class SoundKeep : MonoBehaviour
{
    // 배경음악
    public GameObject Sound;
    public AudioSource MainSound;
    // 배경음악이 재생중인가
    public bool bIsSoundActive;
    // 배경음악 설정 체크
    int SoundCheck;

    // 초기화
    void Awake()
    {
        // 설정 가져오기
        SoundCheck = PlayerPrefs.GetInt("BackGroundSound");

        Instance = this;

        // 설정에 따른 처리
        if (SoundCheck == 1)
        {
            MainSound.Stop();
        }
        if (SoundCheck == 0)
        {
            MainSound.Play();
        }

        // 배경음악 오브젝트를 삭제하지 않고 다음 씬으로 넘긴다.
        DontDestroyOnLoad(this);

        bIsSoundActive = true;
    }

    // 재생을 멈춘다.
    public void SoundStop()
    {
        MainSound.Stop();
    }

    // 재생을 시작한다.
    public void StartPlay()
    {
        MainSound.Play();
    }

    //======================================================================================
    // 싱글톤
    private static SoundKeep Instance;

    public static SoundKeep instance
    {
        get
        {
            //if (Instance == null)
            //{
            //    Instance = new GameObject("TycoonManager").AddComponent<TycoonManager>();
            //}

            return Instance;
        }
    }
    //======================================================================================
}
