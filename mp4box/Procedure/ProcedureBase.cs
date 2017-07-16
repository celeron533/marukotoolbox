using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Procedure
{
    public abstract class ProcedureBase<T>
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public abstract void GetDataFromUI(Action<T> p);
        public abstract void SetDataToUI(Action<T> p);
        public abstract void Execute();
    }
}
