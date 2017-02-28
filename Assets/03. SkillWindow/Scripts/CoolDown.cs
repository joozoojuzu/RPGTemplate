using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour {
    public float duration;
    public float cooldown;
    public Image icon;
    public Button button;

    private bool startCooldown;

    public float castingDuration;
    public float castingTime;
    public Slider castingBar;

    void Start()
    {
        button = GetComponent<Button>();
        CoolDownManager.Instance.Add(this);
        castingBar = GameObject.Find("CastingBar").GetComponent<Slider>();
    }

    public void CoolDownComplete()
    {
        startCooldown = true;
        StartCoroutine(CoCoolDown());
    }

    IEnumerator CoCoolDown()
    {
        if (startCooldown)
        {
            while(true)
            {
                if (cooldown < duration)
                {
                    cooldown += Time.deltaTime;
                    icon.fillAmount = cooldown / duration;
                    button.interactable = false;
                }
                else
                {
                    startCooldown = false;
                    cooldown = 0f;
                    button.interactable = true;
                    yield break;
                }
                yield return null;
            }
        }
    }

    public void StartCoolDown()
    {
        StartCoroutine(CoCasting());
    }

    IEnumerator CoCasting()
    {
        while (true)
        {
            if (castingTime < castingDuration)
            {
                //castingBar.gameObject.SetActive(true);
                castingTime += Time.deltaTime;
                castingBar.value = castingTime / castingDuration;
            }
            else
            {
                //castingBar.gameObject.SetActive(false);
                castingTime = 0f;
                CoolDownManager.Instance.responseTarget = new CoolDownManager.ResponseTarget(CoolDownComplete);
                CoolDownManager.Instance.StartCoolDown();
                yield break;
            }
            yield return null;
        }
    }
}
