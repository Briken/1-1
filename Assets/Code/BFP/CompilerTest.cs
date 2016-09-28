using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CompilerTest : MonoBehaviour {

    #region member variables

    public GameObject m_codeWindow;
    public GameObject m_output;

    private BFParser m_parser;
    private byte m_input;
    private string m_code;
    [SerializeField]
    public List<int> m_outputs;

    #endregion

    void Start ()
    {
        m_outputs = new List<int>();
    }

    public void Clear()
    {
        m_codeWindow.GetComponent<InputField>().text = null;
    }
	
    public void BuildAndRun()
    {
        m_code = m_codeWindow.GetComponent<InputField>().text;
        m_parser = new BFParser();
        m_parser.SetInput(m_input);
        m_parser.ParseCode(m_code);
    }

    public void AddToDisplay(int number)
    {
        m_outputs.Add(number);
    }

    public void Display()
    {
        m_output.SetActive(true);
        GameObject.Find("OutputGO").GetComponent<Text>().text = m_outputs[0].ToString();
    }

    public void DisplayText(string text)
    {
        m_output.SetActive(true);
        GameObject.Find("OutputGO").GetComponent<Text>().text = text;
    }

    public void SetInput(byte input)
    {
        m_input = input;
    }

    public byte GetOutput()
    {
        return m_parser.GetOutput();
    }
}
