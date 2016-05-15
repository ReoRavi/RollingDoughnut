using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Start : 도넛의 시작 초기화 부분
public class Doughnut_Start : MonoBehaviour {

    // 도넛 오브젝트
    public GameObject Doughnut;

    // 기름에 충돌하여 도넛이 준비되는 애니메이션 처리
    void OnTriggerEnter2D(Collider2D Col)
    {
        // 기름에 충돌하면
        if (Col.gameObject.tag == "StartZone")
        {
            Doughnut.SetActive(true);
            Doughnut.GetComponent<Rigidbody2D>().gravityScale = 8;
            Doughnut.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1750F));
            Destroy(this.gameObject);
        }
    }
}
