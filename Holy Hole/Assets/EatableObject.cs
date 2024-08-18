using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    public float Size => size;
    public int Points => points;
    [SerializeField] float size = 1;
    [SerializeField] int points = 1;
}
