using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPoint))]
public class SpawnPointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SpawnPoint mySpawn = (SpawnPoint)target;
        EditorGUILayout.LabelField("Player Name", mySpawn.playerPrefab.name);
    }
}
