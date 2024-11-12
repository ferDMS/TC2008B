using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Numerics;

public class CrearArte : MonoBehaviour
{
    public GameObject PrefabArte;
    public int amount = 5; 
    public Vector3 posicionInicial = Vector3.zero; 
    public Vector3 offset = new Vector3(1, 0, 1); 
    GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        prefabs = new GameObject[0];
        CreateInstances();
    }

    void CreateInstances()
    {
        Vector3 currentPosition = posicionInicial;

        for (int i = 0; i < amount; i++)
        {
            GameObject newObj = Instantiate(PrefabArte, currentPosition, Quaternion.identity);

            Array.Resize(ref prefabs, prefabs.Length + 1);
            prefabs[prefabs.Length - 1] = newObj;

            currentPosition += offset;
        }
    }
}