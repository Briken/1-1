using UnityEngine;
using System.Collections;

public class Interactible : MonoBehaviour {

    #region member variables

    public GameObject[] m_deactivate;
    public GameObject[] m_activate;

    #endregion

    public void Activate()
    {
        //print("Terminal activated");
        if (m_deactivate.Length != 0)
            foreach (GameObject go in m_deactivate)
                go.SetActive(false);

        if (m_activate.Length != 0)
            foreach (GameObject go in m_activate)
                go.SetActive(false);

        if (GetComponent<TricksterTrigger>() != null)
        {
            GetComponent<TricksterTrigger>().ActivateTrickster();
        }
    }
}
