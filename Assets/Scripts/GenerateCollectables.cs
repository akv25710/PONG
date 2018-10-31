using UnityEngine;

public class GenerateCollectables : MonoBehaviour
{
    public GameObject Collectables;

    private int level;
    private int[] quantity = { 200, 300, 400, 500, 600 };

	void Start () {
        Generate();
	}
	
    public int[] GetQuantity()
    {
        return quantity;
    }
	
    public void Generate()
    {
        level = BallController.level;
        float y = 8.0f;
        for (int i = 0; i < quantity[level]; i++)
        {
            float xRange = Random.Range(6.0f, 13.0f);
            float xPos = -xRange;
            while (i < quantity[level] && xPos < xRange)
            {
                Instantiate(Collectables, new Vector3(xPos, y, 0), Quaternion.identity);
                i++;
                xPos += 0.5f;

            }
            y -= 0.5f;
        }

    }
}

