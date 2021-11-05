using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject turret;
    

    public bool GetIsBuildable()
    {
        if(turret == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
