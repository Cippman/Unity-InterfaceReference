/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using CippSharp.Interfaces;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CippSharp.Interfaces
{
     public class ExposeAttribute : Attribute
     {
            ExposedReference<>
     }
}


#if UNITY_EDITOR
namespace CippSharpEditor.Interfaces
{
    /// <summary>
    /// Custom drawer of TypeFilterAttribute. 
    /// </summary>
    [CustomPropertyDrawer(typeof(ExposeAttribute))]
    public class ExposeAttributeDrawer : PropertyDrawer
    {
        private object target = null;
        private readonly Object nullObject = null;
        private Object TargetObject
        {
            get { return target != null ? (Object)target : nullObject; }
            set { target = value; }
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, property.isExpanded && property.hasChildren);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ExposeAttribute exposeAttribute = attribute as ExposeAttribute;
            Type fieldType = fieldInfo.FieldType;
            if (property.propertyType == SerializedPropertyType.Generic && fieldType.IsInterface)
            {
                if (exposeAttribute != null)
                {
                    target = fieldInfo.GetValue(property.serializedObject.targetObject);
                    if (target == null)
                    {    
                        TargetObject = EditorGUI.ObjectField(position, TargetObject, typeof(Object), true);
                        fieldInfo.SetValue(property.serializedObject.targetObject, TargetObject);
                    }
                    else if (target is Object)
                    {
                        TargetObject = EditorGUI.ObjectField(position, TargetObject, typeof(Object), true);
                        fieldInfo.SetValue(property.serializedObject.targetObject, TargetObject);
                    }
                    else
                    {
                        //Not implemented for interfaces that aren't also of type Object.
                    }
                }
                else
                {
                    Debug.LogError("Failed to assign the attribute.");
                }
            }
            else
            {
                Debug.LogWarning("Expose Attribute supports only Interface Reference fields.");
            }
        }
    }
}
#endif

