using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public List<GameObject> donDesObjs;

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Contains("Player"))
        {
            foreach (var item in donDesObjs)
            {
                DontDestroyOnLoad(item);
            }
            SceneManager.LoadScene("SawMill");
        }
    }
}
