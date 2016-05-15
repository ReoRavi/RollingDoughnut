using UnityEngine;
using System.Collections;

//=======================================
// Pause : 일시정지 처리
public class Pause : MonoBehaviour
{
    // 화면을 어둡게 해줄 오브젝트
    public GameObject Fade;
    // 나가기 버튼
    public GameObject Exit;
    // 재생 버튼
    public GameObject Resume;

	// Use this for initialization
	void Start () {
        Fade.SetActive(false);
        Exit.SetActive(false);
        Resume.SetActive(false);
	}

    // 클릭 시
    void OnMouseDown()
    {
        // 일시정지 상태가 아니라면
        if (!GameManager.instance.bIsPause)
        {
            // 오브젝트 활성화 처리
            Fade.SetActive(true);
            Exit.SetActive(true);
            Resume.SetActive(true);
            GameManager.instance.bIsPause = true;
        }
    }
}
