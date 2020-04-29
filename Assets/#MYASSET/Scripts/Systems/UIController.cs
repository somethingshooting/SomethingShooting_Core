using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public ICharacterState _PlayerState;
    public List<ICharacterState> _BossStates = new List<ICharacterState>();

    [SerializeField] private Slider _PlayerHp;
    [SerializeField] private List<Slider> _BossHp =new List<Slider>();

    // Start is called before the first frame update
    void Start()
    {
        _PlayerState = PlayerManager.Instance.PlayerState as ICharacterState;
        _PlayerHp.maxValue = _PlayerState.HP.MaxValue;
        _PlayerHp.value = _PlayerState.HP.Value;
        for (int i = 0; i < _BossHp.Count; i++)
        {
            _BossHp[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpUpdate();
        BossCheck();
        BossHpUpdate();
    }

    public void BossSet(ICharacterState state)
    {
        _BossStates.Add(state);
    }


    private void PlayerHpUpdate()
    {
        _PlayerHp.value = _PlayerState.HP.Value;
    }

    private void BossHpUpdate()
    {
        for (int i = 0; i < Mathf.Min(_BossStates.Count,_BossHp.Count); i++)
        {
            _BossHp[i].value = _BossStates[i].HP.Value;
        }
    }
    private int _Count = 0;
    private void BossCheck()
    {
        for (int i = _BossStates.Count - 1; i >= 0; i--)
        {
            if (_BossStates[i] == null)
            {
                _BossStates.RemoveAt(i);
            }
        }
        if (_Count!=_BossStates.Count)
        {
            for (int i = 0; i < _BossHp.Count; i++)
            {
                _BossHp[i].enabled = false;
            }
            for (int i = 0; i < Mathf.Min(_BossStates.Count, _BossHp.Count); i++)
            {
                _BossHp[i].gameObject.SetActive(true);
                _BossHp[i].maxValue = _BossStates[i].HP.MaxValue;
                _BossHp[i].value = _BossStates[i].HP.Value;
            }
        }
        _Count = _BossStates.Count;
    }
}
