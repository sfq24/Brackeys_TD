using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.WSA.Input;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Renderer render;
    private Color startColor;
    public Vector3 offset;
    private GameObject turret;
    BuildManager buildManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())           //检查是否指针在UI上
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }
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

