using System;
using System.Collections.Generic;

namespace LearningDBFirstApproach.Models
{
    public partial class Emp
    {
        public Emp()
        {
            InverseMgrNavigation = new HashSet<Emp>();
        }

        public int Empno { get; set; }
        public string? Ename { get; set; }
        public string? Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Sal { get; set; }
        public int? Comm { get; set; }
        public int Deptno { get; set; }

        public virtual Emp? MgrNavigation { get; set; }
        public virtual ICollection<Emp> InverseMgrNavigation { get; set; }
    }
}
