using System;
using System.Collections.Generic;
using System.Reflection;

public class HelpAttribute : Attribute
{
    // Defina o seu atributo personalizado aqui
}

public static class ClassAttributeHelper
{
    public static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0)
            {
                yield return type;
            }
        }
    }
}