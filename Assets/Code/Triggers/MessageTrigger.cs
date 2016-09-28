using UnityEngine;
using System.Collections;

public class MessageTrigger : MonoBehaviour {

    #region member variables

    public string m_message;
    public GameObject[] m_objectsToNotify;

    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && m_message != "" && m_objectsToNotify.Length != 0)
        {
            foreach(GameObject obj in m_objectsToNotify)
            {
                obj.BroadcastMessage(m_message);
            }
        }
    }

}
