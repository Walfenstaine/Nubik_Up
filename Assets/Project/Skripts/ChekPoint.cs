using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SaveAndLoad.Instance.Save();
            Interface.rid.ChekPoint();
            Destroy(gameObject);
        }
    }
}
