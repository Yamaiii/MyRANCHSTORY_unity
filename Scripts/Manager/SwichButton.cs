using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichButton : MonoBehaviour
{
    public CanvasDisplay canvasDisplay;
    public Image tagImage;
    public int sub;
    private void Start() {
        GetComponent<Button>().onClick.AddListener(()=>
        {
            canvasDisplay._tag=sub;
        });
    }

    private void Update() {
        if (canvasDisplay._tag!=sub)
        {
            tagImage.gameObject.SetActive(false);
        }
        else
        {
            tagImage.gameObject.SetActive(true);
        }
    }
}
