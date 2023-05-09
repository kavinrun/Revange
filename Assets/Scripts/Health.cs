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
    /// 承受伤害。通过此方法让生命值发生变动。
    /// </summary>
    /// <param name="damage">受到的伤害</param>
    public void TakeDamage(int damage)
    {
        // TODO：可能会有不同类型的伤害，damage可能不能简简单单是一个数字。debuff等效果待处理
        CurrentHealth = CurrentHealth - damage < 0 ? 0 : CurrentHealth - damage;
    }
}
