using UnityEngine;
using System.Collections;

/// <summary>
/// This class will be in the player and will check for activatable objects
/// </summary>

public class MinigameActivator : MonoBehaviour {

    #region member variables

    public GameObject m_minigamePrefab;
    public bool m_isInMinigame = false;

    private bool m_isSolved = false;
    private Interactible m_interactible;
    private GameObject m_minigameGO;

    #endregion

    void Start()
    {
    }

	void FixedUpdate ()
    {
	    if (Input.GetButtonDown("Interact") && !m_isInMinigame)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(transform.position, hit.collider.transform.position) < 2 && hit.collider.gameObject.GetComponent<Interactible>() != null && !m_isSolved)
                {
                    //PUT ALL THIS SHIT IN INTERACTIBLE FFS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    m_isInMinigame = true;
                    m_interactible = hit.collider.gameObject.GetComponent<Interactible>();
                    //setup the minigame
                    m_minigameGO = Instantiate(m_minigamePrefab);
                    MinigameHandler handler = m_minigameGO.GetComponentInChildren<MinigameHandler>();
                    handler.m_toNotify = m_interactible.gameObject;

                    byte[] inputs = { 0, 4, 7 };
                    byte[] outputs = { 3, 7, 10 };

                    handler.SetupMinigame(inputs, outputs);
                }
            }
        }
    }

    public void ValidateGame(bool solved)
    {
        if (solved)
        {
            m_interactible.Activate();
            m_isInMinigame = false;
            m_isSolved = true;
        }
    }
}
