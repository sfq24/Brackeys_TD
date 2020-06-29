using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float borderBuffer = 10f;
    public float scrollSpeed = 30f;
    public bool IsMovable = true;
    public float minimumY = 10f;
    public float maximumY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsMovable = !IsMovable;
        }
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (!IsMovable) return;

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderBuffer)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderBuffer)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderBuffer)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderBuffer)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scrollSpeed * scroll;
        pos.y = Mathf.Clamp(pos.y, minimumY, maximumY);
        transform.position = pos;

    }
}
