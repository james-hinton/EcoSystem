using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    /* This shows a bar for stat for the animal */
    
    public string statName;

    public bool showStats = true;

    public Color statColor = Color.red;

    // stat between 0 and 1
    public float stat;

    // Update is called once per frame
    void Update()
    {
        // Get parent object
        GameObject parent = transform.parent.gameObject;

        // Get the stat from the animal
        stat = parent.GetComponent<AnimalObject>().GetStat(statName);

        // Display the stats above the animal
        if (showStats)
        {
            // stat Stat
            float statPercentage = stat * 100;

            // If the stat is below 50% shade the bar green, else if it is below 75% shade it yellow, else shade it red
            if (statPercentage < 50)
            {
                statColor = Color.green;
            }
            else if (statPercentage < 75)
            {
                statColor = Color.yellow;
            }
            else
            {
                statColor = Color.red;
            }

            GetComponent<Renderer>().material.color = statColor;         

        }

    }
}
