using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public MouseOrbit mouseOrbit;

    public ViewScriptableObject[] viewData;
    public GameObject[] viewTexts;




    void Start()
    {
        ChangeView("View1");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100))
            {
                ChangeView(hit.collider.tag);
                Debug.Log(hit.collider.tag);
            }
        }
    }


    void ChangeView(string _tag)
    {
        int _index = -1;
        for (int i = 0; i < viewData.Length; i++)
        {
            if (_tag == viewData[i].viewName) _index = i;
        }
        if (_index < 0) return;

        mouseOrbit.target = GameObject.Find(viewData[_index].viewName).transform;
        mouseOrbit.newRotation = Quaternion.Euler(viewData[_index].rotation);
        mouseOrbit.newDistance = viewData[_index].distance;

        UpdateText(_index);
    }


    void UpdateText(int _index)
    {
        for (int i = 0; i < viewTexts.Length; i++)
        {
            viewTexts[i].SetActive(false);
        }

        viewTexts[_index].SetActive(true);
    }
}
