using UnityEngine;
using System.Collections;

public class TricksterTrigger : MonoBehaviour {

    #region member variables

    [SerializeField]
    public enum TriggerMode { interaction, time };
    public TriggerMode m_triggerMode = TriggerMode.interaction;
    public float m_timeToActivate;
    public GameObject m_tricksterGameObject;

    #endregion

    void Start ()
    {
	    if (m_triggerMode == TriggerMode.time)
        {
            StartCoroutine(ActivateTricksters());
        }
	}
	
	public void ActivateTrickster()
    {
            if (m_tricksterGameObject.GetComponent<Trickster>() != null)
                m_tricksterGameObject.GetComponent<Trickster>().ActivateExternally();
    }

    IEnumerator ActivateTricksters()
    {
        yield return new WaitForSeconds(m_timeToActivate);
        foreach (Transform obj in GetComponentInChildren<Transform>())
        {
            if (obj.GetComponentInChildren<Trickster>() != null)
                obj.GetComponentInChildren<Trickster>().ActivateExternally();
        }
    }
}
