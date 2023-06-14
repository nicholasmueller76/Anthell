using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EntityData", order = 1)]
public class EntityData : ScriptableObject
{
    /// <summary>
    /// The ant's maximum health.
    /// </summary>
    public float maxHealth;

    /// <summary>
    /// How fast the ant moves.
    /// </summary>
    public float speed;

    /// <summary>
    /// How far away the ant has to be to attack/mine.
    /// </summary>
    public float range;

    /// <summary>
    /// What percent of a block is mined each second.
    /// </summary>
    public float[] mineSpeed = new float[4];

    /// <summary>
    /// What percent of a block is built each second.
    /// </summary>
    public float buildSpeed;

    /// <summary>
    /// Whether or not the ant should seek out enemies automatically.
    /// </summary>
    public bool autoAttack;

    /// <summary>
    /// How much damage the ant does per attack.
    /// </summary>
    public float attackDamage;

    /// <summary>
    /// Time between concesecutive attacks.
    /// </summary>
    public float attackCooldown;

    public int cashCost;
    public int dirtCost;
    public int stoneCost;
    public int woodCost;
    public int sulfurCost;
}
