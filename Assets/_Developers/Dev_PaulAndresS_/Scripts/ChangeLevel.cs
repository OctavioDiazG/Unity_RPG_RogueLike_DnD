using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void ChangingLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
