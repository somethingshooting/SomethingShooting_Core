using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParagraphManager))]
public class TextEventUI : MonoBehaviour
{
    [SerializeField] private Image[] CharactorImage;
    [SerializeField] private Text TextName;
    [SerializeField] private Text TextMessage;

    private ParagraphManager manager;
    private ParagraphManager.ParagraphData.TextBlock CurrentBlock;
    int progress = -1;
    public void StartTextEvent(ParagraphManager.ParagraphData.TextBlock block)
    {
        progress = -1;
        TextName.enabled = true;
        TextMessage.enabled = true;
        for (int i = 0; i < block.Characters.Length||i<4; i++)
        {
            CharactorImage[i].sprite = block.Characters[i].Image;
            CharactorImage[i].enabled = true;
        }
        CurrentBlock = block;
        NextMessage();
    }

    public void NextMessage()
    {
        progress++;
        if (progress < CurrentBlock.Texts.Length)
        {
            TextName.text = CurrentBlock.Characters[ CurrentBlock.Texts[progress].Character].Name;
            TextMessage.text = CurrentBlock.Texts[progress].Message;
        }
        else
        {
            foreach (var item in CharactorImage)
            {
                item.enabled = false;
            }
            TextName.enabled = false;
            TextMessage.enabled = false;
            TextName.text = "";
            TextMessage.text = "";
            manager.TextEventEnd();
        }
    }

    private void Start()
    {
        manager = GetComponent<ParagraphManager>();
        foreach (var item in CharactorImage)
        {
            item.enabled = false;
        }
        TextName.enabled = false;
        TextMessage.enabled = false;
        TextName.text = "";
        TextMessage.text = "";
    }
}
