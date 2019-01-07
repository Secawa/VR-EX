using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace HoloToolkit.Unity
{
    public class FreezeCameraToZero : MonoBehaviour
    {
        public GameObject TheCamera;
        public Vector3 zeroposition;
        // Use this for initialization

        // Update is called once per frame

        public bool onlyonce = true;
        public GameObject[] canvas;
        private class ControllerState
        {
            public InteractionSourceHandedness Handedness;
            public bool Grasped;
            public bool MenuPressed;

        }

        private Dictionary<uint, ControllerState> controllers;

        // Text display label game objects

        private void Awake()
        {
            TheCamera.transform.position = zeroposition;
            controllers = new Dictionary<uint, ControllerState>();
            InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

            InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
            InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
        }

        private void Start()
        {
            if (DebugPanel.Instance != null)
            {
                DebugPanel.Instance.RegisterExternalLogCallback(GetControllerInfo);
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

            }
        }

        private string GetControllerInfo()
        {

            string toReturn = string.Empty;
            foreach (ControllerState controllerState in controllers.Values)
            {
                // Debug message
                toReturn += string.Format("Hand: {0}",
                                          "MenuPressed: {6} Touchpad: Pressed: {11}" + "Touched: {12} Position: {13}\n",
                                          controllerState.Handedness,
                                          controllerState.MenuPressed);
                // Text label display

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
            return toReturn.Substring(0, Math.Max(0, toReturn.Length - 2));
        }




        public void panelOpen()
        {
            for (int i = 0; i < canvas.Length; i++) { 
                if (canvas[i].activeSelf == false)
                {
                    canvas[i].SetActive(true);
                }
                else { canvas[i].SetActive(false); }
        }
        }
    }
}
