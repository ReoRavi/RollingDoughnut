using UnityEngine;
using System.Collections;

//=======================================
// UIButton : UI 버튼 처리
public class UIButton : MonoBehaviour {
    // 업그레이드 유무
    public bool bIsUprade;
    // FadeOut 오브젝트
    public GameObject Fade;

    // 클릭되었을 때
    void OnMouseDown()
    {
        // 업그레이드 유무
        if (bIsUprade)
        {
            // 업그레이드를 한다.
            TycoonManager.instance.LevelUpRequest();            
        }
        else
        {
            // UI를 숨긴다
            TycoonManager.instance.UIHide();
        }

        Fade.gameObject.SetActive(false);
    }
}
