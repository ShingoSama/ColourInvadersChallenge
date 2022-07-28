using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    public enum alienColours
    {
        green,
        blue,
        yellow,
        red,
        white
    }
    [Header("Move State")]
    public float movementVelocity = 3f;
    public int maxHealth;
    public int currentHealth;
    public alienColours colour;
    public Sprite sprite;
    public AnimatorController animator;
    public LayerMask layerMask;
}