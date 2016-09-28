using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour {

    #region member variables

    public enum FadeType { fin, fout };
    public FadeType m_type = FadeType.fin;
    public float m_secondsToWait;

    private GameObject m_fadeUI;
    private float m_alpha;

    #endregion

    void Awake ()
    {
        m_fadeUI = GameObject.Find("FadeUI");

        if (m_type == FadeType.fin)
        {
            m_alpha = m_secondsToWait;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(ActivateControls());
        }
        else
        {
            m_alpha = 0;
        }
	}
	
	void Update ()
    {
        if ((m_type == FadeType.fin && m_alpha <= 0) || (m_type == FadeType.fout && m_alpha >= 255))
        {
            return;
        }

	    if (m_type == FadeType.fin)
        {
            m_alpha -= Time.deltaTime;
        }
        else
        {
            m_alpha += Time.deltaTime;
        }

        Image image = m_fadeUI.GetComponent<Image>();

        Color c = image.color;
        c.a = m_alpha;
        image.color = c;
    }

    private IEnumerator ActivateControls()
    {
        yield return new WaitForSeconds(m_secondsToWait);
        GameObject.FindWithTag("Player").GetComponent<vp_FPInput>().enabled = true;
    }
}
