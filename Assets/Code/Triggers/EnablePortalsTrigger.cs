using UnityEngine;
using System.Collections;

public class EnablePortalsTrigger : MonoBehaviour {

    #region member variables

    public GameObject m_portalToActivate;

    #endregion

    void OnTriggerEnter(Collider other)
    {
        m_portalToActivate.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
