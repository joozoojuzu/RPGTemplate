using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    public Camera mainCamera;
    public LayerMask selectableCollisionLayer;
    public GameObject targetStateUIZone;

    private TargetStateUIZone targetStateUIZoneScript;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private Health targetHealth;
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /* ToDo : 현재 아주 큰 문제가 있다.
             * 1. 몬스터는 플레이어가 근접해 있다는 것을 Sphere Collider의 radius 범위를 확대하여 OnTriggerEnter 에서 하고 있다.
             * 2. 플레이어가 클릭 했을 때 Raycast는 몬스터의 확대된 Sphere Collider과 충돌 함으로 범위에 대한 오류가 발생한다.
             * 3. 몬스터는 플레이어가 근접해 있다는 것을 실시간 거리계산으로 해야 할까?
             * 4. 플레이어 감지 Sphere Collider는 그대로 둔 채 몬스터에 꼭 맞는 크기의 Capsule Collider를 추가 해야할까?
             * 5. 4번의 경우 문제는 해결되지 않는다.
             */
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, selectableCollisionLayer.value))
            {
                if(hit.collider.gameObject.layer == 9 || hit.collider.gameObject.layer == 10)
                {
                    targetHealth = hit.collider.gameObject.GetComponent<Health>();
                    targetStateUIZoneScript = targetStateUIZone.GetComponent<TargetStateUIZone>();
                    targetStateUIZoneScript.Show(targetHealth);
                }
            }
            else
            {
                targetStateUIZoneScript = null;
                targetStateUIZone.GetComponent<TargetStateUIZone>().Hide();
            }
        }
	}
}
