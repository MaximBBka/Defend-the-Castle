using UnityEngine;

public class HeroSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private GameObject[] heroes; // 0 - Rogue, 1 - Knight, 2 - Barbarian

    public void SpawnRogue()
    {
        if (MainUI.Instance.totalMoney >= 30f)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                if (spawnPos[i].GetComponent<ContainerPointForMove>().container == null)
                {
                    GameObject Rogue = Instantiate(heroes[0], spawnPos[i].transform);
                    MainUI.Instance.totalMoney -= 10;
                }
            }
        }
    }
    public void SpawnKnight()
    {
        if (MainUI.Instance.totalMoney >= 60f)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                if (spawnPos[i].GetComponent<ContainerPointForMove>().container == null)
                {
                    GameObject Knight = Instantiate(heroes[1], spawnPos[i].transform);
                    MainUI.Instance.totalMoney -= 20;
                }
            }
        }
    }
    public void SpawnBarbarian()
    {
        if (MainUI.Instance.totalMoney >= 90f)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                if (spawnPos[i].GetComponent<ContainerPointForMove>().container == null)
                {
                    GameObject Rogue = Instantiate(heroes[2], spawnPos[i].transform);
                    MainUI.Instance.totalMoney -= 30;
                }
            }
        }
    }
}
