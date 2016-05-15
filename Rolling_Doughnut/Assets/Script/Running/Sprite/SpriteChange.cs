using UnityEngine;
using System.Collections;

//=======================================
// SpriteChange :  스프라이트 변경 처리
public class SpriteChange : MonoBehaviour {

    // 바꿀 스프라이트들
    public Sprite[] Image;
    // 이미지 객체
    private SpriteRenderer Renderer;

	// Use this for initialization
	void Start () {
        Renderer = GetComponent<SpriteRenderer>();
	}

    public void ImageChange(int Level)
    {
        Renderer.sprite = Image[Level];
    }
}
