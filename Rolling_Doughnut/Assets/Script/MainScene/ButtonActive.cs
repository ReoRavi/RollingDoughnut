using UnityEngine;
using System.Collections;

//=======================================
// ButtonActive : 버튼의 상태에 따라 이미지를 바꾼다.
public class ButtonActive : MonoBehaviour {

    // 버튼의 상태
    public bool bIsActive;
    // 상태에 따라 처리할 이미지
    public Sprite[] Level_Sprite;
    // 이미지 객체
    public SpriteRenderer Level;

     // 초기화
    void Start()
    {
        bIsActive = false;
    }

    // 마우스가 올려졌을 때 (버튼 클릭이 완료됨)
    void OnMouseUp()
    {
        // 상태에 따라 처리
        if (bIsActive)
        {
            Level.sprite = Level_Sprite[0];
            bIsActive = false;
        }
        else
        {
            Level.sprite = Level_Sprite[1];
            bIsActive = true;
        }
    }
}
