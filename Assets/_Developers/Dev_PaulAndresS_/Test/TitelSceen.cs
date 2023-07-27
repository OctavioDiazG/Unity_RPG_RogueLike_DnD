using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitelSceen : MonoBehaviour
{

    public Image Title;
    byte col;

    private void Start() {
        Call();
    }
    // Update is called once per frame
    void Update()
    {
        Title.GetComponent<Image>().color = new Color32(255,255,255,col);
    }

    public void Call()
    {
        InvokeRepeating(nameof(Sum),.05f,.05f);
    }

    private void Sum(){
        
        if(col < 254){
            col++;
        }
    }

    public void ChangeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
