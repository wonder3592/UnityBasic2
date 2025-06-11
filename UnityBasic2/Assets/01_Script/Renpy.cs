using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG; // 배경
    [SerializeField] Image[] img_Character; // 캐릭터

    [SerializeField] TextMeshProUGUI txt_Name; // 캐릭터 이름 : 호시노
    [SerializeField] TextMeshProUGUI txt_NameTitle; // 캐릭터 타이틀 : 대책위원회
    [SerializeField] TextMeshProUGUI txt_Dialogue; // 대사 : 여기에 대사가 출력됩니다.

    int id = 1;

    void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        id++; // 2
        RefreshUI();
    }

    void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Characterid[0]; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼을 가지고 온다.
        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름을 가지고 온다.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 ID에 타이틀을 가지고 온다.

        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue;

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);


        for (int i = 0; i < img_Character.Length; i++)
        {
            img_Character[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SData.GetDialogueData(id).Characterid.Length; i++)
        {
            for (int j = 0; j < img_Character.Length; j++)
            {
                if(j == SData.GetDialogueData(id).Position[i]) // 5
                {
                    img_Character[j].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(SData.GetDialogueData(id).Characterid[i]).Image);
                    img_Character[j].gameObject.SetActive(true);
                }
            }
        }
    }
}
