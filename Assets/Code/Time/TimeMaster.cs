using UnityEngine;
using System.Collections;


public class TimeMaster : MonoBehaviour
{

    public float CustomTimeScale = 1;
    public float m_slowedTimeScale = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("TimeSlow"))
        {
            CustomTimeScale = m_slowedTimeScale;
        }
        else
            CustomTimeScale = 1;

    }
}
