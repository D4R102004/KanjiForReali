using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TextAreaController : MonoBehaviour
{
    private InputField inputField;

    void Start()
    {
        inputField.onEndEdit.AddListener(HandleTextChange);
    }

    void HandleTextChange(string newText)
    {
        // Basic indentation logic
        var lines = newText.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            int indentLevel = CountIndentation(lines[i - 1]);
            lines[i] = new string(' ', indentLevel * 4) + lines[i];
        }
        newText = string.Join("\n", lines);
        inputField.textComponent.text = newText; // Directly set the text component to update display
        inputField.caretPosition = newText.Length; // Move caret to the end
    }

    int CountIndentation(string line)
    {
        int count = 0;
        foreach (char c in line)
        {
            if (c == '{') count++;
            else if (c == '}') count--;
        }
        return Mathf.Max(0, count); // Ensure indentation doesn't go negative
    }

    public void OnSubmit()
    {
        // Custom submit action, e.g., compile and execute
        Debug.Log("Submitting text: " + inputField.text);
    }
}
