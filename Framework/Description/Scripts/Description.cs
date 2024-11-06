using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [TextArea(5, 20)]
    [SerializeField] private string description;
}
