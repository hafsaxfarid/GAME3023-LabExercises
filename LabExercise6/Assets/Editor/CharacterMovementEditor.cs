using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharacterMovement))]
public class CharacterMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CharacterMovement myCharacterMovement = (CharacterMovement)target;
        //myCharacterMovement.moveSpeed = EditorGUILayout.FloatField("Player Speed", myCharacterMovement.moveSpeed);

        myCharacterMovement.moveSpeed = EditorGUILayout.Slider("Player Speed", myCharacterMovement.moveSpeed, 1f, 10f);

    }
}
