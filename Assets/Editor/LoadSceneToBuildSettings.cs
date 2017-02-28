using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadSceneToBuildSettings : MonoBehaviour {
    void Awake()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("Assets/Resources/Scenes/");
        FileInfo[] fileInfo = directoryInfo.GetFiles("*.unity");
        int fileCount = fileInfo.Length;
        string[] fileNames = new string[fileCount];
        for(int i = 0; i < fileCount; i++)
        {
            fileNames[i] = fileInfo[i].Name.Replace(fileInfo[i].Extension, "");
        }

        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        EditorBuildSettingsScene[] newScenes = new EditorBuildSettingsScene[fileCount];
        for(int i = 0; i < fileCount; i++)
        {
            int start = fileInfo[i].FullName.IndexOf("Assets");
            int end = fileInfo[i].FullName.Length;
            string fileName = fileInfo[i].FullName.Substring(start, end - start);
            newScenes[i] = new EditorBuildSettingsScene(fileName, true);
        }

        EditorBuildSettings.scenes = newScenes;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
