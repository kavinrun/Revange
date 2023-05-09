using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName ="Skill", menuName ="Gameplay/Skill", order = 0)]
    internal class SkillProperties : ScriptableObject
    {
        [SerializeField]
        private string skillName;
        public string Name => skillName;
        [Multiline]
        [SerializeField]
        private string description;
        public string Description => description;
        [SerializeField]
        public uint damage;
        public uint Damage => damage;
        [SerializeField]
        private uint cost;
        public uint Cost => cost;
    }
}
