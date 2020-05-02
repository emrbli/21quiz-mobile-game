using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Geri : MonoBehaviour {

    public string Menu;
    public void SahneGecisMenu()
    {
        SceneManager.LoadScene(Menu);//anamenu sahnesine gonder.
    }
}
