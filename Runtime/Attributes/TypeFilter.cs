/*
 *  Author: Alessandro Salani (Cippman)
 */

using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using CippSharp.Interfaces;
using UnityEditor;
#endif

namespace CippSharp.Interfaces
{
    /// <summary>
    /// Generic attribute to make a property of Object type to filter types.
    /// </summary>
    public class TypeFilterAttribute : PropertyAttribute
    {
        public Type[] types;

        public TypeFilterAttribute(Type[] types)
        {
            this.types = types;
        }
    }
}

#if UNITY_EDITOR
namespace CippSharpEditor.Interfaces
{
    /// <summary>
    /// Custom drawer of TypeFilterAttribute. 
    /// </summary>
    [CustomPropertyDrawer(typeof(TypeFilterAttribute))]
    public class TypeFilterAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, property.isExpanded && property.hasChildren);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TypeFilterAttribute typeFilterAttribute = attribute as TypeFilterAttribute;
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUIUtils.DrawProperty(position, property, label);
                
                if (typeFilterAttribute != null)
                {
                    Type[] requiredTypes = typeFilterAttribute.types;
                    
                    #region Preliminary Check

                    PreliminaryCheck(property, requiredTypes);
                    
                    #endregion
                    
                    #region Default Check

                    DefaultCheck(property, requiredTypes);

                    #endregion
                }
                else
                {
                    Debug.LogError("Failed to assign the attribute.");
                }
            }
            else
            {
                Debug.LogWarning("Type Filter Attribute supports only Object Reference fields.");
            }
        }
        
        #region Preliminary Check

        /// <summary>
        /// For a comfy Drag n drop of a GameObject.
        /// It takes the first component that match with one of the required types.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="requiredTypes"></param>
        private void PreliminaryCheck(SerializedProperty property, Type[] requiredTypes)
        {
            Object target = property.objectReferenceValue;
            if (target == null)
            {
                return;
            }
            
            if (target is GameObject)
            {
                GameObject gameObject = (GameObject) target;
                Component comp = null;

                if (!IsNullOrEmpty(requiredTypes))
                {
                    foreach (var requiredType in requiredTypes)
                    {
                        if (requiredType == null)
                        {
                            continue;
                        }
                        
                        comp = gameObject.GetComponent(requiredType);
                        if (comp != null)
                        {
                            break;
                        }
                    }
                }

                if (comp != null)
                {
                    property.objectReferenceValue = comp;
                }
                else
                {
                    Debug.LogWarning("You must assign a GameObject that has at least one component of the required types that you have specified.");
                }
            }
        }
        
        #endregion

        #region Default Check
        
        /// <summary>
        /// Check if property object reference match with one of the required types otherwise set it to null.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="requiredTypes"></param>
        private void DefaultCheck(SerializedProperty property, Type[] requiredTypes)
        {
            Object target = property.objectReferenceValue;
            if (target == null)
            {
                return;
            }
            
            if (!IsNullOrEmpty(requiredTypes))
            {
                Type objectType = target.GetType();
                bool check = requiredTypes.Where(requiredType => requiredType != null).Any(requiredType => requiredType.IsAssignableFrom(objectType));

                if (!check)
                {
                    property.objectReferenceValue = null;
                }
            }            
        }
        
        #endregion

        /// <summary>
        /// Retrieve if an array is null or empty.
        /// This method is also usually used as extension method for check arrays without re-writing the same condition many times.
        /// Here is just a static method 'cause I need it only here for now.
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static bool IsNullOrEmpty<T>(T[] array)
        {
            return array == null || array.Length < 1;
        }
    }
}
#endif
