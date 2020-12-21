using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Info : MonoBehaviour
{
    public Transform target;
    public int lineLength = 300;

    [Header("Info")]
    public string name;

    Text text;
    UILineRenderer line;
    Camera cam;




    void Start()
    {
        text = GetComponentInChildren<Text>();
        line = GetComponentInChildren<UILineRenderer>();
        cam = Camera.main;

        line.m_points = new Vector2[3];
        text.text = name;
    }


    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(target.position);

        int marginX = Screen.width / 2 - 200;
        int marginY = Screen.height / 2 - 100;
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);

        line.m_points[0] = screenPos - center;
        line.m_points[1] = Vec2Clamp(line.m_points[0] + line.m_points[0].normalized * lineLength, -marginX, marginX, -marginY, marginY);
        line.m_points[2] = line.m_points[1] + new Vector2(line.m_points[0].x > 0 ? 100 : -100, 0);
        line.SetAllDirty();

        text.rectTransform.position = line.m_points[2] + new Vector2(line.m_points[0].x > 0 ? text.preferredWidth / 2 + 10 : -text.preferredWidth / 2 - 10, 0) + center;
    }


    float Map(float from, float from2, float to, float to2, float value)
    {
        if (value <= from2)
        {
            return from;
        }
        else if (value >= to2)
        {
            return to;
        }
        else
        {
            return (to - from) * ((value - from2) / (to2 - from2)) + from;
        }
    }


    Vector2 Vec2Clamp(Vector2 _in, int _xMin, int _xMax, int _yMin, int _yMax)
    {
        int _x = (int) Mathf.Clamp(_in.x, _xMin, _xMax);
        int _y = (int) Mathf.Clamp(_in.y, _yMin, _yMax);

        return new Vector2(_x, _y);
    }
}
