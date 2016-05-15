using UnityEngine;
using System.Collections;

//=======================================
// Topping_Control : 3단계 토핑 오브젝트 컨트롤 (버튼에 달려있다.)
public class Topping_Control : MonoBehaviour
{
    // 토핑 오브젝트
    public Topping ToppingControler;
    // 토핑 좌표
    public Transform ToppingTransform;
    // 토핑 타입
    public int ToppingType;
    // 버튼
    private Renderer Button;

    // Use this for initialization
    void Start()
    {
        Button = GetComponent<Renderer>();
    }

    // 루프
    void Update()
    {
        // 게임중이라면
        if (GameManager.instance.Game)
        {
            // 버튼 배치
            this.transform.position = new Vector3(7, -3.5F, this.transform.position.z);

            if (ToppingTransform.position.x < -12)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // 클릭중이라면
    void OnMouseDrag()
    {
        // 토핑 애니메이션 처리
        ToppingControler.SendMessage("AnimationStart");

        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 0.75F);

        if (GameManager.instance.bIsTopping)
        {
            GameManager.instance.ToppingType = ToppingType;
        }
    }

    // 클릭이 끝남
    void OnMouseUp()
    {
        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 1F);

        ToppingControler.SendMessage("AnimationEnd");
    }
}
