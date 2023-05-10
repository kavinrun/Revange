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
    /// �����˺���ͨ���˷���������ֵ�����䶯��
    /// </summary>
    /// <param name="damage">�ܵ����˺�</param>
    public void TakeDamage(int damage)
    {
        // TODO�����ܻ��в�ͬ���͵��˺���damage���ܲ��ܼ�򵥵���һ�����֡�debuff��Ч��������
        CurrentHealth = CurrentHealth - damage < 0 ? 0 : CurrentHealth - damage;
    }
}
