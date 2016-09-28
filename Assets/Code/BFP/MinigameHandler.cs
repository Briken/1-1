using UnityEngine;
using System.Collections;

/// <summary>
/// takes care of activating the minigame and notifying the connected GO of the result of the game session
/// </summary>

public class MinigameHandler : MonoBehaviour
{

    #region member variables

    public GameObject m_toNotify;

    private CompilerTest m_compiler;
    public byte[] m_inputs;
    public byte[] m_outputs;

    #endregion

    void Start()
    {
        m_compiler = GetComponent<CompilerTest>();
        m_compiler.DisplayText("1 > 4\n4 > 7\n7 > 10");
        //deactivate player controls and restore the cursor
        m_toNotify = GameObject.FindWithTag("Player");
        m_toNotify.GetComponent<vp_FPInput>().enabled = false;

        //show small tutorial?

        //present logic problem

        //assign a logic problem to the minigame

    }

    public void SetupMinigame(byte[] inputs, byte[] outputs)
    {
        m_inputs = inputs;
        m_outputs = outputs;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CheckMinigame()
    {
        //here we check if the solution offered by the player is acceptable
        int result;
        //for each of the INPUT values we have in an array (and consequently outputs)
        for (int i = 0; i < m_inputs.Length; i++)
        {
            //we start from the array input point and feed an INPUT value
            m_compiler.SetInput(m_inputs[i]);
            //we then compile the program that the player input and compare it against our OUTPUT
            m_compiler.BuildAndRun();
            result = m_compiler.GetOutput();
            if (m_outputs[i] != result)
            {
                m_toNotify.GetComponent<MinigameActivator>().ValidateGame(false);
                m_compiler.DisplayText("Wrong answer, try again");
                return;
            }
        }
        //we completed the minigame
        m_toNotify.GetComponent<MinigameActivator>().ValidateGame(true);
        m_compiler.DisplayText("Pattern solved"); //try to find a way to delay this
        Destroy(m_compiler.gameObject);
        Destroy(this.gameObject);

    }

    void OnDestroy()
    {
        //reactivate all the stuff
        m_toNotify.GetComponentInChildren<vp_FPInput>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Minigame"))
        {
            Destroy(go);
        }
    }
}
