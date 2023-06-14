using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace LarkinTestTask_2_2
{
    public class StartMessage : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Text>().text = "Собирай сено и вози его на склад, \nне забывай заправляться ;)";
            DestroyAfter(6);
        }

        private async void DestroyAfter(int seconds)
        {
            await Task.Delay(seconds * 1000);
            Destroy(gameObject);
        }
    }
}