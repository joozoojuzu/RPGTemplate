using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownManager : MonoBehaviour {
    public Dictionary<GameObject, CoolDown> cooldowns = new Dictionary<GameObject, CoolDown>(64);

    public delegate void ResponseTarget();
    public ResponseTarget responseTarget;

    private static CoolDownManager instance;
    public static CoolDownManager Instance
    {
        get
        {
            return instance;
        }
    }

    public float duration;
    public float cooldown;
    public bool startCooldown;
    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        if (startCooldown)
        {
            if (cooldown < duration)
            {
                cooldown += Time.deltaTime;

                foreach (KeyValuePair<GameObject, CoolDown> element in cooldowns)
                {
                    element.Value.icon.fillAmount = cooldown / duration;
                    element.Value.button.interactable = false;
                }
            }
            else
            {
                foreach (KeyValuePair<GameObject, CoolDown> element in cooldowns)
                {
                    element.Value.button.interactable = true;
                }

                startCooldown = false;
                cooldown = 0f;

                if (responseTarget != null)
                {
                    responseTarget();
                    responseTarget = null;
                }
            }
        }
    }

    public void StartCoolDown()
    {
        startCooldown = true;
    }

    public void Add(CoolDown cooldown)
    {
        if (!cooldowns.ContainsKey(cooldown.gameObject))
        {
            cooldowns[cooldown.gameObject] = cooldown;
        }
    }

    public void Delete(GameObject cooldown)
    {
        if (cooldowns.ContainsKey(cooldown))
        {
            cooldowns.Remove(cooldown);
        }
    }
}
