using UnityEngine;
using System.Collections;

//=======================================
// ButtonOpacity : 사용자가 버튼에 가한 처리에 따라 버튼의 이미지를 처리한다.
public class ButtonOpacity : MonoBehaviour
{
    // 투명도를 조절하기 위한 객체
    private Renderer Button;
    // 이 오브젝트가 처리됨과 동시에 처리될 다른 버튼들
    public GameObject[] OhterButton;
    // 다른 버튼들의 투명도 
    public ButtonOpacity[] OtherOpacity;
    // 효과음
    public GameObject Sound;
    // 배경음악
    public AudioSource MainSound;
    // 씬의 이름
    public string SceneName;
    // 씬 버튼인지
    public bool bIsSceneButton;
    // 터치 상태
    public bool bIsTouched;
    // 활성화 상태
    public bool bIsActive;

    // Use this for initialization
    void Start()
    {
        // 이전 씬의 배경음악을 이어받기 위해 오브젝트를 받는다.
        Sound = GameObject.Find("Sound(Clone)");
        MainSound = Sound.GetComponent<AudioSource>();
        Button = GetComponent<Renderer>();
        bIsTouched = false;
        bIsActive = false;
    }

    // 루프
    void Update()
    {
        // 씬버튼이거나, 터치를 한 상태라면
        if (bIsSceneButton && bIsTouched)
        {
            // 활성화 여부에 따라 처리
            if (!bIsActive)
            {
                // 화면 밖으로 나가는것을 막는다.
                if (this.transform.position.x <= 13.8F)
                {
                    this.transform.position = new Vector3(this.transform.position.x + 0.5F, this.transform.position.y, -6F);
                }
                else
                {
                    this.transform.position = new Vector3(13.8F, this.transform.position.y, this.transform.position.z);
                    bIsTouched = false;
                }
            }
            else
            {
                if (this.transform.position.x >= 0)
                {
                    this.transform.position = new Vector3(this.transform.position.x - 0.5F, this.transform.position.y, -6F);
                }
                else
                {
                    this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
                    bIsTouched = false;
                }
            }
        }
    }

    // 누른채 드래그중이라면
    void OnMouseDrag()
    {
        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 0.75F);
    }

    // 마우스가 들렸을 때
    void OnMouseUp()
    {
        Button.material.color = new Color(Button.material.color.r, Button.material.color.g, Button.material.color.b, 1F);

        if (bIsSceneButton)
        {
            if (bIsActive)
            {
                bIsActive = false;
            }
            else
            {
                bIsActive = true;
            }

            bIsTouched = true;

            // 연결된 다른 오브젝트들
            for (int i = 0; i < OtherOpacity.Length; i++)
            {
                OtherOpacity[i].bIsActive = false;
                OtherOpacity[i].bIsTouched = false;
            }

            for (int i = 0; i < OhterButton.Length; i++)
            {
                OhterButton[i].transform.position = new Vector3(13.8F, OhterButton[i].transform.position.y, -7);
            }
        }
        else
        {
            if (SceneName == "RunningGame")
            {
                MainSound.Stop();
            }

            Application.LoadLevel(SceneName);
        }
    }
}
