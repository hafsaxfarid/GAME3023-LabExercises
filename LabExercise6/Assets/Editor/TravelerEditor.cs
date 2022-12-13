using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Traveler))]
public class TravelerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Traveler myTraveler = (Traveler)target;
        EditorGUILayout.LabelField("Portal Exit", myTraveler.LastPortalExitSpawnName);
    }
}
