using UnityEngine;
using System.Collections;

//=======================================
// StoryBuy : 스토리를 구매한다.
public class StoryBuy : MonoBehaviour
{
    // 구매할 스토리 레벨
    public int StoryLevel;
    // 잠긴 스토리들
    public StoryLock Lock;

    // 클릭이 완료됬을 때
    void OnMouseUp()
    {
        // 플레이어가 얻은 스토리 레벨과 클릭한 스토리 레벨을 비교한다. 
        if (PlayerPrefs.GetInt("StoryNum") == StoryLevel)
        {
            // 젤리가 충분히 있다면 (5번 스토리는 좀 비싸다)
            if (PlayerPrefs.GetInt("Jelly") >= 500)
            {
                if (StoryLevel == 5)
                {
                    PlayerPrefs.SetInt("Story5", 1);
                    PlayerPrefs.SetInt("Jelly", PlayerPrefs.GetInt("Jelly") - 500);
                    PlayerPrefs.SetInt("StoryNum", PlayerPrefs.GetInt("StoryNum") + 1);
                    Lock.LockReset();
                }
            }

            // 일반 스토리는 300 젤리
            if (PlayerPrefs.GetInt("Jelly") >= 300)
            {
                switch (StoryLevel)
                {
                    case 2:
                        PlayerPrefs.SetInt("Story2", 1);
                        PlayerPrefs.SetInt("Jelly", PlayerPrefs.GetInt("Jelly") - 300);
                        PlayerPrefs.SetInt("StoryNum", PlayerPrefs.GetInt("StoryNum") + 1);
                        Lock.LockReset();

                        break;

                    case 3:
                        PlayerPrefs.SetInt("Story3", 1);
                        PlayerPrefs.SetInt("Jelly", PlayerPrefs.GetInt("Jelly") - 300);
                        PlayerPrefs.SetInt("StoryNum", PlayerPrefs.GetInt("StoryNum") + 1);
                        Lock.LockReset();

                        break;

                    case 4:
                        PlayerPrefs.SetInt("Story4", 1);

                        PlayerPrefs.SetInt("Jelly", PlayerPrefs.GetInt("Jelly") - 300);
                        PlayerPrefs.SetInt("StoryNum", PlayerPrefs.GetInt("StoryNum") + 1);
                        Lock.LockReset();

                        break;

                    case 6:
                        PlayerPrefs.SetInt("Story6", 1);
                        PlayerPrefs.SetInt("Jelly", PlayerPrefs.GetInt("Jelly") - 300);
                        PlayerPrefs.SetInt("StoryNum", PlayerPrefs.GetInt("StoryNum") + 1);
                        Lock.LockReset();

                        break;
                }
            }
        }
    }
}
