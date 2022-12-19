using ESandBox.MVVM.Model.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace ESandBox.MVVM.Model.Resources
{
    class SpriteLoader
    {
        Dictionary<string, BitmapImage> _sprites;

        public SpriteLoader() 
        {
            _sprites = new Dictionary<string, BitmapImage>();
        }

        public ReadOnlyDictionary<string, BitmapImage> Sprites { get => _sprites.AsReadOnly(); }

        public void Load()
        {
            var pathToSprites = "C:\\Users\\OKtolka\\Desktop\\pets\\ESandBox\\ESandBox\\MVVM\\Model\\Resources\\Sprites\\";
            var directoryInfo = new DirectoryInfo(pathToSprites);
            var files = directoryInfo.GetFiles("*.bmp");
            foreach (var file in files)
            {
                var image = new BitmapImage(new Uri(file.FullName));
                _sprites.Add(file.Name, image);
            }
        }
    }
}
