using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner2 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    
    

    // Update is called once per frame
    void Update()
    {
        SpellItOut();
        //Instantiate(cubePrefabVar);
        GameObject cubeGO = Instantiate<GameObject>(cubePrefabVar);
        Material mat = cubeGO.GetComponent<Renderer>().material;
        mat.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.75f, 1);
    }

    void SpellItOut()
    {
        string sA = "Hello World";
        string sB = "";

        for (int i = 0; i < sA.Length; i++)
        {
            sB += sA[i];
        }
        print(sB);
    }
}
