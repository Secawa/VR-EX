
using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity.Examples
{
    public class NewWorld : InteractionReceiver
    {
        // Copyright (c) Microsoft Corporation. All rights reserved.
        // Licensed under the MIT License. See LICENSE in the project root for license information.


       // public GameObject textObjectState;
        public GameObject[] deactiveObjects;
        public GameObject[] activateObjects;
        public bool once = false;
        private string txt = "Traveling back To the Map";
        public Vector3 Thecamerazero;
       // public string thename;
        int num;
        private void Awake()
        {
            deactiveObjects[0] = GameObject.Find("MixedRealityCameraParent");
            deactiveObjects[1] = GameObject.Find("InputManager");
            activateObjects[0] = GameObject.Find("LoadingSphere");
            activateObjects[1] = GameObject.Find("TheScripts");
            activateObjects[1].transform.GetChild(0).gameObject.SetActive(false);
            activateObjects[2] = GameObject.Find("Cameraeyes");
            deactiveObjects[0].transform.position = Thecamerazero;
            activateObjects[2].transform.GetChild(1).gameObject.SetActive(false);
        }
        /*void Update()
        {
            if (deactiveObjects[0] != null) {
                    activateObjects[1].transform.position = deactiveObjects[0].transform.GetChild(0).gameObject.transform.position;
                    activateObjects[1].transform.rotation = deactiveObjects[0].transform.GetChild(0).gameObject.transform.rotation;
                }
            }*/

        protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
        {
            Debug.Log(Targets);
            Debug.Log(obj.name + " : FocusEnter");
            if ((Behaviour)obj.GetComponent("Halo") == true)
            {
                Behaviour halo = (Behaviour)obj.GetComponent("Halo");
                halo.enabled = true;
            }
        }

        protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData)
        {
            Debug.Log(obj.name + " : FocusExit");
            if ((Behaviour)obj.GetComponent("Halo") == true)
            {
                Behaviour halo = (Behaviour)obj.GetComponent("Halo");
                halo.enabled = false;
            }
        }

        protected override void InputDown(GameObject obj, InputEventData eventData)
        {
            activateObjects[0].transform.GetChild(0).gameObject.SetActive(true);
            // activateObjects[1].transform.GetChild(0).gameObject.SetActive(true);
            if (once == false)
            {
                activateObjects[0].transform.GetChild(0).gameObject.GetComponent<loadingbars>().startLoadingthebars = true;
                activateObjects[0].transform.GetChild(0).gameObject.GetComponent<loadingbars>().thename = "Withlocations";
                //  SceneManager.LoadSceneAsync("TheMap");
                activateObjects[2].transform.GetChild(1).gameObject.SetActive(true);
                activateObjects[1].transform.GetChild(0).gameObject.GetComponent<ObjectInWorld>().EnterWorld.text = txt;
                once = true;
            }
        }

        protected override void InputUp(GameObject obj, InputEventData eventData)
        {
        }
    }
}
