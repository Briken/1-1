using UnityEngine;
using System.Collections;

public class Bugs : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ReverseMouse(bool pop)
    {
        player.GetComponent<vp_FPInput>().MouseLookInvert = pop;
    }

    void CrashGame()
    {
        // on specific event required
        Crash();
    }

    IEnumerator Crash(  )
    {
        yield return new WaitForSeconds(2); //Animation length of the crash animation for the wait time. jsut set to a randome number atm
        Application.Quit();
    }
}
