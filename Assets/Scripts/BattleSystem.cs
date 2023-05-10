using System;
using System.ComponentModel;
using Assets.Scripts;
using UnityEngine;

/// <summary>
/// ����ս��ϵͳ�Ļ��ࡣ�������������зֱ�ʵ�ֱ���������̬��
/// ���ű���Ӧֻ��ע�������ͼ���ʩ�ţ������Ϊ��
/// ������������Ӧ���������ű��С�
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
    /// �������֣����������ű�����Castʱ������׶��Ĳ���������Ӧ�ø����ܻ�������
    /// </summary>
    public enum SkillIndex { Skill1, Skill2, UltimateSkill1, UltimateSkill2 }
    /// <summary>
    /// ��õ�ǰ�����顣�ò��Ͼ�ɾ�ˡ�����õĵط��࣬Ԫ���Ե�̫��ª�����Կ��ǵ���дһ��SkillSet�ṹ
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
            _ => throw new InvalidEnumArgumentException(), // ��̫���ܷ���������Ϊ����VS����
        };
    }
    public abstract void Attack();
    /// <summary>
    /// ʩ�ż���
    /// </summary>
    public abstract void Cast(SkillIndex index);
    // TODO: ��ʱ������
}
