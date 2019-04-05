//======= Copyright (c) Immerxive Srl, All rights reserved. ===================
//
// Author: Alessandro Salani (Cippo)
//
// Purpose: 
//
// Notes:
//
//=============================================================================

using CippSharp.Interfaces;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CippSharp.Interfaces
{
	/// <summary>
	/// Generic attribute to make a property NotEditable in inspector.
	/// It doesn't work in inspector's debug view.
	/// </summary>
	public class NotEditableAttribute : PropertyAttribute
	{
        
	}
}

#if UNITY_EDITOR
namespace CippSharpEditor.Interfaces
{
	/// <summary>
	/// Custom drawer of NotEditableAttribute. 
	/// </summary>
	[CustomPropertyDrawer(typeof(NotEditableAttribute))]
	public class NotEditableDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label, property.isExpanded && property.hasChildren);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUIUtils.DrawNotEditableProperty(position, property, new GUIContent(property.displayName));
		}
	}
}
#endif
