using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application_Set : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
