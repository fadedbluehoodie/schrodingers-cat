using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform[] piecePrefabs;
    [SerializeField] private Button confirmButton; // Reference to the UI button

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;
    private bool puzzleCompleted = false;

    private void CreateGamePieces(float gapThickness)
    {
        //This is the width of each tile
        float width = 1f / size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piecePrefab = piecePrefabs[Random.Range(0, piecePrefabs.Length)]; // Randomly select a piece prefab
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                // Pieces will be in a game board going from -1 to +1
                piece.localPosition = new Vector3(-1f + (2f * width * col) + width,
                                                    1f - (2f * width * row) - width,
                                                    0f);
                piece.localScale = ((2f * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                // We want an empty Space in the bottom right.
                if ((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    //We want to map the UV coordinates appropriately they are 0-->1.
                    float gap = gapThickness / 2f;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    // UV Coord order: (0,1) (1,1) (0,0) (1,0)
                    uv[0] = new Vector2((width * col) + gap, 1f - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1f - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1f - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1f - ((width * row) + gap));
                    // Assign our new UVs to the mesh.
                    mesh.uv = uv;
                }
            }
        }
    }

    void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);

        // Add listener to the UI button
        confirmButton.onClick.AddListener(OnConfirmButtonClick);

        // Shuffle the puzzle automatically when the scene starts
        ShuffleAndCheck();
    }

    void Update()
    {
        if (!puzzleCompleted)
        {
            if (CheckCompletion())
            {
                puzzleCompleted = true;
            }
        }

        if (!puzzleCompleted)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    //Go through the list, the index tells us the position.
                    for (int i = 0; i < pieces.Count; i++)
                    {
                        if (pieces[i] == hit.transform)
                        {
                            // Check each direction to see if valid move.
                            // We break out on success so we don't carry on and swap back again.
                            if (SwapIfValid(i, -size, size)) { break; }
                            if (SwapIfValid(i, size, size)) { break; }
                            if (SwapIfValid(i, -1, i / size)) { break; }
                            if (SwapIfValid(i, 1, (i + 1) / size)) { break; }
                        }
                    }
                }
            }
        }
    }

    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }

    private void OnConfirmButtonClick()
    {
        if (puzzleCompleted)
        {
            SceneManager.LoadScene("Paiges");
        }
        else
        {
            Debug.Log("Puzzle is not completed yet!");
            // You can display a message to the player indicating that the puzzle is not complete
        }
    }

    private void ShuffleAndCheck()
    {
        StartCoroutine(ShuffleAndCheckCoroutine());
    }

    private IEnumerator ShuffleAndCheckCoroutine()
    {
        shuffling = true;
        yield return new WaitForSeconds(0.5f);
        Shuffle();
        yield return new WaitForSeconds(0.5f);
        puzzleCompleted = CheckCompletion();
        shuffling = false;
    }

    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while (count < (size * size * size))
        {
            int rnd = Random.Range(0, size * size);
            // Forbid undoing the last move
            if (rnd == last) { continue; }
            last = emptyLocation;
            if (SwapIfValid(rnd, -size, size)) { count++; }
            else if (SwapIfValid(rnd, size, size)) { count++; }
            else if (SwapIfValid(rnd, -1, 0)) { count++; }
            else if (SwapIfValid(rnd, 1, size - 1)) { count++; }
        }
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            // Swap them in game state.
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            // Swap their transforms
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);
            // Update empty location
            emptyLocation = i;
            return true;
        }
        return false;
    }
}
