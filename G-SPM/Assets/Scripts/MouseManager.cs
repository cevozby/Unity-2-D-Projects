using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    public static MouseManager current;
    public GameObject informationMenu;
    public GameObject warningText;
    public GameObject selectedObject;

    public bool barrackPanel = false;

    public bool mouseIsNotOverUI;

    private void Start()
    {
        current = this;
    }

    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            Debug.Log("Mouse is down");

            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                Debug.Log("Target Object is true");
                selectedObject = targetObject.transform.gameObject;
            }
            else
            {
                selectedObject = null;
                Debug.Log("Target Object is false");
            }

        }

        if (selectedObject.tag == "Barrack")
        {
            informationMenu.SetActive(true);
            barrackPanel = true;
        }
        else if (selectedObject == null)
        {
            informationMenu.SetActive(false);
        }
        else if (selectedObject.tag == "Soldier")
        {
            informationMenu.SetActive(false);
        }
        else if (selectedObject.tag == "Power Plant")
        {
            informationMenu.SetActive(false);
        }
    }

}
