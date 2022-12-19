using ESandBox.MVVM.Model.Resources;
using System.Windows.Controls;
using System.Windows.Media;

namespace ESandBox.MVVM.Model.Engine
{
    class Controller
    {
        private SpriteLoader _spriteLoader;
        private PrototypeLoader _protorypeLoader;
        private State _state;
        private Rendering _rendering;

        public Controller(Canvas screen)
        {
            _spriteLoader = new SpriteLoader();
            _protorypeLoader = new PrototypeLoader();
            _state = new State();
            _rendering = new Rendering(screen, _state.Map, _spriteLoader.Sprites);

            LoadResources();
            SubscribeEvents();
        }

        private void LoadResources()
        {
            _spriteLoader.Load();
            _protorypeLoader.Load();
        }

        private void SubscribeEvents()
        {
            CompositionTarget.Rendering += (s, e) => _state.MapUpdate();
            CompositionTarget.Rendering += (s, e) => _rendering.Render();
        }
    }
}
