using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ViewScriptableObject", order = 1)]
public class ViewScriptableObject : ScriptableObject
{
    public string viewName;
    public Vector3 rotation;
    public float distance;
}