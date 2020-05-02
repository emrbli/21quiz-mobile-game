using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class besbekle : MonoBehaviour {
    
    public float dogruzaman;
    // Use this for initialization
    void Start () {
		dogruzaman = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
        dogruzaman -= Time.deltaTime;
        if (dogruzaman>0)
        {
            Debug.Log("Bekle " + dogruzaman);
        }
        else
        {

            Application.LoadLevel(1);
        }
    }
}
