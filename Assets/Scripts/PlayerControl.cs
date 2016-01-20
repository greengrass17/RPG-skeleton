using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public delegate void CheckTargetItemEvent(Vector3 mouseTarget);

public class PlayerControl : MonoBehaviour {

	[SerializeField]
    private float speed;

    public event CheckTargetItemEvent CheckTargetItem;

	private IEnumerator moveCoroutine;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
        // Check if left mouse button is clicked and whether it hit GUI object
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            Vector3 mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseTarget, Vector2.zero);
            if (hit.collider && hit.transform.GetComponent<ItemGeneral>()) {
                ItemGeneral item = hit.transform.GetComponent<ItemGeneral>();
                if (item.text.text == item.description)
                {
                    MovePlayer(mouseTarget);
                    item.text.text = null;
                } else
                {
                    item.text.text = item.description;
                }
            } else {
                MovePlayer(mouseTarget);
            }
        }
	}

    private void MovePlayer (Vector3 mouseTarget) {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine(mouseTarget);
        StartCoroutine(moveCoroutine);

    }

	IEnumerator MoveCoroutine (Vector3 mouseTarget) {
		Vector2 target = new Vector2(mouseTarget.x, transform.position.y);
		while (Vector2.Distance(transform.position, target) > float.Epsilon) {
			transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
			yield return null;
		}
        CheckTargetItem(mouseTarget);
    }

    private void Flip() {

	}
}
