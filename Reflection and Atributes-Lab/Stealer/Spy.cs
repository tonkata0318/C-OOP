using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType=Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            StringBuilder stringBuilder= new StringBuilder();
            Object classInstance=Activator.CreateInstance(classType,new object[] { });
            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");
            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return stringBuilder.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods=classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods=classType.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);
            StringBuilder stringBuilder= new StringBuilder();
            foreach (var field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }
            return stringBuilder.ToString().Trim();
        }
        public string RevealPrivateMethods(string investigatedClass)
        {
            StringBuilder sb=new StringBuilder();
            Type classType = Type.GetType(investigatedClass);
            
            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: Object");
            MethodInfo[] fields = classType.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name}");
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string investigatedClass)
        {
            StringBuilder sb=new StringBuilder();
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in classMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnParameter}");
            }
            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field on {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
