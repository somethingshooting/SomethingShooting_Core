using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ParagraphManager))]
public class TextEventUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image[] CharactorImage;
    [SerializeField] private Text TextName;
    [SerializeField] private Text TextMessage;

    private PlayerInput input;
    private ParagraphManager manager;
    private ParagraphData.TextBlock CurrentBlock;
    int progress = -1;

    bool cannext = false;
    float inputbuffer = 0.5f;
    public void StartTextEvent(ParagraphData.TextBlock block)
    {
        progress = -1;
        panel.SetActive(true);
        TextName.enabled = true;
        TextMessage.enabled = true;
        for (int i = 0; (i < block.Characters.Length && i <4); i++)
        {
            CharactorImage[i].sprite = block.Characters[i].Image;
            CharactorImage[i].enabled = true;
        }
        CurrentBlock = block;
        cannext = true;
        NextMessage();
    }
    [ContextMenu("NextMessage")]
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
            panel.SetActive(false);
            cannext = false;
            manager.TextEventEnd();
        }
    }

    private void Start()
    {
        manager = GetComponent<ParagraphManager>();
        input = GetComponent<PlayerInput>();
        foreach (var item in CharactorImage)
        {
            item.enabled = false;
        }
        TextName.enabled = false;
        TextMessage.enabled = false;
        TextName.text = "";
        TextMessage.text = "";
    }

    private void Update()
    {
        if (cannext)
        {
            if (inputbuffer <= 0)
            {
                if (input.actions["Next"].ReadValue<float>() > 0)
                {
                    NextMessage();
                    inputbuffer = 0.5f;
                }
            }
            else
            {
                inputbuffer -= Time.deltaTime;
            }
        }
        if(input.actions["Next"].ReadValue<float>()>0)
        Debug.Log(input.actions["Next"].ReadValue<float>());
    }
}
