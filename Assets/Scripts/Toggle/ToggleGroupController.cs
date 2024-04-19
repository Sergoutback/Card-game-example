using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToggleGroupController : MonoBehaviour
{
    public List<ToggleIcon> toggles;

    public void ActivateToggle(ToggleIcon activeToggle)
    {
        if (toggles != null)
        {
            foreach (var toggle in toggles)
            {
                if (toggle != null && toggle != activeToggle)
                {
                    toggle.SetInactive(); // Deactivate all buttons except the active one
                }
            }
        }
    }
}