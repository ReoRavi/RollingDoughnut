using UnityEngine;
using System.Collections;

//=======================================
// StoryLock : 스토리 씬 관리
public class StoryScene : MonoBehaviour {

    // 클릭된다면
    void OnMouseDown()
    {
        // 메인메뉴를 불러온다.
        Application.LoadLevel("MainScene");
    }
}
