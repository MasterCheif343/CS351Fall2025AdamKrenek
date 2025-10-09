using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerListEx : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectList; //holds all the cubes
    [Tooltip("This is the amount that a cube will shrink each frame.")]
    public float scalingFactor = 0.95f;
    public int numCubes = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       numCubes++; //Add to number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
        //These lines set some values on the new cubes
        gObj.name = "Cube " + numCubes;
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = c;
        //^Gets the renderer of gObj and gives its material a random color
        gObj.transform.position = Random.insideUnitSphere;

        gameObjectList.Add(gObj); //Add gObj to the list of cubes

        List<GameObject> removeList = new List<GameObject>();
        //^This will store information on Cubes that should be removed from gameObjectList

        //Iterate through each Cube in gameObjectList
        foreach (GameObject goTemp in gameObjectList)
        {
            //Get the scale of the cube
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor; //Shrink by scalingFactor
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)
            {
                //if Scale is less than 0.1f then add it to removeList
                removeList.Add(goTemp);
            }
        }
        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // Remove the cube from gameObjectList
            Destroy(goTemp);
        }

    }
}
