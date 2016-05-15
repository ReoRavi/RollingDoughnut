using UnityEngine;
using System.Collections;

//=======================================
// Topping : 3단계 토핑 오브젝트 애니메이션 처리
public class Topping : MonoBehaviour
{
    // 토핑 애니메이션
    public Animator[] ToppingObject;

    // 애니메이션 시작
    public void AnimationStart()
    {
        for (int i = 0; i < ToppingObject.Length; i++)
        {
            ToppingObject[i].SetBool("bIsTopping", true);
        }
    }

    // 애니메이션 끝
    public void AnimationEnd()
    {
        for (int i = 0; i < ToppingObject.Length; i++)
        {
            ToppingObject[i].SetBool("bIsTopping", false);
        }
    }
}
