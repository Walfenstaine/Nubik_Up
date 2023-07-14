using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPoint : MonoBehaviour
{
    public Data data;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Teleport.rid.position = transform.position;
            SaveAndLoad.Instance.Save();
            Interface.rid.ChekPoint();
            Destroy(gameObject);
        }
    }
}
