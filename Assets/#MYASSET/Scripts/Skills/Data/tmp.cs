using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class tmp : ActiveSkill
{
    protected override void Init()
    {
        InputController.Instance.NormalShotButtonPushed
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ => Debug.Log(GetComponent<SkillController>().NormalShotSkill.SkillName));
    }

    protected override void SkillStart()
    {

    }

    protected override void SkillUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
