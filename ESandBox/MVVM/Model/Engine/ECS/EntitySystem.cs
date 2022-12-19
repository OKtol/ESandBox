using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESandBox.MVVM.Model.Engine.ECS
{
    abstract class EntitySystem
    {
        public abstract void Update();
    }
}
