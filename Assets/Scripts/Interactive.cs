using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public bool deactivated;

    public void Deactivate()
    {
        deactivated = true;
    }

    
    public void Activate()
    {
        deactivated = false;
    }

    void Update()
    {

    }
}
