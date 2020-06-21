using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testskillpanel : MonoBehaviour
{
    [SerializeField] ParagraphManager manager;
    private void OnEnable()
    {
        Debug.Log("SkillPanel");
        manager.SkillSelectEnd();
    }
}
