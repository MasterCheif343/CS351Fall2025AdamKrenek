using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaggedArrayEx : MonoBehaviour
{
    public string[][] jArray;
    // Start is called before the first frame update
    void Start()
    {
        jArray = new string[4][];

        jArray[0] = new string[4];
        jArray[0][0] = "A";
        jArray[0][1] = "B";
        jArray[0][2] = "C";
        jArray[0][3] = "D";

        //These lines use single-line Array initialization syntax
        jArray[1] = new string[] { "E", "F", "G" };
        jArray[2] = new string[] { "H", "I" };

        jArray[3] = new string[4];
        jArray[3][0] = "J";
        jArray[3][3] = "K";

        print("The length of jArray is:" + jArray.Length);

        print("The length of jArray[1] is:" + jArray[1].Length);

        string str = "";
        foreach (string[] sArray in jArray)
        {
            foreach (string sTemp in sArray)
            {
                if (sTemp != null)
                {
                    str += "|" + sTemp;
                }
                else
                {
                    str += "|_";
                }
            }

            str += "|\n";
        }
        print(str);
    }
    
}

