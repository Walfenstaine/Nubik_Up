using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 position;
    public static Teleport rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    void Start()
    {
        Repit();
    }
    public void Repit()
    {
        position = Muwer.rid.transform.position;
    }
    public void Port()
    {
        Muwer.rid.transform.position = position;
    }
    public void Vkl()
    {
        Muwer.rid.enabled = true;
    }
}
