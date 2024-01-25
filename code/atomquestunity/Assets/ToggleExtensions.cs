using UnityEngine;
using UnityEngine.UI;

public static class ToggleExtensions
{
    public static Toggle GetPreviousToggle(this Toggle toggle)
    {
        ToggleGroup toggleGroup = toggle.group;
        for (int i = 0; i < toggleGroup.transform.childCount; i++)
        {
            Transform child = toggleGroup.transform.GetChild(i);
            if (child != toggle.transform && child.GetComponent<Toggle>().isOn)
            {
                return child.GetComponent<Toggle>();
            }
        }
        return null;
    }
}