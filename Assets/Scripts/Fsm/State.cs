using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Fsm
{
    /// <summary>
    /// 状态机的状态
    /// </summary>
    internal class State
    {
        public string Name { get;  set; }
        /// <summary>
        /// 该状态可以发生的转换
        /// </summary>
        public Transition[] Transitions { get; set; }
        /// <summary>
        /// 在Update中执行的操作
        /// </summary>
        public Action Execute { set; get; }
        /// <summary>
        /// 在FixedUpdate中执行的操作
        /// </summary>
        public Action FixedExecute { set; get; }

        /// <summary>
        /// 将会转移到的状态（可能为空）
        /// </summary>
        public State WillTransitTo => Transitions.Where(t => t.Condition()).FirstOrDefault().Target;
    }
}
