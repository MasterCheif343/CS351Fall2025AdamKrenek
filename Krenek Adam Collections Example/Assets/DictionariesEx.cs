using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionariesEx : MonoBehaviour
{
    public Dictionary<string, string> statesDict;

    // Start is called before the first frame update
    void Start()
    {
        statesDict = new Dictionary<string, string>();

        statesDict.Add("MD", "Maryland");
        statesDict.Add("TX", "Texas");
        statesDict.Add("PA", "Pennsylvania");
        statesDict.Add("CA", "California");
        statesDict.Add("MI", "Michigan");

        print("statesDict contains " + statesDict.Count + " elements.");

        foreach (KeyValuePair<string, string> kvp in statesDict)
        {
            print(kvp.Key + ": " + kvp.Value);
        }
        print("MI is " + statesDict["MI"]);

        statesDict["BC"] = "British Columbia";

        foreach (string k in statesDict.Keys)
        {
            print(k + " is " + statesDict[k]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

