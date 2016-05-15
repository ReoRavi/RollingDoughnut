using UnityEngine;
using System.Collections;

//=======================================
// Resume : 재생 처리
public class Resume : MonoBehaviour {

    // 화면을 어둡게 해줄 오브젝트
    public GameObject Fade;
    // 나가기 버튼
    public GameObject Exit;
    // 재생 버튼
    public GameObject ResumeObj;

    // 클릭 시
    void OnMouseDown()
    {
         // 오브젝트 활성화 처리
        Fade.SetActive(false);
        Exit.SetActive(false);
        ResumeObj.SetActive(false);
        GameManager.instance.bIsPause = false;
    }
}
