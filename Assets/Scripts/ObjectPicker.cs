using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectPicker : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Transform obstacles;
    [SerializeField] float mousePickupSpeed = 1f;
    [SerializeField] Material selectedMaterial;
    [SerializeField] Material unselectedMaterial;

    List<Transform> pickableObjects = new List<Transform>();
    List<Transform> selectedObjects = new List<Transform>();

    void Start()
    {
        //Failsafes 
        if (cam == null)
            cam = Camera.main;
        Assert.IsNotNull(obstacles);
        Assert.IsNotNull(selectedMaterial);
        Assert.IsNotNull(unselectedMaterial);

        //Set the pickables
        foreach(var obj in obstacles.GetComponentsInChildren<Transform>())  //Probably a bit dangerous
        {
            pickableObjects.Add(obj);
        }
    }

    void Update()
    {
        SelectObjects();
        LiftObjects();
        ColorObjects();
        DebugTest();
    }

    private void DebugTest()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        // Debug.Log("Object under cursor: " + hit.transform.ToString());
    }

    private void SelectObjects()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Cast a ray out from the mouse
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            // Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            //If it hits a object...
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                //If object hit is valid (ie. on the list of pickable objects)
                if (pickableObjects.Contains(objectHit))
                {
                    //ADD to selected if any shift keys are pressed
                    if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
                    {
                        selectedObjects.Clear();
                    }
                    selectedObjects.Add(objectHit);
                }
            }
        }


    }

    private void LiftObjects()
    {
        //Lift selected objects based on mouse vertical input * lift speed
        if (Input.GetMouseButton(0))
        {
            foreach (var obj in selectedObjects)
            {
                obj.GetComponent<Rigidbody>().useGravity = false;                //Turn off gravity before moving
                obj.Translate(Vector3.forward * mousePickupSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, cam.transform);
                obj.Translate(Vector3.up * mousePickupSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime, Space.World);
                obj.Translate(Vector3.right * mousePickupSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, cam.transform);
            }
        }
        else
        {
            //If mouse button release then turn gravity back on
            foreach (var obj in selectedObjects)
            {
                obj.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void ColorObjects()
    {
        //Colour everything as unselected first
        foreach (var obj in pickableObjects)
        {
            obj.GetComponentInChildren<MeshRenderer>().material = unselectedMaterial;   //Why InChildren?????
        }

        //Colour selected with selected material
        foreach (var obj in selectedObjects)
        {
            if (pickableObjects.Contains(obj))
            {
                obj.GetComponentInChildren<MeshRenderer>().material = selectedMaterial;
            }
        }
    }
}
