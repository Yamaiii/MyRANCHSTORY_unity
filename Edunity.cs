using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Edunity : Editor {
    [MenuItem("log/打开更新")]
    public static void OpenFilePath()
    {
        string path = Application.persistentDataPath;
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        EditorUtility.RevealInFinder(path);
    }
}
