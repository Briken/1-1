using UnityEngine;
using System.Collections;

public class Narrator : MonoBehaviour {

    #region member variables

    public AudioSource m_narration;
    public GameObject[] m_nextEvents;

    #endregion

    void OnEnable ()
    {
        m_narration.Play();
	}

    IEnumerator StartEvent()
    {
        yield return new WaitForSeconds(m_narration.clip.length);
        foreach (GameObject go in m_nextEvents)
        {
            go.SetActive(true);
        }
    }
}
