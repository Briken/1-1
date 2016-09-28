using UnityEngine;
using System.Collections;

public class Deactivate : MonoBehaviour {

    #region member variables

    public GameObject m_target;

    #endregion

    public void Kill()
    {
        CompilerTest comp = GameObject.FindObjectOfType(typeof(CompilerTest)) as CompilerTest;
        if (comp.m_outputs.Count != 0)
        {
            comp.m_outputs.RemoveAt(0);
            comp.Display();
        }
        else
            m_target.SetActive(false);
    }
}
