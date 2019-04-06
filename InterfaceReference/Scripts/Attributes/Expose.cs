/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using CippSharp.Interfaces;
using UnityEditor;
using UnityEngine;

namespace CippSharp.Interfaces
{
     public class ExposeAttribute : PropertyAttribute
     {
		
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

