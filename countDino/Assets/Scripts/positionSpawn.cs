using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class positionSpawn : MonoBehaviour
{    
    public GameObject[] prefabs;
    public float posicionX;
    public float rangoYMin;
    public float rangoYMax;
    private float lastY;

    void Start()
    {
        float manyDinos = UnityEngine.Random.Range(1, 11);
        lastY = 1;
        for (int i = 0; i < manyDinos; i++)
        {         
            int randomIndex = UnityEngine.Random.Range(0, prefabs.Length);
            if (randomIndex == 3)
            {//Indica que vuela
                rangoYMax = 130;
                rangoYMin = 0;
            }
            else
            {//Indica que camina por la tierra
                rangoYMax = 0;
                rangoYMin = -130;
            }
            float posicionY = (float)(Math.Round(UnityEngine.Random.Range(rangoYMin / 20f, rangoYMax / 20f)) * 20f);
            if (lastY==posicionY)
            {
                posicionY += 10;
            }
            Vector3 posicionDeseada = new Vector3(posicionX, posicionY, 0f);
            GameObject instanciaPrefab = Instantiate(prefabs[randomIndex], posicionDeseada, Quaternion.identity);
            lastY = posicionY;
        }
    }
}
