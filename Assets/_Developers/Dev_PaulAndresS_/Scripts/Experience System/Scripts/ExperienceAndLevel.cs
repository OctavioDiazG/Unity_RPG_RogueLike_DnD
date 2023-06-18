using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * Clase que implementan las interfaces para tener manejo de la experiencia y nivel
 */

public class ExperienceAndLevel : MonoBehaviour, IExperience, ILevel
{
    public Slider expBar;
    public Text tLevel;
    [SerializeField] private int mExperience = 0;
    [SerializeField] private int mLevel = 1;
    [SerializeField] private int mExperiencePerLevel = 100;
    [SerializeField] private int mMultiplierPerLevel = 3;

    public int UseExperience;
    public int Experience => mExperience;
    public int Level => mLevel;

    private void Start()
    {
        tLevel.text = "" + mLevel;
        UseExperience = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            AddExperience(10);
        }
    }

    public void AddExperience(int experience)
    {
        // Se asegura que sea un valor positivo
        experience = Mathf.Abs(experience);

        // Almacena la experiencia temporalmente para realizar
        // operaciones sobre ella
        int remainingExperience = experience;
        do
        {
            //Max level is 100
            if (mLevel == 99)
            {
                expBar.value = expBar.maxValue;
                break;
            }
            // Calcula la cantidad maxima de experiencia necesaria para cambiar de nivel
            int experienceToUpgrade = mExperiencePerLevel * mMultiplierPerLevel * mLevel;

            // Si la cantidad de experiencia a agregar hace que suba de nivel
            if (mExperience + remainingExperience >= experienceToUpgrade)
            {
                // Añade un nivel de experiencia
                AddLevel(1);
                mExperience = 0;
            }
            else
            {
                // Asigna la experiencia sobrante y termina el while
                mExperience += remainingExperience;
                remainingExperience = 0;
            }
            //Asignar UI con variables
            expBar.value = mExperience;
            expBar.maxValue = experienceToUpgrade;
            tLevel.text = "" + mLevel;
        } while (remainingExperience > 0);
    }

    public void AddLevel(int level)
    {
        // Evita que sea negativa y añade la experiencia
        level = Mathf.Abs(level);
        mLevel += level;
        UseExperience += level;
    }
}