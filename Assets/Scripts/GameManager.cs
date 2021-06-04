using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public AudioSource music;
    public bool startPlaying;
    public static GameManager instance;
    public int currentScore;
    public int scorePerGood = 100;
    public int scorePerGreat = 200;
    public int scorePerPerfect = 300;
    public int comboTracker;

    public Text scoreText;
    public Text comboText;
    public GameObject hitEffect;
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    public GameObject leftNote;
    public GameObject downNote;
    public GameObject upNote;
    public GameObject rightNote;
    public GameObject holdLeftNote;
    public GameObject holdDownNote;
    public GameObject holdUpNote;
    public GameObject holdRightNote;

    public int totalNotes;
    public int normalHits;
    public int goodHits;
    public int perfectHits;
    public int missHits;
    public float beatTempo;

    public bool lcurrent;
    public bool ucurrent;
    public bool dcurrent;
    public bool rcurrent;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public float msPerBeat;
    public float bpm;
    public float scrollSpeed;
    public int yRes = Screen.height;
    public float unitsPerSec;
    public float spawnYCoord;
    public float sendEarlyTime;
    public float initialTimer;
    public bool musicStarted;

    public int spawnCounter;

    public int[] music1;
    public int[] music2;
    public int[] music3;
    public int[] music4;

    // Start is called before the first frame update
    void Start() {



        music1 = new int[] { 410, 771, 1132, 1494, 1855, 2036, 2217, 2397, 2578, 3301, 3301, 3663, 3663, 4024, 4385, 4385, 4747, 5108, 5108, 5470, 5831, 5831, 6193, 6554, 6554, 6916, 7277, 7277, 7638, 8000, 8000, 8361, 8723, 8723, 9084, 9084, 9446, 9446, 9807, 10169, 10169, 10530, 10891, 10891, 11253, 11614, 11614, 11976, 12337, 12337, 12699, 13060, 13060, 13422, 13783, 13783, 14144, 14506, 14506, 14867, 14867, 15229, 15590, 15952, 16313, 16313, 16675, 17036, 17397, 17759, 17759, 18120, 18482, 18843, 19205, 19205, 19566, 19928, 20289, 20650, 20650, 21012, 21373, 21735, 22096, 22096, 22458, 22819, 23181, 23542, 23542, 23903, 24265, 24626, 24988, 24988, 25349, 25711, 26072, 26434, 26434, 26614, 26795, 27156, 27337, 27518, 27879, 28060, 28241, 28602, 28873, 29144, 29325, 29506, 29687, 30048, 30229, 30409, 30771, 30952, 31132, 31313, 31494, 31765, 32036, 32217, 32217, 32397, 32578, 32940, 33120, 33301, 33663, 33843, 34024, 34385, 34656, 34928, 35108, 35289, 35470, 35831, 36012, 36193, 36554, 36916, 37277, 37638, 38000, 38361, 38723, 39084, 39446, 39446, 39807, 39807, 40169, 40169, 40891, 41253, 41614, 41885, 42156, 42337, 42699, 43060, 43331, 43602, 43783, 44144, 44506, 44777, 45048, 45229, 45590, 45952, 46313, 46494, 46675, 47036, 47397, 47669, 47940, 48120, 48482, 48843, 49114, 49385, 49566, 49928, 50289, 50560, 50831, 51012, 51373, 51735, 52096, 52458, 52458, 52819, 52819, 53181, 53542, 53542, 53903, 54265, 54265, 54626, 54988, 54988, 55349, 55711, 55711, 56072, 56434, 56434, 56795, 57156, 57518, 57879, 58241, 58241, 58602, 58602, 58964, 59325, 59325, 59687, 60048, 60048, 60409, 60771, 60771, 61132, 61494, 61494, 61855, 62217, 62217, 62578, 62940, 63301, 63663, 64024, 64024, 64385, 64747, 65108, 65470, 65650, 65831, 66012, 66193, 66554, 66916, 66916, 67277, 67277, 67638, 68000, 68000, 68361, 68723, 68723, 69084, 69446, 69446, 69807, 70169, 70169, 70530, 70891, 70891, 71253, 71614, 71614, 71976, 72337, 72337, 72699, 72699, 73060, 73060, 73422, 73783, 73783, 74144, 74506, 74506, 74867, 75229, 75229, 75590, 75952, 75952, 76313, 76675, 76675, 77036, 77397, 77397, 77759, 78120, 78120, 78482, 78843, 79205, 79566, 79928, 80289, 80650, 80831, 81012, 81193, 81373, 81735, 82096, 82458, 82819, 83181, 83542, 83723, 83903, 84084, 84265, 84626, 84988, 85349, 85711, 86072, 86434, 86614, 86795, 86976, 87156, 87518, 87879, 88241, 88602, 88964, 89325, 89506, 89687, 89867, 90048, 90048, 90409, 90771, 91042, 91313, 91494, 91855, 92217, 92488, 92759, 92940, 93301, 93663, 93934, 94205, 94385, 94747, 95108, 95470, 95650, 95831, 96193, 96554, 96825, 97096, 97277, 97638, 98000, 98271, 98542, 98723, 99084, 99446, 99717, 99988, 100169, 100530, 100891, 101253, 101614, 101614, 101976, 101976, 102337, 102699, 102699, 103060, 103422, 103422, 103783, 104144, 104144, 104506, 104867, 104867, 105229, 105590, 105590, 105952, 106313, 106675, 107036, 107397, 107397, 107759, 107759, 108120, 108482, 108482, 108843, 109205, 109205, 109566, 109928, 109928, 110289, 110650, 110650, 111012, 111373, 111373, 111735, 112096, 112458, 112819, 113181, 113181, 113542, 113903, 114265, 114626, 114807, 114988, 115169, 115349, 115711, 116072, 116072, 116434, 116434, 116795, 117156, 117156, 117518, 117879, 117879, 118241, 118602, 118602, 118964, 119325, 119325, 119687, 120048, 120048, 120409, 120771, 120771, 121132, 121494, 121494, 121855, 121855, 122217, 122217, 122578, 122940, 122940, 123301, 123663, 123663, 124024, 124385, 124385, 124747, 125108, 125108, 125470, 125831, 125831, 126193, 126554, 126554, 126916, 127277, 127277, 127638, 127638, 128000, 128361, 128723, 129084, 129446, 129807, 130169, 130530, 130891, 131253, 131614, 131976, 132337, 132699, 133060 };
        music2 = new int[] { 64, 448, 320, 192, 64, 448, 64, 448, 192, 64, 448, 192, 320, 64, 320, 448, 192, 64, 320, 448, 64, 192, 320, 192, 448, 64, 192, 320, 448, 64, 192, 320, 192, 448, 64, 448, 192, 320, 448, 64, 192, 320, 192, 448, 64, 320, 448, 192, 64, 320, 448, 192, 320, 64, 320, 448, 192, 64, 320, 192, 448, 64, 320, 448, 64, 320, 448, 192, 64, 192, 448, 320, 64, 192, 64, 320, 192, 448, 320, 64, 192, 320, 448, 64, 320, 448, 192, 64, 448, 192, 320, 448, 64, 320, 64, 448, 192, 320, 448, 64, 320, 192, 320, 448, 320, 192, 64, 448, 192, 320, 192, 64, 448, 320, 192, 64, 192, 320, 448, 64, 320, 448, 192, 320, 448, 64, 320, 192, 320, 448, 320, 192, 64, 448, 192, 320, 192, 64, 448, 320, 192, 64, 192, 320, 448, 64, 320, 192, 448, 64, 192, 320, 64, 448, 64, 448, 64, 448, 448, 448, 64, 192, 320, 64, 64, 448, 320, 192, 448, 448, 64, 192, 320, 64, 64, 448, 192, 320, 64, 64, 448, 320, 192, 448, 448, 64, 192, 320, 64, 64, 448, 320, 192, 448, 192, 320, 64, 320, 448, 64, 448, 192, 64, 448, 320, 64, 192, 448, 192, 320, 64, 320, 448, 192, 64, 448, 64, 192, 320, 448, 64, 192, 64, 448, 320, 64, 448, 192, 320, 448, 64, 192, 320, 448, 64, 192, 320, 64, 448, 448, 320, 192, 64, 320, 448, 192, 320, 448, 64, 320, 192, 448, 192, 64, 320, 448, 64, 320, 192, 320, 448, 64, 192, 320, 448, 64, 192, 320, 192, 448, 64, 320, 448, 192, 64, 448, 320, 64, 192, 64, 320, 192, 448, 320, 64, 192, 448, 192, 320, 64, 320, 448, 192, 64, 320, 448, 64, 192, 320, 64, 448, 192, 320, 448, 64, 192, 320, 448, 64, 448, 64, 320, 192, 448, 64, 192, 320, 448, 64, 448, 64, 192, 320, 448, 64, 192, 320, 448, 64, 448, 64, 320, 192, 448, 64, 192, 320, 448, 64, 320, 192, 448, 192, 448, 64, 192, 64, 448, 320, 192, 448, 448, 64, 192, 320, 64, 64, 448, 320, 192, 448, 448, 64, 320, 192, 448, 448, 64, 192, 320, 64, 64, 448, 320, 192, 448, 448, 64, 192, 320, 64, 320, 192, 448, 64, 192, 64, 448, 320, 64, 448, 192, 320, 448, 64, 192, 320, 448, 64, 192, 320, 64, 448, 448, 320, 192, 64, 320, 448, 64, 448, 192, 64, 448, 320, 64, 192, 448, 192, 320, 64, 320, 448, 192, 64, 448, 64, 192, 320, 448, 64, 192, 320, 192, 64, 448, 320, 64, 192, 320, 448, 64, 192, 192, 448, 320, 64, 192, 448, 192, 320, 64, 320, 448, 192, 64, 320, 448, 64, 192, 320, 64, 448, 192, 320, 448, 192, 448, 64, 320, 192, 320, 448, 64, 192, 320, 448, 64, 192, 320, 192, 448, 64, 320, 448, 192, 64, 448, 320, 64, 192, 320, 448, 64, 192, 320, 448, 320, 192, 64, 192, 448, 320, 192, 64, 192, 320, 448 };
        music3 = new int[] { 5, 128, 128, 128, 1, 1, 1, 1, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 1, 1, 128, 1, 128, 1, 1, 128, 1, 128, 1, 1, 1, 128, 128, 1, 1, 128, 1, 128, 1, 1, 1, 128, 128, 1, 1, 128, 1, 128, 1, 1, 128, 1, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 128, 128, 128, 1, 1, 1, 1, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 128, 128, 128, 1, 1, 128, 128, 128, 1, 1, 1, 1, 128, 128, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 128, 1, 1, 1, 1, 128, 1, 1, 1, 128, 1, 1, 1, 128, 1, 1, 1, };
        music4 = new int[] { 0, 1132, 1494, 1855, 0, 0, 0, 0, 2940, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15229, 15590, 0, 0, 16675, 0, 17036, 0, 0, 18120, 0, 18482, 0, 0, 0, 19566, 19928, 0, 0, 21012, 0, 21373, 0, 0, 0, 22458, 22819, 0, 0, 23903, 0, 24265, 0, 0, 25349, 0, 25711, 26072, 26434, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 36916, 37277, 37638, 38000, 0, 38723, 39084, 39446, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 51373, 51735, 52096, 52458, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 57156, 57518, 57879, 58241, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62940, 63301, 63663, 64024, 0, 0, 64747, 65108, 65470, 0, 0, 0, 0, 66554, 66916, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100530, 100891, 101253, 101614, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106313, 106675, 107036, 107397, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 112096, 112458, 112819, 113181, 0, 0, 113903, 114265, 114626, 0, 0, 0, 0, 115711, 116072, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 128000, 0, 0, 0, 0, 129446, 0, 0, 0, 130891, 0, 0, 0, 132337, 0, 0, 0, };

        instance = this;
        scoreText.text = "SCORE: 0";

        beatTempo = beatTempo / 60f;
        yRes = Screen.height;
        bpm = 60000 / msPerBeat;
        unitsPerSec = 10 * scrollSpeed * bpm / 288;

        sendEarlyTime = 10000 / unitsPerSec;
    }

    // Update is called once per frame
    void Update() {
        if (!startPlaying) {
            if (Input.anyKeyDown) {
                startPlaying = true;
                music.Stop();
                Invoke("playAudio", sendEarlyTime/1000f);
            }
        } else {
            if (!musicStarted) {
                initialTimer += Time.deltaTime;
                if(spawnCounter < music1.Length && music1[spawnCounter] < initialTimer * 1000) {
                    while (music1[spawnCounter] < initialTimer * 1000) {
                        genNote();
                        spawnCounter++;
                    }
                }
            } else {
                if (spawnCounter < music1.Length && music1[spawnCounter] < music.time * 1000 + sendEarlyTime) {
                    while (music1[spawnCounter] < music.time * 1000 + sendEarlyTime) {
                        genNote();
                        spawnCounter++;
                    }
                }
            }
            if (music.time >= music.clip.length && !resultsScreen.activeInHierarchy) {
                resultsScreen.SetActive(true);
                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missHits.ToString();

                float percentageScore = ((float)(normalHits + goodHits + perfectHits) / (normalHits + goodHits + perfectHits + missHits) * 100);
                percentHitText.text = percentageScore.ToString("F1") + "%";
                if(percentageScore == 0) {
                    rankText.text = "FFF";
                } else if (percentageScore < 30) {
                    rankText.text = "FF";
                } else if (percentageScore < 60) {
                    rankText.text = "F";
                } else if (percentageScore < 70) {
                    rankText.text = "D";
                } else if (percentageScore < 80) {
                    rankText.text = "C";
                } else if (percentageScore < 90) {
                    rankText.text = "B";
                } else if (percentageScore < 95) {
                    rankText.text = "A";
                } else if (percentageScore < 98) {
                    rankText.text = "S";
                } else if (percentageScore < 100) {
                    rankText.text = "SS";
                } else if (percentageScore == 100) {
                    rankText.text = "SSS";
                }
                finalScoreText.text = currentScore.ToString();
            }
        }

        updateCurrentNums();
    }

    void playAudio() {
        music.Play();
        musicStarted = true;
    }

    void genNote() {
        if (music2[spawnCounter] == 64) {
            Instantiate(leftNote, new Vector3(leftNote.transform.position.x, 10.0f, 0.0f), leftNote.transform.rotation);
            if (music3[spawnCounter] == 128) {
                int holdLength = (int)((music4[spawnCounter] - music1[spawnCounter]) / 1000.0 * unitsPerSec);
                for (int i = 0; i < holdLength; i++) {
                    Instantiate(holdLeftNote, new Vector3(leftNote.transform.position.x, 11.0f + i, 0.0f), leftNote.transform.rotation);
                }
            }
        } else if (music2[spawnCounter] == 192) {
            Instantiate(upNote, new Vector3(upNote.transform.position.x, 10.0f, 0.0f), upNote.transform.rotation);
            if (music3[spawnCounter] == 128) {
                int holdLength = (int)((music4[spawnCounter] - music1[spawnCounter]) / 1000.0 * unitsPerSec);
                for (int i = 0; i < holdLength; i++) {
                    Instantiate(holdUpNote, new Vector3(holdUpNote.transform.position.x, 11.0f + i, 0.0f), holdUpNote.transform.rotation);
                }
            }
        } else if (music2[spawnCounter] == 320) {
            Instantiate(downNote, new Vector3(downNote.transform.position.x, 10.0f, 0.0f), downNote.transform.rotation);
            if (music3[spawnCounter] == 128) {  
                int holdLength = (int)((music4[spawnCounter] - music1[spawnCounter]) / 1000.0 * unitsPerSec);
                for (int i = 0; i < holdLength; i++) {
                    Instantiate(holdDownNote, new Vector3(holdDownNote.transform.position.x, 11.0f + i, 0.0f), holdDownNote.transform.rotation);
                }
            }
        } else if (music2[spawnCounter] == 448) {
            Instantiate(rightNote, new Vector3(rightNote.transform.position.x, 10.0f, 0.0f), rightNote.transform.rotation);
            if (music3[spawnCounter] == 128) {
                int holdLength = (int)((music4[spawnCounter] - music1[spawnCounter]) / 1000.0 * unitsPerSec);
                for (int i = 0; i < holdLength; i++) {
                    Instantiate(holdRightNote, new Vector3(holdRightNote.transform.position.x, 11.0f + i, 0.0f), holdRightNote.transform.rotation);
                }
            }
        }
    }

    public void NoteHit() {
        comboTracker++;
        comboText.text = "COMBO: x" + comboTracker;
        scoreText.text = "SCORE: " + currentScore;
    }

    public void goodHit(float xPos) {
        var obj = Instantiate(hitEffect, new Vector3(xPos, 0.0f, 0.0f), hitEffect.transform.rotation);
        Destroy(obj, 0.3f);
        currentScore += scorePerGood;
        NoteHit();

        normalHits++;
    }
    public void greatHit(float xPos) {
        var obj = Instantiate(goodEffect, new Vector3(xPos, 0.0f, 0.0f), goodEffect.transform.rotation);
        Destroy(obj, 0.3f);
        currentScore += scorePerGreat;
        NoteHit();

        goodHits++;
    }
    public void perfectHit(float xPos) {
        var obj = Instantiate(perfectEffect, new Vector3(xPos, 0.0f, 0.0f), perfectEffect.transform.rotation);
        Destroy(obj, 0.3f);
        currentScore += scorePerPerfect;
        NoteHit();

        perfectHits++;
    }

    public void NoteMiss(float xPos) {
        var obj = Instantiate(missEffect, new Vector3(xPos, 0.0f, 0.0f), missEffect.transform.rotation);
        Destroy(obj, 0.3f);
        comboTracker = 0;
        comboText.text = "COMBO: x" + comboTracker;
        missHits++;
    }
    public void HoldHit(float xPos) {
        var obj = Instantiate(perfectEffect, new Vector3(xPos, 0.0f, 0.0f), missEffect.transform.rotation);
        Destroy(obj, 0.3f);
        currentScore += scorePerPerfect;
        NoteHit();

        perfectHits++;
    }

    public void updateCurrentNums() {
        if (!lcurrent) {
            lcurrent = true;
        }
        if(!ucurrent) {
            ucurrent = true;
        }
        if(!dcurrent) {
            dcurrent = true;
        }
        if(!rcurrent) {
            rcurrent = true;
        }
    }
}
