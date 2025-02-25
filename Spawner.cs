using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyArray;

    [Space(10)]
    [Header("Spawn Rate")]
    [SerializeField] float waitMin;
    [SerializeField] float waitMax;



    [Space(15)]
    [Header("Sheet stats required (DEBUGGING/CHECKING PURPOSES ONLY, DOES NOT DO ANYTHING)")]
    [SerializeField] int probSheetLength;
    [SerializeField] int probSheetAmmount;

    int[][] enemyProbabilitySheet;

    bool spawnRefreshed = true;

    void Start()
    {
        enemyProbabilitySheet = makeProbabilitySheet();
    }

    void Update()
    {
        if (spawnRefreshed)
        {
            spawnRefreshed = false;
            StartCoroutine(SpawnRefresh());

            Instantiate(enemyArray[generateEnemyIdxFromSheetIdx(generateEnemyProbabilityIndex(ScoreManager.score))]);

        }
    }


    int generateEnemyProbabilityIndex(int score)
    {
        if (score <= 30)
        {
            return 0;
        }
        if (score > 30 && score < 60)
        {
            return 1;
        }
        if (score > 60 && score<90)
        {
            return 2;
        }
        if (score > 90 && score < 150)
        {
            return 3;
        }
        if (score >150 && score < 190)
        {
            return 4;
        }
        if (score > 190 && score < 245)
        {
            return 5;
        }
        if (score > 245)
        {
            return 6;
        }


        return 2;
    }

    int generrateSheetIdx(int score)
    {
        return 1;
    }

    int generateEnemyIdxFromSheetIdx(int x)
    {
        int[] prob = enemyProbabilitySheet[x];
        int num = Random.Range(0,101);

        for(int i=0; i < prob.Length; i++)
        {
            if (num <= arraySummation(prob, i))
            {
                return i;
            }
        }


        Debug.LogError("For loop did not find any matches in generateEnemyFromSheet(int x)");
        return (prob.Length - 1);

    }

    int arraySummation(int[] arr, int idx)
    {
        int sum = 0;
        for(int i=0; i <= idx; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    int[][] makeProbabilitySheet()
    {
        int[] arr0 = new int[4] {100, 0, 0, 0};
        int[] arr1 = new int[4] { 70, 30, 0, 0 };
        int[] arr2 = new int[4] { 50, 50, 0, 0 };
        int[] arr3 = new int[4] { 40, 40, 20, 0 };
        int[] arr4 = new int[4] { 30, 30, 30, 10 };
        int[] arr5 = new int[4] { 20, 30, 30, 20 };
        int[] arr6 = new int[4] { 10, 30, 30, 30 };

        int[][] sheet = {arr0, arr1, arr2, arr3, arr4, arr5, arr6};

        //check if all arrays are valid
        for(int i=0; i < sheet.Length; i++)
        {
            if (sheet[i].Length != probSheetLength)
            {
                Debug.LogError("Probability #" + i + " length does not match with inspector-defined probSheetLength in Spawner.cs makeProbabilitySheet(). Error #1");
            }
        }

        if (sheet.Length != probSheetAmmount)
        {
            Debug.LogError("Probability sheet ammount does not match with inspector-defined probSheetAmmount in Spawner.cs makeProbabilitySheet(). Error #2");
        }

        return sheet;

    }

    IEnumerator SpawnRefresh()
    {
        yield return new WaitForSeconds(Random.Range(waitMin, waitMax/ScoreManager.calculateGTS(1, 3f, 1f)));
        spawnRefreshed = true;
    }
}
