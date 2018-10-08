using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SteeringConfig
{
    public const int num_priorities = 5;
}

abstract public class SteeringAbstract : MonoBehaviour
{
    [Range(0, SteeringConfig.num_priorities)]
    public int priority = 0;
}
