using SoftUniDiFrameWork.Attributes;
using SoftUniDiFrameWork.Modules;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDiFrameWork.Injectors
{
    public class Injector
    {
        private IModule module;
        public Injector(IModule module)
        {
            this.module = module;
        }
        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62).Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private bool CheckForContructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }
        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            if (desireClass==null)
            {
                return default(TClass);
            }
            var constructors=desireClass.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (!CheckForContructorInjection<TClass>())
                {
                    continue;
                }
                var inject=(Inject)constructor.GetCustomAttributes(typeof(Injector),true).FirstOrDefault();
                var parameterTypes=constructor.GetParameters();
                var constructorParams=new object[parameterTypes.Length];
                var i = 0;
                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttribute(typeof(Named));
                    Type dependency = null;
                    if (named==null)
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = module.GetMapping(parameterType.ParameterType, named);
                    }
                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance!=null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance=Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }
            return default(TClass);
        }
        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass=typeof(TClass);
            var desireClassInstance=module.GetInstance(desireClass);
            if (desireClassInstance==null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                module.SetInstance(desireClass, desireClassInstance);
            }
            var fields = desireClass.GetFields((BindingFlags)62);
            foreach ( var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject),true).Any())
                {
                    var injection=(Inject)field
                        .GetCustomAttributes(typeof(Inject),true)
                        .FirstOrDefault();
                    Type dependency = null;
                    var named=field.GetCustomAttribute(typeof(Named),true);
                    var type = field.FieldType;
                    if (named==null)
                    {
                        dependency = module.GetMapping(type, injection);
                    }
                    else 
                    {
                        dependency=module.GetMapping(type, named);
                    }
                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance==null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }
            return (TClass)desireClassInstance;
        }
        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckForContructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();
            if (hasConstructorAttribute&&hasFieldAttribute)
            {
                throw new ArgumentException("There must be ony field or constructor annotated with Inject attribute");
            }
            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }
            return default(TClass);
        }
    }
}
