using UnityEngine;
using System.Collections;

//=======================================
// GameInitailize : 게임 시작 초기화
public class GameInitailize : MonoBehaviour
{
    // 배경음악 오브젝트
    public GameObject Sound;

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width / 16 * 10, true);

        // 처음 로그인이면, 튜토리얼을 진행한다.
        if (PlayerPrefs.HasKey("FirstLogin") == false)
        {
            PlayerPrefs.SetInt("FirstLogin", 0);

            // 게임 값들을 가져온다.
            if (PlayerPrefs.GetInt("FirstLogin") == 0)
            {
                PlayerPrefs.SetInt("Doughnut1", -1);
                PlayerPrefs.SetInt("Doughnut2", -1);
                PlayerPrefs.SetInt("Doughnut3", -1);
                PlayerPrefs.SetInt("Doughnut4", -1);
                PlayerPrefs.SetInt("Doughnut5", -1);
                PlayerPrefs.SetInt("Doughnut6", -1);
                PlayerPrefs.SetInt("Doughnut7", -1);
                PlayerPrefs.SetInt("Doughnut8", -1);
                PlayerPrefs.SetInt("Doughnut9", -1);
                PlayerPrefs.SetInt("Doughnut10", -1);

                PlayerPrefs.SetInt("Doughnut1Price", 0);
                PlayerPrefs.SetInt("Doughnut2Price", 0);
                PlayerPrefs.SetInt("Doughnut3Price", 0);
                PlayerPrefs.SetInt("Doughnut4Price", 0);
                PlayerPrefs.SetInt("Doughnut5Price", 0);
                PlayerPrefs.SetInt("Doughnut6Price", 0);
                PlayerPrefs.SetInt("Doughnut7Price", 0);
                PlayerPrefs.SetInt("Doughnut8Price", 0);
                PlayerPrefs.SetInt("Doughnut9Price", 0);
                PlayerPrefs.SetInt("Doughnut10Price", 0);

                PlayerPrefs.SetInt("Coin", 0);
                PlayerPrefs.SetInt("Jelly", 0);
                PlayerPrefs.SetInt("Quality", 0);

                PlayerPrefs.SetInt("Doughnut_Number", 0);

                PlayerPrefs.SetInt("TentLevel", 0);
                PlayerPrefs.SetInt("ClerkLevel", 0);

                PlayerPrefs.SetInt("BackGroundSound", 0);
                PlayerPrefs.SetInt("EffectSound", 0);

                PlayerPrefs.SetInt("Story1", 1);
                PlayerPrefs.SetInt("Story2", 0);
                PlayerPrefs.SetInt("Story3", 0);
                PlayerPrefs.SetInt("Story4", 0);
                PlayerPrefs.SetInt("Story5", 0);
                PlayerPrefs.SetInt("Story6", 0);

                PlayerPrefs.SetInt("StoryNum", 2);
            }
        }

        // 음악 오브젝트 생성
        Instantiate(Sound, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // 클릭되었을 때
    void OnMouseDown()
    {
        // 처음 로그인했다면
        if (PlayerPrefs.GetInt("FirstLogin") == 0)
        {
            // 튜토리얼을 진행한다.
            Application.LoadLevel("Tutorial");
        }
        else
        {
            // 바로 메인메뉴로 이동한다.
            Application.LoadLevel("MainScene");
        }
    }
}
