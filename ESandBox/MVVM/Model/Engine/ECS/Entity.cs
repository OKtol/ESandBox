﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESandBox.MVVM.Model.Engine.ECS
{
    class Entity
    {
        public string Name { get; set; }
        public List<Component> Components { get; set; }
    }
}
