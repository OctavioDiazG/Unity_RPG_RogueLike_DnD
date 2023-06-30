using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CheckDice : MonoBehaviour
{
    public List<DiceScript> dice;
    public List<int> Results;
    public GameObject ResultScreen;
    public GameObject next;
    public List<Text> ResultsText;
    public List<Dropdown> dropdowns;
    public List<Text> StatsNumber;
    public List<Text> StatsBonus;

    private bool selected;
    private List<Dropdown.OptionData> dropdownOption = new List<Dropdown.OptionData>() { 
        new Dropdown.OptionData("Choose Stat..."), 
        new Dropdown.OptionData("Strength"), 
        new Dropdown.OptionData("Dexterity"), 
        new Dropdown.OptionData("Constitution"), 
        new Dropdown.OptionData("Intelligence"), 
        new Dropdown.OptionData("Wisdom"), 
        new Dropdown.OptionData("Charisma")
    };

    public void RollDice()
    {
        foreach (DiceScript die in dice)
        {
            die.Toss();
        }
    }

    private void Update()
    {

        if(selected)
        {
            return;
        }

        Results.Clear();

        foreach (DiceScript die in dice)
        {
            if(die.result!=0)
            {
                 Results.Add(die.result);
                if(Results.Count == 8)
                {
                    selectDice();
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

        assignResults();
    }

    private void assignResults()
    {
        ResultScreen.SetActive(true);
        for(int i = 0; i < 6; i++)
        {
            ResultsText[i].text = "" + Results[i];
            dropdowns[i].options = dropdownOption;
        }
    }

    public void selectDropdown(Dropdown dropdown)
    {
        int pos = 0;
        next.SetActive(true);

        for (int i = 0; i < 6; i++)
        {
            if (dropdowns[i] == dropdown)
            {
                pos = i;
                continue;
            }

            if (dropdowns[i].value == dropdown.value)
            {
                dropdowns[i].value = 0;
                next.SetActive(false);
            }

            if (dropdowns[i].value == 0)
                next.SetActive(false);
        }

        if (dropdown.value == 0)
            return;

        StatsNumber[dropdown.value-1].text = "" + Results[pos];
        calculate();
    }

    private void calculate()
    {
        for(int i = 0; i < 6; i++)
        {
            switch (int.Parse(StatsNumber[i].text))
            {
                case 1:
                    StatsBonus[i].text = "-5";
                    break;
                case <4:
                    StatsBonus[i].text = "-4";
                    break;
                case < 6:
                    StatsBonus[i].text = "-3";
                    break;
                case < 8:
                    StatsBonus[i].text = "-2";
                    break;
                case < 10:
                    StatsBonus[i].text = "-1";
                    break;
                case < 12:
                    StatsBonus[i].text = "0";
                    break;
                case < 14:
                    StatsBonus[i].text = "1";
                    break;
                case < 16:
                    StatsBonus[i].text = "2";
                    break;
                case < 18:
                    StatsBonus[i].text = "3";
                    break;
                case < 20:
                    StatsBonus[i].text = "4";
                    break;
                case 20:
                    StatsBonus[i].text = "5";
                    break;
            }
        }
    }
}
