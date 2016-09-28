using UnityEngine;
using System.Collections;

public class BFParser
{
    #region member variables

    private byte[] m_rail = new byte[1000];
    private byte m_output;
    private int m_pointer = 500;
    private CompilerTest m_compiler;

    #endregion

    public void SetInput(byte input)
    {
        m_rail[m_pointer] = input;
    }

    public void ParseCode(string code)
    {
        //m_compiler = GameObject.FindObjectOfType(typeof(CompilerTest)) as CompilerTest;

        foreach (char c in code)
        {
            ExecuteCommand(c, m_compiler);
        }

        //m_compiler.Display();
        m_output = m_rail[m_pointer];
    }

    public byte GetOutput()
    {
        return m_output;
    }

    void ExecuteCommand(char command, CompilerTest compiler)
    {
        switch (command)
        {
            case '+':
                if (m_rail[m_pointer] < 255)
                    m_rail[m_pointer]++;
                else
                    m_rail[m_pointer] = 0;
            break;

            case '-':
                if (m_rail[m_pointer] > 0)
                    m_rail[m_pointer]--;
                else
                    m_rail[m_pointer] = 255;
            break;

            case '<':
                m_pointer--;
            break;

            case '>':
                m_pointer++;
            break;

            case '.':
                compiler.AddToDisplay(m_rail[m_pointer]);
            break;
        }
    }
}
