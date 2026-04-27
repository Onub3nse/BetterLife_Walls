// COIExtended.StoragePlus, Version=0.7.7.470, Culture=neutral, PublicKeyToken=null
// COIExtended.StoragePlus.Extensions.ReflectionExtensions
using System;
using System.Reflection;


internal static class ReflectionExtensions
{
    public static void UniversalSetPrivateProperty<T>(object obj, string propertyName, T value)
    {
        Type type = obj.GetType();
        Type type2 = type;
        while (type2 != null)
        {
            PropertyInfo property = type2.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, value);
                return;
            }
            FieldInfo field = type2.GetField(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field == null)
            {
                string name = "<" + propertyName + ">k__BackingField";
                field = type2.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            }
            if (field != null)
            {
                field.SetValue(obj, value);
                return;
            }
            type2 = type2.BaseType;
        }
        throw new InvalidOperationException("Property or field '" + propertyName + "' not found on " + type.Name + " or its base types.");
    }

    public static void UniversalSetPrivatePropertyOld<T>(object obj, string propertyName, T value)
    {
        Type type = obj.GetType();
        PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (property != null && property.CanWrite)
        {
            property.SetValue(obj, value);
            return;
        }
        FieldInfo field = type.GetField(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field == null)
        {
            string name = "<" + propertyName + ">k__BackingField";
            field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
        if (field != null)
        {
            field.SetValue(obj, value);
            return;
        }
        Type type2 = typeof(T).BaseType ?? throw new InvalidOperationException("Property, field, or backing field '" + propertyName + "' not found on " + type.Name + ".");
        FieldInfo fieldInfo = type2.GetField("<Strings>k__BackingField", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ?? throw new InvalidOperationException("Property, field, or backing field '" + propertyName + "' not found on " + type.Name + ".");
        fieldInfo.SetValue(obj, value);
    }

    public static void UniversalSetPrivateStaticProperty<T>(object obj, string fieldName, T value)
    {
        Type type = obj.GetType();
        FieldInfo field = type.GetField(fieldName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (field == null)
        {
            string name = "<" + fieldName + ">k__BackingField";
            field = type.GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
        if (field != null)
        {
            field.SetValue(null, value);
            return;
        }
        throw new InvalidOperationException("Static field or backing field '" + fieldName + "' not found on " + type.Name + ".");
    }

    public static T UniversalGetPrivateProperty<T>(object obj, string propertyName)
    {
        Type type = obj.GetType();
        PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (property != null && property.CanRead)
        {
            return (T)property.GetValue(obj);
        }
        FieldInfo field = type.GetField(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field == null)
        {
            string name = "<" + propertyName + ">k__BackingField";
            field = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
        }
        if (field != null)
        {
            return (T)field.GetValue(obj);
        }
        Type type2 = typeof(T).BaseType ?? throw new InvalidOperationException("Property, field, or backing field '" + propertyName + "' not found on " + type.Name + ".");
        FieldInfo field2 = type2.GetField("<Strings>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
        if (field2 != null)
        {
            return (T)field2.GetValue(obj);
        }
        throw new InvalidOperationException("Property, field, or backing field '" + propertyName + "' not found on " + type.Name + ".");
    }

    public static T GetPrivateProperty<T>(this object obj, string propertyName)
    {
        return ReflectionExtensions.UniversalGetPrivateProperty<T>(obj, propertyName);
    }

    public static void SetPrivateProperty<T>(this object obj, string propertyName, T value)
    {
        ReflectionExtensions.UniversalSetPrivateProperty(obj, propertyName, value);
    }

    public static object Call(this object o, string methodName, params object[] args)
    {
        return o.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(o, args);
    }

    public static T GetPrivateStaticMember<T>(Type type, string name)
    {
        PropertyInfo property = type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (property != null && property.CanRead)
        {
            return (T)property.GetValue(null);
        }
        FieldInfo field = type.GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (field != null)
        {
            return (T)field.GetValue(null);
        }
        string name2 = "<" + name + ">k__BackingField";
        field = type.GetField(name2, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (field != null)
        {
            return (T)field.GetValue(null);
        }
        throw new InvalidOperationException("Static property, field, or backing field '" + name + "' not found on " + type.Name + ".");
    }

    public static void SetPrivateStaticMember<T>(Type type, string name, T value)
    {
        FieldInfo field = type.GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (field == null)
        {
            string name2 = "<" + name + ">k__BackingField";
            field = type.GetField(name2, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
        if (field != null)
        {
            field.SetValue(null, value);
            return;
        }
        throw new InvalidOperationException("Static field or backing field '" + name + "' not found on " + type.Name + ".");
    }

    public static void UniversalSetPrivateProperty_ExplicitlyBySetter<T>(object obj, string propertyName, T value)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        Type type = obj.GetType();
        Type type2 = type;
        while (type2 != null)
        {
            PropertyInfo property = type2.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, value);
                return;
            }
            type2 = type2.BaseType;
        }
        throw new InvalidOperationException("Property '" + propertyName + "' with a writable setter not found on " + type.Name + " or its base types.");
    }

    public static T UniversalGetPrivatePropertyDeep<T>(object obj, string propertyName)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        if (string.IsNullOrEmpty(propertyName))
        {
            throw new ArgumentNullException("propertyName");
        }
        Type type = obj.GetType();
        PropertyInfo propertyInfo = null;
        Type type2 = type;
        while (type2 != null && propertyInfo == null)
        {
            propertyInfo = type2.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            type2 = type2.BaseType;
        }
        if (propertyInfo != null && propertyInfo.CanRead)
        {
            return (T)propertyInfo.GetValue(obj);
        }
        FieldInfo fieldInfo = null;
        type2 = type;
        while (type2 != null && fieldInfo == null)
        {
            fieldInfo = type2.GetField(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            type2 = type2.BaseType;
        }
        if (fieldInfo == null)
        {
            string name = "<" + propertyName + ">k__BackingField";
            type2 = type;
            while (type2 != null && fieldInfo == null)
            {
                fieldInfo = type2.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
                type2 = type2.BaseType;
            }
        }
        if (fieldInfo != null)
        {
            return (T)fieldInfo.GetValue(obj);
        }
        throw new InvalidOperationException("Property, field, or backing field '" + propertyName + "' not found on " + type.Name + " or its base types.");
    }
}
