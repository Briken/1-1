using UnityEngine;
using System.Collections;

public class EnableTricksterComponentTrigger : MonoBehaviour {

    #region member variables

    public Trickster m_trickster;

    #endregion

    void OnTriggerEnter ()
    {
        m_trickster.ActivateExternally();
	}
	
}
