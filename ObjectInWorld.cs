
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
using System.Collections;
using UnityEngine.XR.WSA.Input;

namespace HoloToolkit.Unity.Examples
{
    public class ObjectInWorld : InteractionReceiver
    {
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.


     //   public GameObject textObjectState;
        public GameObject[] deactiveObjects;
        public Texture2D theblackness;
        public GameObject[] activateObjects;
        public bool onlyonce = true;
        public GameObject[] Buildings;
        public GameObject TheCamera;
        public bool changescenebool = false;
        // public GameObject objectsparentclass;
        private TextMesh txt;
        public string thename;
        public Text EnterWorld;
        int num;
        private Dictionary<uint, ControllerState> controllers;
        void Awake()
        {
           
            TheCamera = GameObject.Find("MixedRealityCameraParent");
            activateObjects[0] = GameObject.Find("LoadingSphere");
            deactiveObjects[0] = GameObject.Find("Map");
            deactiveObjects[1] = GameObject.Find("Waypoints");
            deactiveObjects[2] = GameObject.Find("TheScripts");
            deactiveObjects[3] = GameObject.Find("Cameraeyes");
            controllers = new Dictionary<uint, ControllerState>();
            InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

            InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
            InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;

            DontDestroyOnLoad(this.gameObject);

            for (int j = 0; j < deactiveObjects[2].GetComponent<FindThebuildingsagain>().namesoflocations.Length; j++)
            {
                interactables[j] = GameObject.Find("3D Buildings").transform.GetChild(j).gameObject;
                Targets[j] = GameObject.Find("3D Buildings").transform.GetChild(j).gameObject;
                //    activateObjects[i] = objectsparentclass.transform.GetChild(i).gameObject;
                //      txt = textObjectState.GetComponentInChildren<TextMesh>();
                Buildings[j] = interactables[j];
                deactiveObjects[2].GetComponent<FindThebuildingsagain>().namesoflocations[j] = Buildings[j].name;
            }

        }
        private class ControllerState
        {
            public InteractionSourceHandedness Handedness;
            public bool SelectPressed;
        }
        public void MessagetoViewer(string themessage)
        {
            EnterWorld.text = themessage;
        }
            public void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }
            for (int i = 0; i < Buildings.Length; i++)
            {
                Buildings[i] = interactables[i];
                if (TheCamera.GetComponent<Collider>().bounds.Intersects(Buildings[i].GetComponent<Collider>().bounds) && thename != Buildings[i].name && changescenebool == false)
                {
                    Debug.Log("inside " + Buildings[i]);
                    MessagetoViewer("Click Trigger to Enter: " + Buildings[i].name);
                    thename = Buildings[i].name;

                }
                else if (!TheCamera.GetComponent<Collider>().bounds.Intersects(Buildings[i].GetComponent<Collider>().bounds) && thename == Buildings[i].name && changescenebool == false)
                {
                    MessagetoViewer("");
                    Debug.Log("Moving Outside of" + Buildings[i]);
                    thename = "WithLocations";
                }
                foreach (ControllerState controllerState in controllers.Values)
                {

                   // Debug.Log(controllerState.SelectPressed);
                        if (controllerState.SelectPressed == true && onlyonce == true && TheCamera.GetComponent<Collider>().bounds.Intersects(Buildings[i].GetComponent<Collider>().bounds) && changescenebool == false)
                        {
                            for (int j = 0; j < activateObjects.Length; j++)
                            {
                                activateObjects[j].transform.GetChild(0).gameObject.SetActive(true);
                            }

                            
                            for (int m = 0; m < deactiveObjects.Length; m++)
                            {
                                deactiveObjects[m].transform.GetChild(0).gameObject.SetActive(false);
                            }
                        thename = Buildings[i].name;
                        MessagetoViewer("Now Entering: " + Buildings[i].name);
                       // SceneManager.LoadSceneAsync(thename);
                            onlyonce = false;
                        }
                        else if (controllerState.SelectPressed == false)
                        {

                            onlyonce = true;

                        }
                    }
            }
        }
        /*
        protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
        {

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


            }


       
       /* IEnumerator LoadScene()
        {
            yield return null;

            //Begin to load the Scene you specify
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(thename);
            //Don't let the Scene activate until you allow it to
            asyncOperation.allowSceneActivation = false;
            Debug.Log("Pro :" + asyncOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                loadProgress.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //Change the Text to show the Scene is ready
                    loadProgress.text = "Press the space bar to continue";
                    //Wait to you press the space key to activate the Scene
                    if (Input.GetKeyDown(KeyCode.Space))
                        //Activate the Scene
                        asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
        

        protected override void InputUp(GameObject obj, InputEventData eventData)
        {
        }
        */
        public void OnStart()
        {
            Debug.Log("runned");
            deactiveObjects[0] = GameObject.Find("Map");
            deactiveObjects[1] = GameObject.Find("Waypoints");
            for (int j = 0; j < deactiveObjects[2].GetComponent<FindThebuildingsagain>().namesoflocations.Length; j++)
            {
                interactables[j] = GameObject.Find("3D Buildings/" + deactiveObjects[2].GetComponent<FindThebuildingsagain>().namesoflocations[j]);
                Targets[j] = interactables[j];
            }
        }
        private void InteractionManager_InteractionSourceDetected(InteractionSourceDetectedEventArgs obj)
        {
            Debug.LogFormat("{0} {1} Detected", obj.state.source.handedness, obj.state.source.kind);

            if (obj.state.source.kind == InteractionSourceKind.Controller && !controllers.ContainsKey(obj.state.source.id))
            {
                controllers.Add(obj.state.source.id, new ControllerState { Handedness = obj.state.source.handedness });
            }
        }

        private void InteractionManager_InteractionSourceLost(InteractionSourceLostEventArgs obj)
        {
            Debug.LogFormat("{0} {1} Lost", obj.state.source.handedness, obj.state.source.kind);

            controllers.Remove(obj.state.source.id);
        }

        private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
        {
            ControllerState controllerState;
            if (controllers.TryGetValue(obj.state.source.id, out controllerState))
            {

                controllerState.SelectPressed = obj.state.selectPressed;

            }
        }
    }
}
