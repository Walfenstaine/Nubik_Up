using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Andlevel : MonoBehaviour
{
    public string lvl;
    public void Reload()
    {
        SaveAndLoad.Instance.Save();
        SceneManager.LoadScene(lvl);
    }
}
