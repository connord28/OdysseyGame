using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class TypingGame : MonoBehaviour
{
    [SerializeField] List<GameObject> spawns;
    [SerializeField] Queue<GameObject> suitors;
    [SerializeField] GameObject suitorPrefab;
    /*[SerializeField] float maxScale;
    [SerializeField] float increment;*/
    [SerializeField] List<Image> hearts;
    [SerializeField] GameObject endscreen;

    private GameObject target;
    private string targetName;
    private Stack<string> nameStack;
    private int currCorrect = 0;
    private bool[] inUse;
    private int health = 3;
    private string[] names = {"Zeus", "Hades", "Ares", "Hermes", "Hera", "Poisidon", "Apollo", "Demeter" }; //change these to be names of suitors

    private void shuffle(string[] arr)
    {
        int n = arr.Length;
        System.Random random = new System.Random();
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + random.Next(n - i);
            string s = arr[r];
            arr[r] = arr[i];
            arr[i] = s;
        }
    }

    void Start()
    {
        suitors = new Queue<GameObject>();
        shuffle(names);
        nameStack = new Stack<string>();
        for(int i = 0; i < 8; i++)
        {
            nameStack.Push(names[i]);
        }
        inUse = new bool[spawns.Count];
        StartCoroutine(Game());
    }

    public IEnumerator Game()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(4f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(3f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(2f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(2f);
        StartCoroutine(spawnSuitor());
        yield return StartCoroutine(spawnSuitor());
        yield return new WaitForSeconds(1.5f);
        target = null;
        targetName = "";
        endscreen.GetComponentInChildren<Text>().text = "You Win";
        endscreen.SetActive(true);
        yield break;
    }

    public IEnumerator spawnSuitor()
    {
        int rand = Random.Range(0, spawns.Count);
        while (inUse[rand] == true)
        {
            rand = Random.Range(0, spawns.Count);
            yield return null;
        }
        inUse[rand] = true;
        Transform pos = spawns[rand].transform;
        GameObject suitor = Instantiate(suitorPrefab, pos);
        suitor.GetComponentInChildren<TMP_Text>().text = nameStack.Pop();
        suitors.Enqueue(suitor);
        if (suitors.Count == 1)
        {
            currCorrect = 0;
            target = suitors.Peek();
            target.GetComponentInChildren<TMP_Text>().color = Color.red;
            targetName = target.GetComponentInChildren<TMP_Text>().text;
            Debug.Log("Initializing   " + targetName);
            Debug.Log(target.GetComponentInChildren<TMP_Text>().text);
        }
        suitor.GetComponent<Animator>().Play("approach");
        yield return new WaitForSeconds(4f);
        if(suitor)
        {
            suitors.Dequeue();
            GameObject.Destroy(suitor);
            currCorrect = 0;
            Debug.Log("Destroying   " + targetName);
            if (suitors.Count > 0)
            {
                
                target = suitors.Peek();
                target.GetComponentInChildren<TMP_Text>().color = Color.red;
                targetName = target.GetComponentInChildren<TMP_Text>().text;
                Debug.Log("New Target   " + targetName);
            }
            else
            {
                target = null;
                targetName = "";
                Debug.Log("target is Null");
            }
            takeDamage();
            
        }
        inUse[rand] = false;
        yield break;
    }

    private void takeDamage()
    {
        health -= 1;
        hearts[health].color = Color.black;
        if(health == 0)
        {
            StopAllCoroutines();
            foreach (GameObject s in suitors) {
                s.GetComponent<Animator>().speed = 0;
                //GameObject.Destroy(s);
            }
            target = null;
            targetName = "";
            endscreen.SetActive(true);
        }
    }


    public void DestroySuitor(GameObject suitor, int rand)
    {
        GameObject.Destroy(suitor);
        inUse[rand] = false;
    }

    protected void OnEnable()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }

    protected void OnDisable()
    {
        Keyboard.current.onTextInput -= OnTextInput;
    }

    
    private void OnTextInput(char ch)
    {
        if(target != null && targetName.Length > 0)
        {
            if (char.ToUpper(ch) == char.ToUpper(targetName[currCorrect]))
            {
                Debug.Log(targetName);
                currCorrect++;
                target.GetComponentInChildren<TMP_Text>().text = "<color=#FFFFFF>" + targetName.Substring(0, currCorrect) + "</color>" + targetName.Substring(currCorrect, targetName.Length - currCorrect);
                if(currCorrect >= targetName.Length)
                {
                    GameObject temp2 = suitors.Peek();
                    suitors.Dequeue();
                    GameObject.Destroy(temp2);
                    currCorrect = 0;
                    if (suitors.Count > 0)
                    {
                        target = suitors.Peek();
                        target.GetComponentInChildren<TMP_Text>().color = Color.red;
                        targetName = target.GetComponentInChildren<TMP_Text>().text;
                    }
                    else
                    {
                        target = null;
                    }
                }
            }
            else
            {
                target.GetComponentInChildren<TMP_Text>().text = targetName;
                Debug.Log("FAIL   " + targetName);
                currCorrect = 0;
            }
        }
    }
}
