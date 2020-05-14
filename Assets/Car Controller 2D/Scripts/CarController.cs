using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[CreateAssetMenu(fileName = "Car Controller ()", menuName = "Car Controller/Create Car Controller")]
public class CarController : ScriptableObject
{
    private const int maxSIZE = 7;

    [Space(10)]
    public string SpeedTextName = "SpeedText";
    public string GearTextName = "GearText";

    [Space(10)]
    public bool FWD = false;
    public bool RWD = false;

    [Space(10)]
    public float CarMass = 2020f;
    public float FrontWheelMass = 13.5f;
    public float RearWheelMass = 13.5f;

    [Space(10)]
    public float MaxSpeed;
    public float motorForce;

    [Space(10)]
    public float[] gearRatio;
    [HideInInspector]
    public bool[] Transmission;
    [HideInInspector]
    public int currentTransmission;

    void OnValidate()
    {
        if (gearRatio.Length > maxSIZE)
        {
            Array.Resize(ref gearRatio, maxSIZE);
        }
        Array.Resize(ref Transmission, gearRatio.Length);
    }

}