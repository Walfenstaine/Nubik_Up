using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLoocker : MonoBehaviour
{
    void Update()
    {
        if (Muwer.rid != null)
        {
            transform.LookAt(Muwer.rid.transform);
        }
    }
}
