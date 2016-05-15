using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{
    public int DataCount;
    public GameObject UI;
    public GameObject Fade;
    public SpriteRenderer UI_Sprite;
    public Sprite[] UpgradeUI_Image;
    public int Level;

    // Use this for initialization
    void Start()
    {
        Fade.gameObject.SetActive(false);

        if (DataCount == 0)
        {
            Level = PlayerPrefs.GetInt("TentLevel");

            if (Level < UpgradeUI_Image.Length)
            {
                UI_Sprite.sprite = UpgradeUI_Image[Level];
            }
        }

        if (DataCount == 1)
        {
            Level = PlayerPrefs.GetInt("ClerkLevel");

            if (Level < UpgradeUI_Image.Length)
            {
                UI_Sprite.sprite = UpgradeUI_Image[Level];
            }
        }
    }

    void OnMouseDown()
    {
        if (DataCount == 0)
        {
            Level = PlayerPrefs.GetInt("TentLevel");
            TycoonManager.instance.UprageCount = 0;

            if (!(Level < TycoonManager.instance.Tent_Sprite.Length))
            {
                return;
            }

            if (Level < UpgradeUI_Image.Length)
            {
                UI.gameObject.SetActive(true);
                Fade.gameObject.SetActive(true);
                TycoonManager.instance.Button[0].SetActive(true);
                TycoonManager.instance.Button[1].SetActive(true);

                UI_Sprite.sprite = UpgradeUI_Image[Level];
            }
        }

        if (DataCount == 1)
        {
            Level = PlayerPrefs.GetInt("ClerkLevel");
            TycoonManager.instance.UprageCount = 1;

            if (!(Level < TycoonManager.instance.Clerk_Sprite.Length))
            {
                return;
            }

            if (Level < UpgradeUI_Image.Length)
            {
                UI.gameObject.SetActive(true);
                Fade.gameObject.SetActive(true);
                TycoonManager.instance.Button[0].SetActive(true);
                TycoonManager.instance.Button[1].SetActive(true);

                UI_Sprite.sprite = UpgradeUI_Image[Level];
            }
        }
    }
}
