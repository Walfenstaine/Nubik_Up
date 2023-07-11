using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {

	private Muwer muwer;
	// Use this for initialization
	void Start () {
        muwer = Muwer.rid;
	}
	

	void Update () {
		muwer.muve = new Vector3 (Input.GetAxis ("Horizontal"), muwer.muve.y, Input.GetAxis ("Vertical"));
        muwer.rut = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            muwer.Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Tab))
        {
            Interface.rid.Menu();
        }
    }
}
