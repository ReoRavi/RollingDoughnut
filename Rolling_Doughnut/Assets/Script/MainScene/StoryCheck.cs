using UnityEngine;
using System.Collections;

//=======================================
// StoryCheck : 스토리 버튼 처리
public class StoryCheck : MonoBehaviour
{
    // 버튼의 이미지 정보
    public Renderer Button;
    // 스토리 이름
    public string StoryName;

    // Use this for initialization
    void Start()
    {
        Button = GetComponent<Renderer>();
    }

    // 버튼을 클릭중이라면
    void OnMouseDrag()
    {
        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 0.75F);
    }

    // 버튼 클릭이 완료되었다면
    void OnMouseUp()
    {
        // 스토리가 열린 상태라면
        if (PlayerPrefs.GetInt(StoryName) == 1)
        {
            // 스토리를 보여준다.
            Application.LoadLevel(StoryName);
        }

        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 1F);
    }
}
