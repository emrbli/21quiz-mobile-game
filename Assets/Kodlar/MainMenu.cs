using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        Application.LoadLevel(1);//1.Sahenyi açar.
    }
    public void QuitGame()//oyunu kapatmak için void oluşturduk.
    {
        Debug.Log("Kapandı");   //consola oyun kapandı yazdırdık.
        Application.Quit();//uygulamayı kapatma kodu yazdık.
    }
}
    