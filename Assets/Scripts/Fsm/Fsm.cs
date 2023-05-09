using Assets.Scripts.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态机。新的状态机应派生自该类。
/// </summary>
internal abstract class Fsm : MonoBehaviour
{
    private State currentState;
    /// <summary>
    /// 子类必须实现的构造状态的方法
    /// </summary>
    /// <returns>初始状态</returns>
    protected abstract State SetupInitialState();

    // 派生类重写时记得调用基类的Start设置初始状态，或者你自己记得写这一行也行
    protected virtual void Start()
    {
        currentState = SetupInitialState();
    }

    protected virtual void Update()
    {
        currentState.Execute?.Invoke();
    }

    protected virtual void FixedUpdate()
    {
        currentState.FixedExecute?.Invoke();
    }

    protected virtual void LateUpdate()
    {
        if (currentState.WillTransitTo != null)
        {
            currentState = currentState.WillTransitTo;
        }
    }
}
