using UnityEngine;
using System.Collections;

//=======================================
// LifeShow : 남은 목숨 UI 처리
public class LifeShow : MonoBehaviour {

    // 숫자 이미지
    public Sprite[] Number;
    // 이미지 객체
    private SpriteRenderer LifeNumber;

	// Use this for initialization
	void Start () {
        LifeNumber = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        // 게임이 진행중이라면
        if (GameManager.instance.Game)
        {
            // 이미지 변경
            LifeNumber.sprite = Number[GameManager.instance.Life];
        }
	}
}
