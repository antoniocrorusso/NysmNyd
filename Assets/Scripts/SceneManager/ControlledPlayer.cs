using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledPlayer : MonoBehaviour
{
    private int value = 1;
    public bool isPlayer;


    public void setValue(int number)
    {
        value = number;
    }

    // Update is called once per frame
    void Update()
    {
        if (value ==  1)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }
}
