using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider ExpBar;

    public void ExpFromEnemy()
    {
        //nivel maximo de 300 (100 vida, 100 mana, 100 stamina)
        ExpBar.value++;
    }

}
