using UnityEngine;
#if UNITY_EDITOR
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
#endif

/*
 * This Attribute facilitates SortingLayer assignation in the Inspector.
 * When used with a string, any item from the unity SortingLayer list can be chosen in a drop down menu.
 * 
 * HOW TO USE : 
 * [SortingLayer]
 * public string m_Layer;
 */

#if UNITY_EDITOR
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
#endif
public class SortingLayerAttribute : PropertyAttribute
{
	public SortingLayerAttribute()
	{
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SortingLayerAttribute))]
public class SortingLayerAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// We must use reflection because static sortingLayerNames of InternalEditorUtility is private
		System.Type internalEditorUtilityType = typeof(InternalEditorUtility);
		PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
		List<string> layers = new List<string>((string[])sortingLayersProperty.GetValue(null, new object[0]));
		int n = EditorGUI.Popup(position, label.text, layers.IndexOf(property.stringValue), layers.ToArray());
		if (n != -1)
		{
			property.stringValue = layers[n];
		}
	}
}
#endif