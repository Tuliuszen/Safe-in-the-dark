using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    guard, demon, sad
}

[CreateAssetMenu(fileName = "Enemy Config", menuName = "EnemySO")]
public class EnemySO : ScriptableObject
{
    public Type type;

    public bool shooter;

    public float speed;
}
