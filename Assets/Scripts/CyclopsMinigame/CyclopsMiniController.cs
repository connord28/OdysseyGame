using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CyclopsMiniController : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] Text instructions;
    [SerializeField] List<GameObject> sheepList;
    [SerializeField] GameObject cyclops;
    //[SerializeField] Camera camera;
    //[SerializeField] GameObject canvas;
    [SerializeField] GameObject endScreen;
    [SerializeField] Text endText;

    [SerializeField] Sprite grabSprite;
    [SerializeField] Sprite handSprite;

    [SerializeField] List<GameObject> locations;
    private int currLocation;

    private bool flag;
    private GameObject currSheep;
    private GameObject targetSheep;
    private Vector3 cyclopsVector;
    private Vector3 target;
    private enum Phases { SetUp, Player, CyclopsSearch, CyclopsGrab, Win, Loss};
    private Phases phase = Phases.SetUp;
    private int turn = 0;

    //get rid of this later 
    private Color sheepColor;

    // Start is called before the first frame update
    void Start()
    {
        sheepColor = sheepList[0].GetComponent<Button>().colors.disabledColor;
        flag = false;
        currLocation = 0;
        phase = Phases.Player;
        foreach (GameObject sheep in sheepList)
        {
            sheep.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step;
        switch (phase)
        {
            case Phases.Player:
                break;
            case Phases.CyclopsSearch:
                //cyclops.transform.position += cyclopsVector;
                //Vector3 temp;
                //RectTransformUtility.ScreenPointToLocalPointInRectangle(cyclops.GetComponent<RectTransform>(), cyclopsVector, camera, out temp);
                //RectTransformUtility.ScreenPointToWorldPointInRectangle(cyclops.GetComponent<RectTransform>(), cyclops.transform.position + cyclopsVector, camera, out temp);
                //temp = Camera.main.ScreenToWorldPoint(cyclops.transform.position);
                //temp += cyclopsVector;
                //cyclops.transform.position = Camera.main.WorldToScreenPoint(temp);
                // temp = temp.normalized;
                //Debug.Log(temp);
                //cyclops.transform.position += new Vector3(temp.x, temp.y, 0);
                // Debug.Log(cyclopsVector);
                //RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), cyclopsVector, camera, out temp);
                //Debug.Log(temp);
                //cyclops.transform.localPosition += cyclopsVector;
                //Debug.Log(cyclops.transform.localPosition);
                step = 350 * Time.deltaTime;
                cyclops.transform.localPosition = Vector3.MoveTowards(cyclops.transform.localPosition, locations[currLocation].transform.localPosition, step);
                break;
            case Phases.CyclopsGrab:
                step = 400 * Time.deltaTime;
                cyclops.transform.localPosition = Vector3.MoveTowards(cyclops.transform.localPosition, target, step);
                if(cyclops.transform.localPosition == target && flag)
                {
                    flag = false;
                    sheepList.Remove(targetSheep);
                    targetSheep.SetActive(false);
                    turn++;
                    StartCoroutine(EndCyclopsTurn());
                }
                break;
        }
    }

    public IEnumerator PlayerTurnEnd()
    {
        yield return new WaitForSeconds(.5f);
        instructions.text = "The Cyclops is coming";
        yield return new WaitForSeconds(2f);
        textBox.SetActive(false);
        currLocation = 0;
        phase = Phases.CyclopsSearch;
        StartCoroutine(CyclopsSearch());
    }

    public IEnumerator CyclopsSearch()
    {
        //float moveY = 7f;
        //float moveX = 7f;
        //cyclopsVector = new Vector3(0, -moveY, 0);
        yield return new WaitForSeconds(1.5f);
        //cyclopsVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.3f);
        currLocation++;
        //cyclopsVector = new Vector3(moveX, 0, 0);
        yield return new WaitForSeconds(1.5f);
        //cyclopsVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.3f);
        //cyclopsVector = new Vector3(0, moveY, 0);
        currLocation++;
        yield return new WaitForSeconds(.8f);
        //cyclopsVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.3f);
        //cyclopsVector = new Vector3(-moveX, 0, 0);
        currLocation++;
        yield return new WaitForSeconds(1f);
        //cyclopsVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.3f);
        currLocation++;
        //cyclopsVector = new Vector3(0, -moveY, 0);
        yield return new WaitForSeconds(.7f);
        cyclopsVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.7f);
        phase = Phases.CyclopsGrab;
        //StartCoroutine(CyclopsGrab());
        int rand = Random.Range(0, sheepList.Count);
        //Debug.Log(rand);
        targetSheep = sheepList[rand];
        target = targetSheep.transform.localPosition;
        flag = true;
        //Debug.Log(cyclops.transform.position);
        //Debug.Log(target);
        //Debug.Log(cyclopsVector + cyclops.transform.position);*/
    }
    public IEnumerator EndCyclopsTurn()
    {
        yield return new WaitForSeconds(.5f);
        cyclops.GetComponent<Image>().sprite = grabSprite;
        yield return new WaitForSeconds(.3f);
        target = new Vector3(-250, 389, 0);
        yield return new WaitForSeconds(2.3f);
        cyclops.GetComponent<Image>().sprite = handSprite;
        if (currSheep == targetSheep)
        {
            phase = Phases.Loss;
            endText.text = "You Lose";
            endScreen.SetActive(true);
            yield break;
        }
        if (turn == 3) //probably need to fix this
        {
            int rand = Random.Range(0, sheepList.Count);
            targetSheep = sheepList[rand];
            target = targetSheep.transform.localPosition;
            yield return new WaitForSeconds(1.5f);
            cyclops.GetComponent<Image>().sprite = grabSprite;
            yield return new WaitForSeconds(1f);
            sheepList.Remove(targetSheep);
            targetSheep.SetActive(false);
            target = new Vector3(-250, 389, 0);
            yield return new WaitForSeconds(2f);
            cyclops.GetComponent<Image>().sprite = handSprite;
            if (currSheep == targetSheep)
            {
                phase = Phases.Loss;
                endText.text = "You Lose";
                endScreen.SetActive(true);
                yield break;
            }
            else
            {
                phase = Phases.Win;
                endText.text = "You Win";
                endScreen.SetActive(true);
                yield break;
            }
        }
        else
        {
            phase = Phases.Player;
            Debug.Log("enabled"); 
            foreach (GameObject sheep in sheepList)
            {
                sheep.GetComponent<Button>().interactable = true;
            }
            instructions.text = "Choose a sheep to hide under";
            textBox.SetActive(true);
        }
    }

    public void SelectSheep(GameObject sheep)
    {
        Debug.Log("Test0");
        var newColorBlock = sheepList[0].GetComponent<Button>().colors;
        newColorBlock.disabledColor = sheepColor;
        Debug.Log("Test1");
        if (currSheep != null)
            currSheep.GetComponent<Button>().colors = newColorBlock;
        Debug.Log("Test2");
        currSheep = sheep;
        Color c = new Color(178/255f, 178/255f, 178/255f);
        newColorBlock.disabledColor = c;
        currSheep.GetComponent<Button>().colors = newColorBlock;
        Debug.Log("disabled");
        //need to add changing the disabled sprite of the selected sheep
        foreach (GameObject s in sheepList)
        {
            s.GetComponent<Button>().interactable = false;
        }
        StartCoroutine(PlayerTurnEnd());
    }
}
