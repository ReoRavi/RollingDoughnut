using UnityEngine;
using System.Collections;

//=======================================
// Tutorial : 튜토리얼 처리
public class Tutorial : MonoBehaviour {

    // 이미지 객체
    public SpriteRenderer Image;
    // 튜토리얼 이미지들
    public Sprite[] TutorialImage;
    // 이미지 카운트
    public int ImageCount;

	// Use this for initialization
	void Start () {
        Image = GetComponent<SpriteRenderer>();
	}

    // 클릭 시
    void OnMouseDown()
    {
        // 이미지 카운트들
        ImageCount++;

        // 이미지 카운트에 따라 이미지를 다르게한다.
        if (ImageCount >= 14)
        {
            if (PlayerPrefs.GetInt("FirstLogin") == 0)
            {
                PlayerPrefs.SetInt("FirstLogin", 1);
                Application.LoadLevel("RunningTutorial");
            }
            else
            {
                Application.LoadLevel("MainScene");
            }
        }
        
        if (ImageCount <= 13)
        {
            Image.sprite = TutorialImage[ImageCount];
        }
    }
}
