using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsEX : MonoBehaviour
{
    public int numTimesCalled = 0;
    public List<GameObject> reallyLongList;
    public GameObject goOne, goTwo, goThree;
    private void Start()
    {
        print (Fac(5));
        print (Fac(0));
        print(Fac(-5));
        print(Fac(10).ToString("#,##0"));

        //SetX(this.gameObject, 25.0f);
        //print(this.gameObject.transform.position.x);
        //SetX(this.gameObject);
        //print(this.gameObject.transform.position.x);

        //print(Add(1.0f, 2.5f));
       // print(Add(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
        //Color colorA = new Color(0.5f, 1, 0, 1);
        //Color colorB = new Color(0.15f, 0.33f,0,1);
        //print (Add(colorA, colorB));

        //AlignX(goOne, goTwo, goThree);
        //MoveToOrigin("Phil");

        //PrintUpdates

        //PrintGameObjectName(this.gameObject);
        //SetColor(this.gameObject, Color.red);
        //Say("Hello");
    }
    
    int Fac( int num)
    {
        if(num < 0) { return 0; }
        if(num == 0) { return 1; }

        int result = num * Fac(num - 1);
        return result;
    }
    void SetX(GameObject go, float newX = 0.0f)
    {
        Vector3 tempPos = go.transform.position;
        tempPos.x = newX;
        go.transform.position = tempPos;
    }
    float Add(float f0, float f1)
    {
        return (f0 + f1);
    }

    Vector3 Add(Vector3 v0, Vector3 v1)
    {
        return(v0 + v1);
    }

    Color Add(Color c0, Color c1)
    {
        float r, g, b, a;
        r = Mathf.Clamp01(c0.r + c1.r);
        g = Mathf.Clamp01(c0.g + c1.g);
        b= Mathf.Clamp01(c0.b + c1.b);
        a = Mathf.Clamp01(c0.a + c1.a);
        return (new Color(r, g, b, a));
    }
    void AlignX(GameObject go0, GameObject go1, GameObject go2)
    {
        float avgX = go0.transform.position.x;
        avgX += go1.transform.position.x;
        avgX += go2.transform.position.x;
        avgX = avgX / 3.0f;

        SetX1 (go0, avgX );
        SetX1(go1, avgX );
        SetX1(go2, avgX );
    }

    void SetX1(GameObject go, float newX)
    {
        Vector3 tempPos = go.transform.position;
        tempPos.x = newX;
        go.transform.position = tempPos;
    }
    void MoveToOrigin( string theName)
    {
        foreach (GameObject go in reallyLongList)
        {
            if(go.name == theName)
            {
                go.transform.position = Vector3.zero;
                return;
            }

        }
    }
    void PrintUpdates()
    {
        string outputMessage = "Updates: " + numTimesCalled;
        print(outputMessage);
    }
    void Say(string sayThis)
    {
        print(sayThis);
    }

    void PrintGameObjectName(GameObject go)
    {
        print(go.name);
    }

    void SetColor(GameObject go, Color col)
    {
        Renderer r = go.GetComponent<Renderer>();
        r.material.color = col;
    }
}
