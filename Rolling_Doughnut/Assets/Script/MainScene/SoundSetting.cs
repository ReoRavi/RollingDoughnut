using UnityEngine;
using System.Collections;

//=======================================
// SoundSetting : 메인메뉴의 소리 설정 부분 처리
public class SoundSetting : MonoBehaviour {

    // 버튼 이미지들
    public Sprite[] ButtonImage;
    // 버튼의 이미지 정보
    public SpriteRenderer Button;
    // 세팅 이름
    public string SettingName;
    // 버튼의 상태
    public int ButtonState;
    // 사운드
    public GameObject Sound;
    // 배경 음악
    public AudioSource MainSound;

	// Use this for initialization
	void Start () {
        // 배경음악 오브젝트를 가져온다.
        Sound = GameObject.Find("Sound(Clone)");
        MainSound = Sound.GetComponent<AudioSource>();

        // 저장된 세팅을 가져온다.
        ButtonState = PlayerPrefs.GetInt(SettingName);
        Button.sprite = ButtonImage[ButtonState];

        if (ButtonState == 1)
        {
            MainSound.Stop();
        }
	}

    // 눌렸을 때
    void OnMouseDown()
    {
        // 버튼의 상태에 따라 처리
        if (ButtonState == 0)
        {
            // 음악을 멈춘다.
            PlayerPrefs.SetInt(SettingName, 1);

            Button.sprite = ButtonImage[PlayerPrefs.GetInt(SettingName)];
            ButtonState = 1;

            if (SettingName == "BackGroundSound")
            {
                MainSound.Stop();
            }
        }
        else
        {
            // 음악을 재생한다.
            PlayerPrefs.SetInt(SettingName, 0);

            Button.sprite = ButtonImage[PlayerPrefs.GetInt(SettingName)];
            ButtonState = 0;

            if (SettingName == "BackGroundSound")
            {
                MainSound.Play();
            }
        }
    }
}
