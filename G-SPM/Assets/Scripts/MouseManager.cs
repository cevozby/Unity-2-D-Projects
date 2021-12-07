using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public static MouseManager current;
    public GameObject buildingInformationMenu, soldierInformationMenu;
    public GameObject warningText;
    public GameObject selectedObject;

    public bool barrackControl = false;

    public bool mouseIsNotOverUI;

    Soldier swordMan = new Swordman("Sword Man", "Infantry", 20, 30, 1, 5);
    Barrack barrack = new Barrack("Barrack", 4, 4, false);

    private void Start()
    {
        current = this;
        selectedObject = GameObject.Find("Main Camera");
    }

    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {

            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
            }
            else
            {
                selectedObject = GameObject.Find("Main Camera");
            }

        }

        if (selectedObject.tag == "Barrack")
        {
            buildingInformationMenu.SetActive(true);
            soldierInformationMenu.SetActive(false);
            barrackControl = true;
        }
        else if (selectedObject.tag == "MainCamera")
        {
            buildingInformationMenu.SetActive(false);
            soldierInformationMenu.SetActive(false);
        }
        else if (selectedObject.tag == "Soldier")
        {
            buildingInformationMenu.SetActive(false);
            soldierInformationMenu.SetActive(true);
            SoldierInformation();
        }
        else if (selectedObject.tag == "Power Plant")
        {
            buildingInformationMenu.SetActive(false);
            soldierInformationMenu.SetActive(false);
        }
    }

    void SoldierInformation()
    {
        GameObject.Find("SoldierUnitText").GetComponent<Text>().text = swordMan.name;
        GameObject.Find("SoldierInformation").GetComponent<Text>().text = "UNIT: " + swordMan.unit + "\nATK: " + swordMan.attack.ToString()
            + "\nDEF: " + swordMan.defans.ToString() + "\nRANGE: " + swordMan.range.ToString() + "\nSPEED: " + swordMan.speed.ToString();

    }

    void BuildingInformation()
    {
        GameObject.Find("BuildingUnitText").GetComponent<Text>().text = barrack.name;
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
