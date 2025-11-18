using UnityEngine;
using UnityEngine.UI;
public class DashUI : MonoBehaviour
{
    public Image dashCooldownImage;

    public void UpdateDashUI(float cooldownTime, float timer)
    {
        if (timer > 0)
            dashCooldownImage.fillAmount = 1f - (timer / cooldownTime);
        else
            dashCooldownImage.fillAmount = 1f;
    }
}