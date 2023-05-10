using Assets.Scripts.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ״̬�����µ�״̬��Ӧ�����Ը��ࡣ
/// </summary>
internal abstract class Fsm : MonoBehaviour
{
    private State currentState;
    /// <summary>
    /// �������ʵ�ֵĹ���״̬�ķ���
    /// </summary>
    /// <returns>��ʼ״̬</returns>
    protected abstract State SetupInitialState();

    // ��������дʱ�ǵõ��û����Start���ó�ʼ״̬���������Լ��ǵ�д��һ��Ҳ��
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
