using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using System;

public class BlockSpawn : MonoBehaviour {

    public GameObject[] blocks;

    // directional block arrays
    public GameObject[] rightBlocks;
    public GameObject[] upBlocks;
    public GameObject[] leftBlocks;
    public GameObject[] downBlocks;

    private Dictionary<Direction, GameObject[]> directionBlockMap;
    public Transform blockSpawnerPos;
    public int blockCount;
    public float newPosition = 5.0f;

    const float BLOCK_WIDTH = 5.0f;
    const float RANDOM_FACTOR = 0.1f;
    private const float RANDOM_BASE = 0.5f;
    private float flipFactor = RANDOM_BASE;
    private float waitTime = 0.1f;
    private GameObject block;
    public Direction currentDirection;
    const int CHANGE_DIRECTION_LIMIT = 5;
    public int changeDirection;
    public int currentBlockCount = 0;
    private System.Random rand = new System.Random();
	// Use this for initialization
	void Start () {
        directionBlockMap.Add(Direction.RIGHT, rightBlocks);
        directionBlockMap.Add(Direction.DOWN, downBlocks);
        directionBlockMap.Add(Direction.LEFT, leftBlocks);
        directionBlockMap.Add(Direction.UP, upBlocks);
        directionBlockMap.TryGetValue(currentDirection, out blocks);
        Block();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Block()
    {

        if(currentBlockCount == changeDirection)
        {
            Direction prevDirection = currentDirection;
            switch (currentDirection)
            {
                
                case Direction.RIGHT:
                    Direction[]  rightArray = { Direction.RIGHT, Direction.UP, Direction.DOWN};
                    currentDirection = rightArray[UnityEngine.Random.Range(0, 3)];
                    break;
                case Direction.UP:
                    Direction[] upArray = { Direction.UP, Direction.RIGHT, Direction.LEFT};
                    currentDirection = upArray[UnityEngine.Random.Range(0, 3)];
                    break;
                case Direction.LEFT:
                    Direction[] leftArray = { Direction.LEFT, Direction.UP, Direction.DOWN};
                    currentDirection = leftArray[UnityEngine.Random.Range(0, 3)];
                    break;
                case Direction.DOWN:
                    Direction[] downArray = { Direction.DOWN, Direction.RIGHT, Direction.LEFT};
                    currentDirection = downArray[UnityEngine.Random.Range(0, 3)];
                    break;
            }

            if (prevDirection.Equals(currentDirection))
            {
                bool shouldFlip = (rand.NextDouble() < flipFactor);
                if(shouldFlip)
                {
                    DirectionHandler.flip();
                    flipFactor = RANDOM_BASE;
                } else
                {
                    //didn't flip this time around, increase the factor and try again next decission tree
                    flipFactor += RANDOM_FACTOR;
                }
            } else {
                flipFactor = RANDOM_BASE; 
            }



            changeDirection = CHANGE_DIRECTION_LIMIT + UnityEngine.Random.Range(0, 5);
            currentBlockCount = 0;
            DirectionHandler.updateDirection(currentDirection);
            directionBlockMap.TryGetValue(currentDirection, out blocks);
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
        block = Instantiate(blocks[UnityEngine.Random.Range(0, 5)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
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


