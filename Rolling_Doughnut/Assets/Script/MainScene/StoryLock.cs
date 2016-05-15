using UnityEngine;
using System.Collections;

//=======================================
// StoryLock : 스토리 버튼들을 관리한다.
public class StoryLock : MonoBehaviour {

    // 스토리 오브젝트들.
    public GameObject[] Lock;
    // 잠김 여부
    public bool[] bIsLocked;

	// Use this for initialization
	void Start () {
        bIsLocked = new bool[6];

        LockReset();
	}

    // 스토리들의 정보를 읽고, 활성화 처리를 한다.
    public void LockReset()
    {
        if (PlayerPrefs.GetInt("Story2") == 0)
        {
            bIsLocked[0] = true;
        }
        else
        {
            bIsLocked[0] = false;
        }

        if (PlayerPrefs.GetInt("Story3") == 0)
        {
            bIsLocked[1] = true;
        }
        else
        {
            bIsLocked[1] = false;
        }

        if (PlayerPrefs.GetInt("Story4") == 0)
        {
            bIsLocked[2] = true;
        }
        else
        {
            bIsLocked[2] = false;
        }

        if (PlayerPrefs.GetInt("Story5") == 0)
        {
            bIsLocked[3] = true;
        }
        else
        {
            bIsLocked[4] = false;
        }

        if (PlayerPrefs.GetInt("Story6") == 0)
        {
            bIsLocked[4] = true;
        }
        else
        {
            bIsLocked[4] = false;
        }

        for (int i = 0; i < Lock.Length; i++)
        {
            if (bIsLocked[i])
            {
                Lock[i].SetActive(true);
            }
            else
            {
                Lock[i].SetActive(false);
            }
        }
    }
}
