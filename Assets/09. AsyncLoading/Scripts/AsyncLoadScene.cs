using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class AsyncLoadScene : MonoBehaviour {
    public Slider slider;
    public RawImage[] images;
    private int index;
    private string[] fileNames;

    void Awake()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        DirectoryInfo directoryInfo = new DirectoryInfo("Assets/Resources/Scenes/");
        FileInfo[] fileInfo = directoryInfo.GetFiles("*.unity");
        int fileCount = fileInfo.Length;
        fileNames = new string[fileCount];
        for(int i = 0; i < fileCount; i++)
        {
            fileNames[i] = fileInfo[i].Name.Replace(fileInfo[i].Extension, "");
        }
    }

    void Start ()
    {
	}
	
	void Update ()
    {
		
	}

    public void LoadingScreen()
    {
        index = Random.Range(0, images.Length);
        images[index].gameObject.SetActive(true);

        StartCoroutine(CoLoadingScreen());
    }

    IEnumerator CoLoadingScreen()
    {
        Debug.Log(fileNames[index]);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(fileNames[index]);

        if (asyncOperation == null)
        {
            Debug.LogError("Error> AsyncOperation is null");
        }

        asyncOperation.allowSceneActivation = false;

        while(true)
        {
            slider.value = asyncOperation.progress + 0.1f;
            if (!asyncOperation.isDone)
            {
                asyncOperation.allowSceneActivation = true;
                break;
            }
            yield return null;
        }
    }
}
