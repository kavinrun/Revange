using System;
using System.ComponentModel;
using Assets.Scripts;
using UnityEngine;

/// <summary>
/// 主角战斗系统的基类。在两个派生类中分别实现表里两种姿态。
/// 本脚本中应只关注攻击（和技能施放）相关行为。
/// 其它能力如冲刺应放在其它脚本中。
/// </summary>
internal abstract class BattleSystem : MonoBehaviour
{
    [SerializeField]
    protected SkillProperties attackProperties;
    [SerializeField]
    protected SkillProperties skill1Properties;
    [SerializeField]
    protected SkillProperties skill2Properties;
    [SerializeField]
    protected SkillProperties ultimateSkill1Properties;
    [SerializeField]
    protected SkillProperties ultimateSkill2Properties;

    /// <summary>
    /// 技能名字，方便其它脚本调用Cast时传入更易读的参数。可能应该给技能换个名字
    /// </summary>
    public enum SkillIndex { Skill1, Skill2, UltimateSkill1, UltimateSkill2 }
    /// <summary>
    /// 获得当前技能组。用不上就删了。如果用的地方多，元组显得太丑陋，可以考虑单独写一个SkillSet结构
    /// </summary>
    public (SkillProperties attack, SkillProperties skill1, SkillProperties skill2, SkillProperties ultimate1, SkillProperties ultimate2) SkillSet
        => (attackProperties, skill1Properties, skill2Properties, ultimateSkill1Properties, ultimateSkill2Properties);

    protected SkillProperties GetSkillProperties(SkillIndex index)
    {
        return index switch
        {
            SkillIndex.Skill1 => skill1Properties,
            SkillIndex.Skill2 => skill2Properties,
            SkillIndex.UltimateSkill1 => ultimateSkill1Properties,
            SkillIndex.UltimateSkill2 => ultimateSkill2Properties,
            _ => throw new InvalidEnumArgumentException(), // 不太可能发生，纯粹为了让VS闭嘴
        };
    }
    public abstract void Attack();
    /// <summary>
    /// 施放技能
    /// </summary>
    public abstract void Cast(SkillIndex index);
    // TODO: 暂时先这样
}
