using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEventFlag : MonoBehaviour
{
    public ParagraphManager.ParagraphData.TextBlock block;

    [SerializeField] private TextAsset text;
    public string sample;
    [ContextMenu("ReadTextAsset")]
    public void ReadTextAsset()
    {
        var array = text.text.Split(new string[] { "\r\n" },System.StringSplitOptions.None);
        block.Texts = new ParagraphManager.ParagraphData.TextBlock.TextData[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            var item = array[i].Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
            block.Texts[i].Character = int.Parse(item[0]);
            block.Texts[i].Message = item[1];
        }
    }
}
