using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSpaceShipData", menuName = "Data/SpaceShip Data/Base Data")]
public class SpaceShipData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;
    public int totalLife;
    public int currentLifes;
    public int higthScore;
    public int currentScore;
}