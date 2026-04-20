using UnityEngine;

public class FixedBattlefieldLayoutController : MonoBehaviour
{
    [Header("Spawn Markers")]
    [SerializeField] private Transform teamASpawn01;
    [SerializeField] private Transform teamASpawn02;
    [SerializeField] private Transform teamBSpawn01;
    [SerializeField] private Transform teamBSpawn02;

    [Header("Cover Objects")]
    [SerializeField] private Transform coverLeftTop;
    [SerializeField] private Transform coverLeftBottom;
    [SerializeField] private Transform coverRightTop;
    [SerializeField] private Transform coverRightBottom;

    [Header("Layout Control")]
    [Tooltip("-1 = play할 때 랜덤 선택, 0 이상 = 해당 레이아웃 고정")]
    [SerializeField] private int forcedLayoutIndex = -1;

    private LayoutData[] layouts;

    private void Awake()
    {
        BuildLayouts();

        if (!ValidateReferences())
        {
            Debug.LogError("[FixedBattlefieldLayoutController] One or more Transform references are missing.");
            return;
        }

        int layoutIndex = forcedLayoutIndex >= 0
            ? Mathf.Clamp(forcedLayoutIndex, 0, layouts.Length - 1)
            : Random.Range(0, layouts.Length);

        ApplyLayout(layouts[layoutIndex]);
        Debug.Log("[FixedBattlefieldLayoutController] Applied layout index: " + layoutIndex);
    }

    private void BuildLayouts()
    {
        layouts = new LayoutData[]
        {
            new LayoutData(
                new Vector3(-8f, 3f, 0f),
                new Vector3(-8f, -3f, 0f),
                new Vector3(8f, 3f, 0f),
                new Vector3(8f, -3f, 0f),
                new Vector3(-3f, 2.5f, 0f),
                new Vector3(-3f, -2.5f, 0f),
                new Vector3(3f, 2.5f, 0f),
                new Vector3(3f, -2.5f, 0f)
            ),
            new LayoutData(
                new Vector3(-9f, 2.5f, 0f),
                new Vector3(-9f, -2.5f, 0f),
                new Vector3(9f, 2.5f, 0f),
                new Vector3(9f, -2.5f, 0f),
                new Vector3(-2f, 3.5f, 0f),
                new Vector3(-2f, -3.5f, 0f),
                new Vector3(2f, 3.5f, 0f),
                new Vector3(2f, -3.5f, 0f)
            ),
            new LayoutData(
                new Vector3(-8.5f, 4f, 0f),
                new Vector3(-7f, -2f, 0f),
                new Vector3(7f, 2f, 0f),
                new Vector3(8.5f, -4f, 0f),
                new Vector3(-4f, 1.5f, 0f),
                new Vector3(-2f, -4f, 0f),
                new Vector3(4f, 4f, 0f),
                new Vector3(2f, -1.5f, 0f)
            )
        };
    }

    private bool ValidateReferences()
    {
        return teamASpawn01 != null
            && teamASpawn02 != null
            && teamBSpawn01 != null
            && teamBSpawn02 != null
            && coverLeftTop != null
            && coverLeftBottom != null
            && coverRightTop != null
            && coverRightBottom != null;
    }

    private void ApplyLayout(LayoutData layout)
    {
        teamASpawn01.position = layout.teamASpawn01;
        teamASpawn02.position = layout.teamASpawn02;
        teamBSpawn01.position = layout.teamBSpawn01;
        teamBSpawn02.position = layout.teamBSpawn02;

        coverLeftTop.position = layout.coverLeftTop;
        coverLeftBottom.position = layout.coverLeftBottom;
        coverRightTop.position = layout.coverRightTop;
        coverRightBottom.position = layout.coverRightBottom;
    }

    private struct LayoutData
    {
        public readonly Vector3 teamASpawn01;
        public readonly Vector3 teamASpawn02;
        public readonly Vector3 teamBSpawn01;
        public readonly Vector3 teamBSpawn02;
        public readonly Vector3 coverLeftTop;
        public readonly Vector3 coverLeftBottom;
        public readonly Vector3 coverRightTop;
        public readonly Vector3 coverRightBottom;

        public LayoutData(
            Vector3 teamASpawn01,
            Vector3 teamASpawn02,
            Vector3 teamBSpawn01,
            Vector3 teamBSpawn02,
            Vector3 coverLeftTop,
            Vector3 coverLeftBottom,
            Vector3 coverRightTop,
            Vector3 coverRightBottom)
        {
            this.teamASpawn01 = teamASpawn01;
            this.teamASpawn02 = teamASpawn02;
            this.teamBSpawn01 = teamBSpawn01;
            this.teamBSpawn02 = teamBSpawn02;
            this.coverLeftTop = coverLeftTop;
            this.coverLeftBottom = coverLeftBottom;
            this.coverRightTop = coverRightTop;
            this.coverRightBottom = coverRightBottom;
        }
    }
}