using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] prefabs; // Un arreglo que contiene tus 4 prefabs diferentes

    void Start()
    {
        int indiceAleatorio = Random.Range(0, prefabs.Length); // Genera un índice aleatorio dentro del rango de prefabs

        GameObject objetoGenerado = Instantiate(prefabs[indiceAleatorio], transform.position, Quaternion.identity);

        // Puedes ajustar la posición y la rotación según tus necesidades.
    }
}
