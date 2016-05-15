using UnityEngine;
using System.Collections;

//=======================================
// OpacityControl : 투명도 조절
public class OpacityControl : MonoBehaviour {
    // 투명도 값
    public float Transperancy;
    // 텍스트 이미지 객체
    public Renderer Text;
    // 투명도 조절 방향
    public int Direction;

	// Use this for initialization
	void Start () {
        Text = GetComponent<Renderer>();
        Transperancy = 1;
        Direction = -1;
	}
	
	// Update is called once per frame
	void Update () {

        // 투명도 조절하기
        Transperancy += Direction * 0.04F;

        if (Transperancy <= 0)
        { 
            Direction = 1;
        }

        if (Transperancy >= 1)
        {
            Direction = -1;
        }

        Text.material.color = new Color(Text.material.color.r, Text.material.color.g, Text.material.color.b, Transperancy);
	}
}
