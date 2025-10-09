using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaggedListEx : MonoBehaviour
{
    public List<List<string>> jList;

    // Start is called before the first frame update
    void Start()
    {
        jList = new List<List<string>>();

        //Add 2 list<string>s to Jlist
        jList.Add(new List<string>());
        jList.Add(new List<string>());

        //Add 2 strings to Jlist[0]
        jList[0].Add("Hello");
        jList[0].Add("World");

        //Add a 3rd List<string> to Jlist, including data
        jList.Add(new List<string>(new string[] { "Complex" , "Initialization" }));

        string str = "";
        foreach (List<string> sL in jList) {
            foreach(string sTemp in sL)
            {
                if(sTemp != null)
                {
                    str += "|" + sTemp;
                }
                else
                {
                    str += "|_";
                }
                str += "|\n";
            }
                }
        print(str);
    }

    
}
