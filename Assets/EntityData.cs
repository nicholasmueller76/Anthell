using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EntityData", order = 1)]
public class EntityData : ScriptableObject
{
    //The ant's maximum health.
    public float maxHealth;

    //How fast the ant moves.
    public float speed;

    //How far away the ant has to be to attack/mine.
    public float range;

    //What percent of a block is mined each second.
    public float mineSpeed;

    //Damage per second.
    public float damage;
}
