using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class positionSpawn : MonoBehaviour
{    
    public GameObject[] prefabs;
    public float posicionX,rangoYMin,rangoYMax;
    public float[] listY;
    void Start()
    {
        float manyDinos = UnityEngine.Random.Range(1, 11);
        listY=new float[(int)manyDinos];
        int contadorSprite=0;
        for (int i = 0; i < manyDinos; i++)
        {
            rangoYMax = (contadorSprite == 3) ?  130 : 0;
            rangoYMin = (contadorSprite == 3) ? 0 : -130;

            float posicionY;
            do
            {
                posicionY = Mathf.Round(UnityEngine.Random.Range(rangoYMin, rangoYMax) / 20f) * 20f;
            } while (listY.Contains(posicionY));

            listY[i] = posicionY;
            Vector3 setPosition = new Vector3(posicionX, posicionY, 0f);
            GameObject instanciaPrefab = Instantiate(prefabs[contadorSprite], setPosition, Quaternion.identity);

            contadorSprite = (contadorSprite != 3) ? contadorSprite + 1 : 0;
        }
    }
}
