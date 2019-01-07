using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.WSA.Input;
using UnityEngine.UI;

namespace HoloToolkit.Unity
{
    public class ClickLeftMenu : MonoBehaviour
    {
        public bool onlyonce = true;
        public bool onlyonce1 = true;
        public GameObject[] canvas;

        public GameObject movingcamera;
        public GameObject input;
        public float movingforward;
        public GameObject forwardobject;
        public GameObject Sidewaysobject;
        public bool alphaUp = false;
        private class ControllerState
        {
            public InteractionSourceHandedness Handedness;
            public bool Grasped;
            public bool MenuPressed;
            public bool TouchpadPressed;
            public bool TouchpadTouched;
            public Vector2 TouchpadPosition;

        }

        private Dictionary<uint, ControllerState> controllers;

        // Text display label game objects

        private void Awake()
        {
            forwardobject = GameObject.Find("CameraMovement Forward");
            Sidewaysobject = GameObject.Find("CameraMovement Sideways");
            movingcamera = GameObject.Find("MixedRealityCameraParent");
            canvas[0] = GameObject.Find("Cameraeyes").transform.GetChild(0).gameObject;
            canvas[1] = GameObject.Find("Waypoints");
            input = GameObject.Find("InputManager");
            controllers = new Dictionary<uint, ControllerState>();
            InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

            InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
            InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
        }

        private void Start()
        {
            movingcamera = GameObject.Find("MixedRealityCameraParent");
            if (DebugPanel.Instance != null)
            {
                DebugPanel.Instance.RegisterExternalLogCallback(GetControllerInfo);
            }
        }
        private void Update()
        {

            foreach (ControllerState controllerState in controllers.Values)
            {
                if (controllerState.Handedness.Equals(InteractionSourceHandedness.Left))
                {
                    if (controllerState.MenuPressed == true && onlyonce == true)
                    {
                        panelOpen();
                        onlyonce = false;
                    }
                    else if (controllerState.MenuPressed == false)
                    {
                        onlyonce = true;
                    }
                }
                if (controllerState.Handedness.Equals(InteractionSourceHandedness.Right))
                {
                    if (controllerState.MenuPressed == true && onlyonce1 == true)
                    {
                        panelOpen();
                        onlyonce1 = false;
                    }
                    else if (controllerState.MenuPressed == false)
                    {
                        onlyonce1 = true;
                    }
                }


              // Debug.Log(controllerState.MenuPressed);
                movingcamera.transform.position = Vector3.MoveTowards(movingcamera.transform.position, forwardobject.transform.position, movingforward * controllerState.TouchpadPosition.y * Time.deltaTime);
                movingcamera.transform.position = Vector3.MoveTowards(movingcamera.transform.position, Sidewaysobject.transform.position, movingforward/2 * -controllerState.TouchpadPosition.x * Time.deltaTime);
                if (controllerState.TouchpadPosition.y != 0 || controllerState.TouchpadPosition.x != 0)
                {
                    canvas[1].SetActive(false);
                }
            }
                if (Input.GetKey(KeyCode.UpArrow))
            {
                movingcamera.transform.Translate(Vector3.forward * Time.deltaTime * Time.deltaTime);
                Debug.Log("moving forward");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movingcamera.transform.Translate(Vector3.forward * -Time.deltaTime * Time.deltaTime);
                Debug.Log("moving backwards");
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

                controllerState.MenuPressed = obj.state.menuPressed;
                controllerState.TouchpadPressed = obj.state.touchpadPressed;
                controllerState.TouchpadTouched = obj.state.touchpadTouched;
                controllerState.TouchpadPosition = obj.state.touchpadPosition;

            }
        }

        private string GetControllerInfo()
        {

            string toReturn = string.Empty;
            foreach (ControllerState controllerState in controllers.Values)
            {
              //  Debug.Log(controllerState.TouchpadPosition);
                while (controllerState.TouchpadPosition.y >= 0.5 && controllerState.TouchpadPressed)
                {
                    movingcamera.transform.Translate(Vector3.forward * Time.deltaTime);
                }
                // Debug message
                toReturn += string.Format("Hand: {0}",
                                          "MenuPressed: {6} Touchpad: Pressed: {11}" + "Touched: {12} Position: {13}\n",
                                          controllerState.Handedness,
                                          controllerState.MenuPressed, controllerState.TouchpadPressed,
                                          controllerState.TouchpadTouched, controllerState.TouchpadPosition);
                //Debug.Log(controllerState.MenuPressed);
                // Text label display       

               
            }
            return toReturn.Substring(0, Math.Max(0, toReturn.Length - 2));
        }

        public void panelOpen()
        {
            if (canvas[0].activeSelf == false)
            {
                canvas[0].SetActive(true);
            }
            else
            {
                canvas[0].SetActive(false);
            }

        }
        public void OpenWaypointers()
        {
            if (movingcamera.transform.position != movingcamera.transform.position)
            {
                turnOnAlpha();
            }
            if (canvas[1].activeSelf == false)
            {
                canvas[1].SetActive(true);
            }
            else
            {
                canvas[1].SetActive(false);
            }

        }
        public void turnOnAlpha()
        {
            for (int i = 1; i < canvas.Length; i++)
            {
                canvas[i].GetComponent<CanvasGroup>().alpha = 0f;
            }
                alphaUp = true;
        }
        public void OnStart()
        {
            canvas[1] = GameObject.Find("Waypoints");
        }

    }
}