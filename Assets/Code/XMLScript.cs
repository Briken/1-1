using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class XMLScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveGame()
    {
        TestDataClass tdc = new TestDataClass("My Name", "This is a serialized item");
        XmlSerializer x = new XmlSerializer(tdc.GetType());

        System.IO.FileStream file =
            System.IO.File.Create("Save_File.xml");

        x.Serialize(file, tdc);
    }

    public void LoadGame()
    {
        TestDataClass tdc = new TestDataClass("","");
        XmlSerializer x = new XmlSerializer(tdc.GetType());

        System.IO.FileStream file =
            System.IO.File.OpenRead("Save_File.xml");
        tdc = (TestDataClass)x.Deserialize(file);

        file.Close();
        print(tdc.name + " : " + tdc.description);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("<Level1Here>",  LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("<level1Here>"));
    }
}
