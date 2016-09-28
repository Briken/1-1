using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    #region member variables

    public float m_speed;

    #endregion

    void Update ()
    {
        gameObject.transform.Rotate(Vector3.forward, m_speed * GameObject.Find("TimeMasterGO").GetComponent<TimeMaster>().CustomTimeScale * Time.deltaTime);
    }
}
