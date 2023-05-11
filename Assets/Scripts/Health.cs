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
    /// 响应生命变化事件的委托
    /// </summary>
    /// <param name="delta">生命变化了多少</param>
    /// <param name="currentHealth">变化后的生命</param>
    public delegate void HealthChangeEventHandler(int delta, int currentHealth);
    public event HealthChangeEventHandler HealthChanged;
    /// <summary>
    /// 承受伤害。通过此方法让生命值发生变动。
    /// </summary>
    /// <param name="damage">受到的伤害</param>
    public void TakeDamage(int damage)
    {
        // TODO：可能会有不同类型的伤害，damage可能不能简简单单是一个数字。debuff等效果待处理
        CurrentHealth = CurrentHealth - damage < 0 ? 0 : CurrentHealth - damage;
        HealthChanged?.Invoke(damage, CurrentHealth);
    }
}
