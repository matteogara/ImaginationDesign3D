using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public ViewScriptableObject view1;
    public ViewScriptableObject view2;
    public MouseOrbit mouseOrbit;

    bool one = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (one) {
                mouseOrbit.target = GameObject.Find(view2.targetName).transform;
                mouseOrbit.newRotation = Quaternion.Euler(view2.rotation);
                mouseOrbit.newDistance = view2.distance;
                one = false;
            } else {
                mouseOrbit.target = GameObject.Find(view1.targetName).transform;
                mouseOrbit.newRotation = Quaternion.Euler(view1.rotation);
                mouseOrbit.newDistance = view1.distance;
                one = true;
            }
        }
    }
}
