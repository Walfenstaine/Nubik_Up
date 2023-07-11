using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLoocker : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Muwer.rid.transform);
    }
}
