using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDice : MonoBehaviour
{
    public List<DiceScript> dice;
    public List<int> Results;

    private bool selected;

    public void RollDice()
    {
        foreach (DiceScript die in dice)
        {
            die.Toss();
        }
    }

    private void Update()
    {
        Results.Clear();

        if(selected)
        {
            return;
        }

        foreach (DiceScript die in dice)
        {
            if(die.result!=0)
            {
                 Results.Add(die.result);
                if(Results.Count == 8)
                {
                    selectDice();
                    Debug.Log("xd");
                }
            }
        }
    }

    private void selectDice()
    {
        selected= true;
        DiceScript minDice = dice[0];
        DiceScript maxDice = dice[0];

        foreach (DiceScript die in dice)
        {
            if(die.result < minDice.result)
            {
                minDice= die;
            }

            if(die.result> maxDice.result)
            {
                maxDice= die;
            }
        }

        Debug.Log("Eliminado " + minDice.result + " y " + maxDice.result);
        Results.Remove(minDice.result);
        Results.Remove(maxDice.result);
        Destroy(minDice.gameObject);
        Destroy(maxDice.gameObject);
    }
}
