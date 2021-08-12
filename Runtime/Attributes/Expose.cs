/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CippSharp.Core.Interfaces
{
    /// <summary>
    /// Purpose: after declaring a custom Interface Reference you can directly expose the target
    /// in inspector without have the 'foldout'.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExposeAttribute : PropertyAttribute
    {
		
    }
}

#if UNITY_EDITOR
namespace CippSharp.Core.Interfaces.Editor
{
    /// <summary>
    /// Custom drawer of ExposeAttribute.
    /// </summary>
    [CustomPropertyDrawer(typeof(ExposeAttribute))]
    public class ExposeAttributeDrawer : PropertyDrawer
    {
        private SerializedProperty ser_target = null;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, property.isExpanded && property.hasChildren);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ExposeAttribute exposeAttribute = attribute as ExposeAttribute;
			if (property.propertyType == SerializedPropertyType.Generic)
            {
                if (ser_target == null)
                {
                    ser_target = property.FindPropertyRelative("target");
                }

                if (ser_target != null)
                {
                    if (exposeAttribute != null)
                    {
                        EditorGUIUtils.DrawProperty(position, ser_target, label);
                    }
                    else
                    {
                        Debug.LogError("Failed to assign the attribute.");
                    }
                }
                else
                {
                    Debug.LogWarning("Expose Attribute supports only Interface Reference fields. (Or fields with a sub-"+typeof(SerializedProperty).Name+" with name <i>target</i>");
                }
            }
            else
            {
                Debug.LogWarning("Serialized Property is not of Generic type.");
            }
        }
    }
}
#endif
