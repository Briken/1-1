using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    #region member variables

    public string m_levelToLoad;

    #endregion

    public void End ()
    {
        Fader fader = FindObjectOfType(typeof(Fader)) as Fader;
        float time = fader.m_secondsToWait;
        fader.m_type = Fader.FadeType.fout;
        StartCoroutine(LoadLevel(time));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    private IEnumerator LoadLevel(float secs)
    {
        yield return new WaitForSeconds(secs);
        Application.LoadLevel(m_levelToLoad);
    }
}
