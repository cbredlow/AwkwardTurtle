using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour {

    public GameObject[] blocks;
    public Transform blockSpawnerPos;
    public int blockCount;
    public float newPosition = 5.0f;

    const float BLOCK_WIDTH = 5.0f;
    private float waitTime = 0.1f;
    private GameObject block;
    public Direction currentDirection;
    const int CHANGE_DIRECTION_LIMIT = 5;
    public int changeDirection;
    public int currentBlockCount = 0;
	// Use this for initialization
	void Start () {
        Block();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Block()
    {

        if(currentBlockCount == changeDirection)
        {
            switch (currentDirection)
            {
                case Direction.RIGHT:
                    Direction[]  rightArray = { Direction.RIGHT, Direction.UP, Direction.DOWN};
                    currentDirection = rightArray[Random.Range(0, 3)];
                    break;
                case Direction.UP:
                    Direction[] upArray = { Direction.UP, Direction.RIGHT, Direction.LEFT};
                    currentDirection = upArray[Random.Range(0, 3)];
                    break;
                case Direction.LEFT:
                    Direction[] leftArray = { Direction.LEFT, Direction.UP, Direction.DOWN};
                    currentDirection = leftArray[Random.Range(0, 3)];
                    break;
                case Direction.DOWN:
                    Direction[] downArray = { Direction.DOWN, Direction.RIGHT, Direction.LEFT};
                    currentDirection = downArray[Random.Range(0, 3)];
                    break;
            }
            changeDirection = CHANGE_DIRECTION_LIMIT + Random.Range(0, 5);
            currentBlockCount = 0;
        }

        Vector3 temp = blockSpawnerPos.position;
        switch (currentDirection)
        {
            case Direction.RIGHT:
                temp.x += BLOCK_WIDTH;
                temp.y += 0;
                break;
            case Direction.UP:
                temp.x += 0;
                temp.y += BLOCK_WIDTH;
                break;
            case Direction.LEFT:
                temp.x -= BLOCK_WIDTH;
                temp.y += 0;
                break;
            case Direction.DOWN:
                temp.x += 0;
                temp.y -= BLOCK_WIDTH;
                break;  
        }
        

        blockSpawnerPos.position = temp;
        block = Instantiate(blocks[Random.Range(0, 5)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
        currentBlockCount++;
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        blockCount++;
        Block();
    }

    
}

public enum Direction
{
    RIGHT = 0,
    UP = 1,
    LEFT = 2,
    DOWN = 3
}

