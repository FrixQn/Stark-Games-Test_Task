using UnityEngine;

public class Border
{
    private Camera Camera;
    //
    private Vector3 LeftBorder;
    private Vector3 RightBorder;
    private Vector3 UpBorder;
    //
    public Vector3 Left {get => LeftBorder;}
    public Vector3 Right { get => RightBorder;}


    public Border(Camera camera, SpriteRenderer spriteRenderer)
    {
        if (camera.orthographic)
        {
            Camera = camera;
            Vector3 cameraPos = camera.transform.position;
            LeftBorder = cameraPos - new Vector3(camera.orthographicSize * (float)camera.pixelWidth / camera.pixelHeight, 0f ,0f) + spriteRenderer.bounds.extents;
            RightBorder = cameraPos + new Vector3(camera.orthographicSize * (float)camera.pixelWidth / camera.pixelHeight, 0f ,0f) - spriteRenderer.bounds.extents;
            UpBorder = cameraPos + new Vector3(0f, camera.orthographicSize, 0f);
        
        }
        else
        {
            throw new System.Exception("Camera othographic is false, please set camera othographic view");
        }
    }


    public Vector3 GetMouseScreenSide(Vector3 mouseWorldPosition)
    {
        if (mouseWorldPosition.x <= Camera.transform.position.x)
            return Vector3.left;
        else
            return Vector3.right;
    }

    public Vector3 GetRandomPosition()
    {
        float xPos = Random.Range(LeftBorder.x, RightBorder.x);
        float yPos = Random.Range(Camera.transform.position.y, UpBorder.y);

        return new Vector3(xPos, yPos);
    }
}

