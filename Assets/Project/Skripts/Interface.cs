using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using InstantGamesBridge;

public class Interface : MonoBehaviour
{
    public Scrollbar sense;
    public Data data;
    public UnityEvent gameer, menue, chekPoint;
    public static Interface rid { get; set; }
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
        Menu();
    }

    public void Menu()
    {
        sense.value = data.sense;
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        menue.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void ChekPoint()
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        chekPoint.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    public void Game()
    {
        gameer.Invoke();
        Time.timeScale = 1;
        Lock(true);
        data.sense = sense.value;
        Muwer.rid.sensitivity = sense.value;
    }


    void Lock(bool stateTemp)
    {
        if(stateTemp && (Bridge.device.type == InstantGamesBridge.Modules.Device.DeviceType.Desktop))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
