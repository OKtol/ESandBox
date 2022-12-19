using ESandBox.MVVM.Model.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace ESandBox.MVVM.Model.Resources
{
    class PrototypeLoader
    {
        private Dictionary<string, Entity> _prototypes;

        public PrototypeLoader()
        {
            _prototypes = new Dictionary<string, Entity>();
        }

        public ReadOnlyDictionary<string,Entity> Prototypes { get => _prototypes.AsReadOnly(); }

        public void Load()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var pathToPrototypes = "C:\\Users\\OKtolka\\Desktop\\pets\\ESandBox\\ESandBox\\MVVM\\Model\\Resources\\Prototypes\\";
            var directoryInfo = new DirectoryInfo(pathToPrototypes);
            var files = directoryInfo.GetFiles("*.yaml");
            foreach ( var file in files) 
            {
                var text = File.ReadAllText(file.FullName);
                var entity = deserializer.Deserialize<Entity>(text);
                _prototypes.Add(entity.Name, entity);
            }
        }
    }
}
