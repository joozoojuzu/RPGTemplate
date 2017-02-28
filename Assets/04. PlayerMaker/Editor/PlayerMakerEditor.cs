using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMakerEditor : EditorWindow {
    string UserName;
    Server.Name ServerKind;
    Camp.Name CampKind;
    Races.Name RacesKind;
    Sex.Name SexKind;
    Classes.Name ClassesKind;

    public Dictionary<Transform, MonoBehaviour> PartsOfPlayer = new Dictionary<Transform, MonoBehaviour>();
    GameObject g;
    MonoBehaviour m;

    [MenuItem("Game Editor/Make Player")]
    static public void ShowWindow()
    {
        EditorWindow window = (PlayerMakerEditor)GetWindow(typeof(PlayerMakerEditor));
        window.titleContent = new GUIContent("Player Setting");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.BeginVertical();
                {
                    UserName = EditorGUILayout.TextField("Name", UserName);
                    ServerKind = (Server.Name)EditorGUILayout.EnumPopup("Server", ServerKind);
                    CampKind = (Camp.Name)EditorGUILayout.EnumPopup("Camp", CampKind);
                    RacesKind = (Races.Name)EditorGUILayout.EnumPopup("Races", RacesKind);
                    SexKind = (Sex.Name)EditorGUILayout.EnumPopup("Sex", SexKind);
                    ClassesKind = (Classes.Name)EditorGUILayout.EnumPopup("Classes", ClassesKind);
                    EditorGUILayout.EndVertical();

                    if (GUILayout.Button("Clear"))
                    {
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            g = (GameObject)EditorGUILayout.ObjectField("GameObject", g, typeof(GameObject), false);
            m = (MonoBehaviour)EditorGUILayout.ObjectField("MonoBehaviour", m, typeof(MonoBehaviour), false);
            if (GUILayout.Button("Add Part of Player"))
            {
                /*
                foreach(KeyValuePair<> val in PartsOfPlayer)
                {

                }
                */
            }

            if (GUILayout.Button("Make Player"))
            {
                GameObject playerObject = GameObject.Find("Player");
                if (playerObject)
                {
                    DestroyImmediate(playerObject);
                    playerObject = null;
                }

                GameObject cameraObject = GameObject.FindWithTag("MainCamera");
                if (cameraObject)
                {
                    Destroy(cameraObject);
                    cameraObject = null;
                }

                playerObject = PrefabLoader.LoadPrefab(PrefabLoader.cCharacter, "Player", new Vector3(0, 0.5f, 0));
            }
        }
        EditorGUILayout.EndVertical();
    }
}
