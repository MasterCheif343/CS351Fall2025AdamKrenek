using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEx : MonoBehaviour
{
    public List<string> sList;

    // Start is called before the first frame update
    void Start()
    {
        sList = new List<string>();
        sList.Add("Experience");
        sList.Add("is");
        sList.Add("what");
        sList.Add("you");
        sList.Add("get");
        sList.Add("when");
        sList.Add("you");
        sList.Add("don't");
        sList.Add("get");
        sList.Add("What");
        sList.Add("you");
        sList.Add("wanted");

        print("sList count:" + sList.Count);
        print("The 0th element is: " + sList[0]);
        print("The 1st element is: " + sList[1]);
        print("The 3rd element is: " + sList[3]);
        print("The 8th element is: " + sList[8]);

        string str = " ";
        foreach(string sTemp in sList)
        {
            str+= sTemp;
        }
        print(str);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
