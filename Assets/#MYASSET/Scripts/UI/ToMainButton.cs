using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToMainButton : MonoBehaviour
{
    private Button _Button = null;

    void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.Instance.ChangeScene("Main");
    }
}
