using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PortalManager))]
public class PortalManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PortalManager myPortalManager = (PortalManager)target;
        EditorGUILayout.LabelField("Name", myPortalManager.name);
    }
}
