﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    //private void Start()
    //{
    //    turrentToBuild = standardTurretPrefab;
    //}

    private GameObject turrentToBuild;

    public GameObject GetTurretToBuild()
    {
        return turrentToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }
}
