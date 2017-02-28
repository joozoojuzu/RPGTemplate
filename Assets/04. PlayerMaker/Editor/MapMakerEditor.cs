using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapMakerEditor : EditorWindow {
    public class Map
    {
        public Transform transform;
    }

    public List<Map> maps = new List<Map>();

    [MenuItem("Game Editor/Make Map")]
    static public void ShowWindow()
    {
        EditorWindow window = (MapMakerEditor)GetWindow(typeof(MapMakerEditor));
        window.titleContent = new GUIContent("Map Setting");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            foreach (Map val in maps)
            {
                val.transform = (Transform)EditorGUILayout.ObjectField("Transform", val.transform, typeof(Transform), false);
                EditorGUILayout.Space();
            }
        }
        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Add Map"))
        {
            maps.Add(new Map());
        }

        if (GUILayout.Button("Create Map"))
        {

        }
    }
}
