using System.Collections;
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

    private void Start()
    {
        turrentToBuild = standardTurretPrefab;
    }

    private GameObject turrentToBuild;

    public GameObject GetTurretToBuild()
    {
        return turrentToBuild;
    }

}
