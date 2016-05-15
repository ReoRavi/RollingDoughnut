using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Faint : 판매한 도넛을 보여준다.
public class Doughnut_Faint : MonoBehaviour {

    // 도넛 이미지 오브젝트
    private Renderer Doughnut;
    // 투명도
    private float Transparency;

	// Use this for initialization
	void Start () {
        Doughnut = GetComponent<Renderer>();
        Transparency = 1.0F;
	}
	
	// Update is called once per frame
	void Update () {
        // 점점 투명도를 낮춘다.
        Transparency -= 0.01F;

        if (Transparency <= 0)
        {
            Destroy(this);
        }

        Doughnut.material.color = new Color(Doughnut.material.color.r, Doughnut.material.color.g, Doughnut.material.color.b, Transparency);
	}
}
