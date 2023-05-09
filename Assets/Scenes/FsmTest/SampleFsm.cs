using Assets.Scripts.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 示例。在FsmSample场景中看效果（按F）
/// </summary>
internal class SampleFsm : Fsm
{
    [SerializeField]
    private GameObject target;
    protected override State SetupInitialState()
    {
        // 状态之间存在依赖关系，建议先构造完所有的状态。
        // 然后再配置状态转换。
        var move = new State()
        {
            Name = "Move",
            Execute = Move,

        };
        var idle = new State()
        {
            Name = "Idle",
            Execute = null,
            Transitions = new Transition[] 
            {
                new Transition(){ Condition=() => Input.GetKeyDown(KeyCode.F), Target=move}
            }
        };
        move.Transitions = new Transition[]
        {
            new Transition() 
            { 
                Condition= () => Vector2.Distance(transform.position, target.transform.position) < 5,
                Target=idle
            }
        };
        return idle;
    }

    private void Move()
    {
        transform.Translate((target.transform.position - transform.position).normalized * Time.deltaTime);
    }
}
