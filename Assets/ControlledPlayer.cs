using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledPlayer : MonoBehaviour
{
    private int[] index;
    private int value;
    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        int[] index = { 1, 2 };
    }

    public void setValue(int arrayNumber)
    {
        value = index[arrayNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (value == 1)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }
}
