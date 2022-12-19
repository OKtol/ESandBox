using ESandBox.MVVM.Model.Content.BlackWhiteTile;
using ESandBox.MVVM.Model.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ESandBox.MVVM.Model.Engine
{
    class State
    {
        private List<EntitySystem> _entitySystems;
        private Map _map;
        private DateTime _lastMapUpdateTime;

        public State()
        {
            _entitySystems = new List<EntitySystem>();
            _map = new Map(new Size(25, 30));
            _lastMapUpdateTime = DateTime.Now;

            RegisterSystems();
        }

        public Map Map { get { return _map; } }

        public void MapUpdate()
        {
            if (DateTime.Now - _lastMapUpdateTime > TimeSpan.FromSeconds(5))
            {
                _map.Update();
                _lastMapUpdateTime = DateTime.Now;
            }
        }

        public void UpdateAll()
        {
            foreach (var system in _entitySystems)
                system.Update();
        }

        private void RegisterSystems()
        {
            _entitySystems.Add(new BlackWhiteTileEntitySystem());
        }
    }
}
