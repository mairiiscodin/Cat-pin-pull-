using UnityEngine;

public class pinScript : MonoBehaviour
{
    [Header("Handle")]
    public Transform handle;          // Chuôi pin
    public Transform body;
    public float handleRadius = 0.3f; // Bán kính vùng click

    [Header("Pull Settings")]
    public float maxPullDistance = 2f;

    private Vector3 startPos;
    private bool canDrag = false;
    private bool released = false;

    void Start()
    {
        startPos = body.position;
    }

    void OnMouseDown()
    {
        if (released) return;

        Vector3 mouseWorld = GetMouseWorldPos();

        // Kiểm tra click có nằm trong vùng handle không
        float dist = Vector2.Distance(mouseWorld, handle.position);
        if (dist <= handleRadius)
        {
            canDrag = true;
        }
    }

    void OnMouseDrag()
    {
        if (!canDrag || released) return;

        Vector3 mouseWorld = GetMouseWorldPos();

        // Phương pin = từ thân pin → chuôi handle
        Vector3 pinDir = (handle.position - startPos).normalized;

        // Vector từ pin tới chuột
        Vector3 toMouse = mouseWorld - startPos;

        // Chiếu chuột lên phương pin
        float pullAmount = Vector3.Dot(toMouse, pinDir);

        // Giới hạn kéo
        pullAmount = Mathf.Clamp(pullAmount, 0, maxPullDistance);

        // Di chuyển pin
        transform.position = startPos + pinDir * pullAmount;
    }

    void OnMouseUp()
    {
        if (!canDrag || released) return;

        float pulledDistance = Vector3.Distance(transform.position, startPos);

        // Kéo đủ → pin biến mất
        if (pulledDistance >= maxPullDistance * 0.95f)
        {
            released = true;

            // Tắt collider trước (an toàn cho vật lý)
            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            Destroy(gameObject);
        }

        canDrag = false;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        return pos;
    }

    void OnDrawGizmos()
    {
        if (handle != null)
        {
            // Vẽ vùng click handle
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(handle.position, handleRadius);

            // Vẽ phương pin
            Gizmos.color = Color.red;
            Vector3 dir = (handle.position - body.position).normalized;
            Gizmos.DrawLine(body.position, body.position + dir * maxPullDistance);
        }
    }
}
