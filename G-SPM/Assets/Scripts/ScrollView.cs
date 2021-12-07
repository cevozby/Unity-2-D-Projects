using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    public List<GameObject> emptyObjects = new List<GameObject>();
    GameObject nonSelected;
    public GameObject powerPlant;

    void Start()
    {
        
    }

    void Update()
    {
        if(emptyObjects[0].transform.position.y > 1010)
        {
            nonSelected = emptyObjects[0];
            nonSelected.transform.position = new Vector3(nonSelected.transform.position.x, emptyObjects[emptyObjects.Count - 1].transform.position.y - 80, nonSelected.transform.position.z);
            emptyObjects.Remove(emptyObjects[0]);
            emptyObjects.Add(nonSelected);

        }
        else if(emptyObjects[0].transform.position.y < 1000 && powerPlant.transform.position.y > 1050)
        {
            nonSelected = emptyObjects[emptyObjects.Count - 1];
            nonSelected.transform.position = new Vector3(nonSelected.transform.position.x, emptyObjects[0].transform.position.y + 80, nonSelected.transform.position.z);
            emptyObjects.Remove(emptyObjects[emptyObjects.Count - 1]);
            emptyObjects.Insert(0, nonSelected);
        }
    }
}
