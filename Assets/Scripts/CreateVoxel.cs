using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateVoxel : MonoBehaviour
{
    public float checkIncrement;
    public float reach = 8;
    private Camera mainCamera;
    private Vector3 lastPos;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        createVoxel();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("delete");
            FindObjectOfType<voxelRenderer>().editVoxelData(lastPos, 0);
        }
    }

    void createVoxel()
    {
        //float step = checkIncrement;
        //while (step<reach)
        //{
            Vector3 pos = mainCamera.transform.position + mainCamera.transform.forward * 1000;
            lastPos = new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt((pos.z)));
            Debug.Log(lastPos);
         //   step += checkIncrement;
        //}
    }
}
