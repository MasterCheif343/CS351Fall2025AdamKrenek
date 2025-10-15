using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{ // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i <= 360; i++)
        { if((i % 90) != 0){
                continue;
            }
        print(i);
        }
    }
}
    
