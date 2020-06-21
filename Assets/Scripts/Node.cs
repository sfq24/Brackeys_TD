using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Renderer render;
    private Color startColor;
    public Vector3 offset;
    private GameObject turret;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if(turret!= null)
        {
            Debug.Log("Already has a turret");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }
}

