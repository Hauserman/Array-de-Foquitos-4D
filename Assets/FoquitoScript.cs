using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    public GameObject[] colors;
    public int currentLightIndex = -1;
    int CurrentCycle = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight()
    {
        if (CurrentCycle == 3)
        {
            foreach (GameObject g in colors)
            {
                Destroy(g);
            }
        }
        else
        {
            currentLightIndex++;
            if (currentLightIndex >= colors.Length)
            {
                currentLightIndex = 0;
                CurrentCycle++;
            }
            DeactivateAllLights();
            colors[currentLightIndex].SetActive(true);
        }
    }

    public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in colors)
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        CancelInvoke(nameof(ActivateNextLight));
        InvokeRepeating(nameof(ActivateNextLight), 0, t);
    }
}
