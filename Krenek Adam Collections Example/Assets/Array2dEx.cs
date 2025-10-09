using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array2dEx : MonoBehaviour
{
    public string[,] sArray2d;
    // Start is called before the first frame update
    void Start()
    {
        sArray2d = new string[4, 4];

        sArray2d[0, 0] = "A";
        sArray2d[0, 3] = "B";
        sArray2d[1, 2] = "C";
        sArray2d[3,1] = "D";

        print("The length of sArray2d is: " + sArray2d.Length);

        string str = "";
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (sArray2d[i,j] != null)
                {
                    str += "|" + sArray2d[i, j];
                }
                else
                {
                    str += "|_";
                }
                str += "|" + "\n";
            }
        }print(str);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
