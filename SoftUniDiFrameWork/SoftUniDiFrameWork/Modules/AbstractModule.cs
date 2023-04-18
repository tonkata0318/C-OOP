using SoftUniDiFrameWork.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDiFrameWork.Modules
{
    public abstract class AbstractModule:IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;
        public AbstractModule()
        {
            implementations=new Dictionary<Type, Dictionary<string, Type>>();
            instances=new Dictionary<Type, object>();
        }
        public abstract void Configure();
        protected void CreateMapping<TInter,TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
            {
                implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }
            implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
        public Type GetMapping(Type currentInterface,object attribute)
        {
            var currentImplemention = this.implementations[currentInterface];
            Type type= null;
            if (attribute is Inject)
            {
                if (currentImplemention.Count==1)
                {
                    type = currentImplemention.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: " + currentInterface.Name);
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;
                string dependencyName = named.Name;
                type = currentImplemention[dependencyName];
            }
            return type;
        }
        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }
        public object GetInstance(Type implementation)
        {
            instances.TryGetValue(implementation, out object value);
            return value;
        }
    }
}
