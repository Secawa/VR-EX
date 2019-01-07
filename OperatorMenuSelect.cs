using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.Examples
{
    public class OperatorMenuSelect : MonoBehaviour
    {
        public GameObject[] deactiveObjects;
        public GameObject Scripts;
        public GameObject LoadingSphere;
        private KeyCode[] keyCodes = {
             KeyCode.Alpha0,
             KeyCode.Alpha1,
             KeyCode.Alpha2,
             KeyCode.Alpha3,
             KeyCode.Alpha4,
             KeyCode.Alpha5,
             KeyCode.Alpha6,
             KeyCode.Alpha7,
             KeyCode.Alpha8,
             KeyCode.Alpha9,
             KeyCode.Q,
             KeyCode.W,
             KeyCode.E,
             KeyCode.R,
             KeyCode.T,
             KeyCode.Y,
             KeyCode.U,
             KeyCode.I,
             KeyCode.O,
             KeyCode.P,
         };




        // WUCC check for errors. 

        // Use this for initialization
        void Start()
        {
            Scripts = GameObject.Find("TheScripts").transform.GetChild(0).gameObject;
            LoadingSphere = GameObject.Find("LoadingSphere").transform.GetChild(0).gameObject;
            deactiveObjects[0] = GameObject.Find("Map");
            deactiveObjects[1] = GameObject.Find("Waypoints");
            deactiveObjects[2] = GameObject.Find("TheScripts");
            deactiveObjects[3] = GameObject.Find("Cameraeyes");
        }

        // Update is called once per frame
        void Update()
        {

            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    int numberPressed = i;
                    Debug.Log(numberPressed);
                    LoadingSphere.SetActive(true);
                    Scripts.GetComponent<ObjectInWorld>().changescenebool = true;
                    Scripts.GetComponent<ObjectInWorld>().thename = Scripts.GetComponent<ObjectInWorld>().Buildings[numberPressed].name;
                    LoadingSphere.GetComponent<loadingbars>().thename = Scripts.GetComponent<ObjectInWorld>().Buildings[numberPressed].name;
                    {
                        print("up arrow key is held down");
                        for (int m = 0; m < deactiveObjects.Length; m++)
                        {
                            deactiveObjects[m].transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        public void OnStart()
        {
            Debug.Log("runned");
            deactiveObjects[0] = GameObject.Find("Map");
            deactiveObjects[1] = GameObject.Find("Waypoints");
        }
    }
}
