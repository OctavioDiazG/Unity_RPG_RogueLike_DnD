using System;
using UnityEngine;
using UnityEngine.UI;

public class ManageLvl : MonoBehaviour
{

    public ExperienceAndLevel exp;
    public Text EXPtoLevel;
    int nValue;
    
    private void Awake() {
        exp = FindObjectOfType<ExperienceAndLevel>();
        EXPtoLevel.text = "1";
    }

    private void Update() {
        EXPtoLevel.text = "" + exp.UseExperience;
    }

    public void AddValue(Text value){
        if(exp.UseExperience > 0){
            nValue =  int.Parse(value.text);
            if(nValue == 20){
                return;
            } 
            nValue++;
            value.text = "" + nValue;
            exp.UseExperience--;
        }
    }
    public void SubValue(Text value){
        
        nValue =  int.Parse(value.text);
        if(nValue == 1){
            return;
        }
        nValue--;
        value.text = "" + nValue;
        exp.UseExperience++;
    }

    public void UpdateData(Text value){
        
        value.text = "" + Math.Floor((nValue * 0.5f) - 5);
    }
}
