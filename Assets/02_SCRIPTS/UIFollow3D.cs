using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollow3D : MonoBehaviour
{
    public Transform target;

    Camera cam;
    Text text;



    void Start()
    {
        cam = Camera.main;
        text = GetComponent<Text>();
    }


    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        text.rectTransform.position = screenPos;
    }
}
