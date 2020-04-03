using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ManagerBase<PlayerManager>
{
    public PlayerState PlayerState = new PlayerState();

    private void Awake()
    {
        PlayerState = GetComponent<PlayerState>();
    }
}
