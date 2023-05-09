using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Fsm
{
    /// <summary>
    /// 状态的转换
    /// </summary>
    internal struct Transition
    {
        /// <summary>
        /// 目标状态
        /// </summary>
        public State Target { set; get; }
        /// <summary>
        /// 条件
        /// </summary>
        public Func<bool> Condition { set; get; }
    }
}
