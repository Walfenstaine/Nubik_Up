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
    public UnityEvent gameer, menue, chekPoint, down, andlevel;
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
        if (Muwer.rid != null)
        {
            Muwer.rid.muve = Vector2.zero;
            Muwer.rid.rut = Vector2.zero;
        }
        menue.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void ChekPoint()
    {
        if (Muwer.rid != null)
        {
            Muwer.rid.muve = Vector2.zero;
            Muwer.rid.rut = Vector2.zero;
        }
        chekPoint.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    public void Down()
    {
        if (Muwer.rid != null)
        {
            Muwer.rid.enabled = false;
            Muwer.rid.muve = Vector2.zero;
            Muwer.rid.rut = Vector2.zero;
        }  
        down.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    public void Game()
    {
        if (Muwer.rid != null)
        {
            Muwer.rid.sensitivity = sense.value;
            Muwer.rid.enabled = true;
        }
        gameer.Invoke();
        Time.timeScale = 1;
        Lock(true);
        data.sense = sense.value;
        
    }
    public void Andlevel()
    {
        if (Muwer.rid != null)
        {
            Muwer.rid.muve = Vector2.zero;
            Muwer.rid.rut = Vector2.zero;
        }
        andlevel.Invoke();
        Time.timeScale = 0;
        Lock(false);
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
