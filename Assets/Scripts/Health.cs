using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int max;
    public int Max { get => max; set => max = value; }
    public int CurrentHealth { get; private set; }
    /// <summary>
    /// ��Ӧ�����仯�¼���ί��
    /// </summary>
    /// <param name="delta">�����仯�˶���</param>
    /// <param name="currentHealth">�仯�������</param>
    public delegate void HealthChangeEventHandler(int delta, int currentHealth);
    public event HealthChangeEventHandler HealthChanged;
    /// <summary>
    /// �����˺���ͨ���˷���������ֵ�����䶯��
    /// </summary>
    /// <param name="damage">�ܵ����˺�</param>
    public void TakeDamage(int damage)
    {
        // TODO�����ܻ��в�ͬ���͵��˺���damage���ܲ��ܼ�򵥵���һ�����֡�debuff��Ч��������
        CurrentHealth = CurrentHealth - damage < 0 ? 0 : CurrentHealth - damage;
        HealthChanged?.Invoke(damage, CurrentHealth);
    }
}
