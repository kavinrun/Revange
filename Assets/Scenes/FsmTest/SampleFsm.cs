using Assets.Scripts.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ʾ������FsmSample�����п�Ч������F��
/// </summary>
internal class SampleFsm : Fsm
{
    [SerializeField]
    private GameObject target;
    protected override State SetupInitialState()
    {
        // ״̬֮�����������ϵ�������ȹ��������е�״̬��
        // Ȼ��������״̬ת����
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
