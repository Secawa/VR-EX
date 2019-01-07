using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.Examples
{
    public class activateallotherscripts : MonoBehaviour
    {
        public GameObject[] activateObjects;
        // Use this for initialization
        void Start()
        {

            activateObjects[0] = GameObject.Find("TheScripts");
            activateObjects[1] = GameObject.Find("Waypoints/Locations");
            activateObjects[2] = GameObject.Find("Cameraeyes");
            activateObjects[0].transform.GetChild(0).gameObject.SetActive(true);
            activateObjects[1].SetActive(true);
            activateObjects[2].transform.GetChild(0).gameObject.SetActive(true);
            activateObjects[2].transform.GetChild(1).gameObject.SetActive(true);
            activateObjects[0].transform.GetChild(0).gameObject.GetComponent<ObjectInWorld>().OnStart();
                activateObjects[0].transform.GetChild(0).gameObject.GetComponent<ClickLeftMenu>().OnStart();
            activateObjects[2].transform.GetChild(0).gameObject.GetComponent<LocationScout>().OnStart();
            activateObjects[1].GetComponent<Waypointers>().OnStart();
            GameObject.Find("MenuSelection").GetComponent<OperatorMenuSelect>().OnStart();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
