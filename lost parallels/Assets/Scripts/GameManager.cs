using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    public Boolean puzzle_solved = false;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;
    public bool solved = false;

    private void CreateGamePieces(float gapThickness)
    {
        //width of each tile
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                //pieces go from -1 to +1
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                    +1 - (2 * width * row) - width,
                    0);

                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";


                if ((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];

                    //uv coord order (0, 1), (1, 1), (0, 0), (1, 0)
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

                    mesh.uv = uv;
                }
            }

        }


    }

    // defines size and calls main create function
    void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
    }

    void Update()
    {
        //checks completion
        if (!shuffling && CheckCompletion())
        {
            puzzle_solved = true;
        }

        // on click sends out ray to select piece
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //go through list index tells us position
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                    {
                        //check each direction for valid move
                        // break on success so we dont carry on and swap back again.
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }
        }

        //creates game setup with size x size pieces

    }

    //colcheck used to stop horizontal moves wrapping
    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            // swap game state
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            // swap transform
            (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));

            emptyLocation = i;
            return true;
        }
        return false;
    }

    // names pieces in order to check completion
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

    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling = false;
    }

    // brute force shuffling
    private void Shuffle()
    {
        int count = 0;
        int last = emptyLocation; // Track the last empty space to avoid reversing the same move

        while (count < (size * size * size)) // Shuffle enough times based on board size
        {
            // Pick a random piece to try to move
            int rnd = UnityEngine.Random.Range(0, size * size);

            // Prevent the shuffle from reversing the previous move by checking last empty location
            if (rnd == last) continue;

            // Try all directions for valid swaps and increase count for each successful swap
            bool swapped = false;

            if (SwapIfValid(rnd, -size, size)) // Move piece down
            {
                swapped = true;
            }
            else if (SwapIfValid(rnd, +size, size)) // Move piece up
            {
                swapped = true;
            }
            else if (SwapIfValid(rnd, -1, 0)) // Move piece left
            {
                swapped = true;
            }
            else if (SwapIfValid(rnd, +1, size - 1)) // Move piece right
            {
                swapped = true;
            }

            // If a swap occurred, increment the count and update the last empty location
            if (swapped)
            {
                last = emptyLocation;
                count++;
            }
        }
    }

}