using UnityEngine;
using System.Collections;

//=======================================
// Sprite_Rotate : 이미지
public class Sprite_Rotate : MonoBehaviour
{
    // 이미지 각도
    public float Angle;
    // 회전 속도
    public float RotateSpeed;
    // 회전중인가
    public bool bIsRotate;

	// Use this for initialization
	void Start () {
        Angle = this.transform.rotation.z;
        bIsRotate = true;
	}

    // 루프
    void Update()
    {
        // 게임 중이라면
        if (GameManager.instance.Game)
        {
            // 회전 중이라면
            if (bIsRotate)
            {
                // 회전 처리
                Angle += RotateSpeed;

                this.transform.Rotate(0, 0, -RotateSpeed);

                if (Angle >= 360)
                {
                    Angle = 0;
                }
            }
        }
    }
}
