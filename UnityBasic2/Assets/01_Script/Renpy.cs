using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG; // ���
    [SerializeField] Image[] img_Character; // ĳ����

    [SerializeField] TextMeshProUGUI txt_Name; // ĳ���� �̸� : ȣ�ó�
    [SerializeField] TextMeshProUGUI txt_NameTitle; // ĳ���� Ÿ��Ʋ : ��å����ȸ
    [SerializeField] TextMeshProUGUI txt_Dialogue; // ��� : ���⿡ ��簡 ��µ˴ϴ�.

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
        int characterID = SData.GetDialogueData(id).Characterid[0]; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷��� ������ �´�.
        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸��� ������ �´�.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� ID�� Ÿ��Ʋ�� ������ �´�.

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
