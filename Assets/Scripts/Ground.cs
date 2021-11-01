using UnityEngine;

public class Ground : MonoBehaviour
{
    public Vector3 Position => new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y,gameObject.transform.position.z);


}
