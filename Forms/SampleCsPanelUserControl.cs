using System;
using System.Drawing;
using System.Windows.Forms;

namespace SampleCsWinForms.Forms
{
  /// <summary>
  /// This is the user control that is buried in the tabbed, docking panel.
  /// </summary>
  [System.Runtime.InteropServices.Guid("83D6FCC8-4F31-4AE3-BF60-C6528DB232D0")]
  public partial class SampleCsPanelUserControl : UserControl
  {
    /// <summary>
    /// Public constructor
    /// </summary>
    public SampleCsPanelUserControl()
    {
      InitializeComponent();
            SetTreeView();
      // Set the user control property on our plug-in
      SampleCsWinFormsPlugIn.Instance.PanelUserControl = this;

      // Create a visible changed event handler
      VisibleChanged += OnVisibleChanged;

      // Create a dispose event handler
      Disposed += OnUserControlDisposed;
    }

    void OnVisibleChanged(object sender, EventArgs e)
    {
      // TODO...
    }

    /// <summary>
    /// Occurs when the component is disposed by a call to the
    /// System.ComponentModel.Component.Dispose() method.
    /// </summary>
    void OnUserControlDisposed(object sender, EventArgs e)
    {
      // Clear the user control property on our plug-in
      SampleCsWinFormsPlugIn.Instance.PanelUserControl = null;
    }

    /// <summary>
    /// Returns the ID of this panel.
    /// </summary>
    public static Guid PanelId => typeof(SampleCsPanelUserControl).GUID;


        public void SetTreeView()
        {
            String currentPath = Environment.CurrentDirectory;
            String directoryPath = currentPath.Replace("bin", "resources\\");

            ImageList imgList = new ImageList();
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "workpiece.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "basePlanes.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "innerBasePlane.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "alongCurves.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "innerAlongCurve.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "tools.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "InnerTool.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "toolpath.png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "maketoolpath(toolpath).png"));
            imgList.Images.Add(Bitmap.FromFile(directoryPath + "alongCurve.png"));
            infoPanelTreeView.ImageList = imgList;

            TreeNode workPieceNode = new TreeNode("Work Piece", 0, 0);
            workPieceNode.ExpandAll();
            TreeNode workPieceChildNode = new TreeNode("piece", 0, 0);
            workPieceNode.Nodes.Add(workPieceChildNode);
            infoPanelTreeView.Nodes.Add(workPieceNode);

            TreeNode baseSurfaceNode = new TreeNode("Base Surface(Boundary)", 1, 1);
            baseSurfaceNode.ExpandAll();
            TreeNode baseSurfaceChildNode = new TreeNode("surface1", 2, 2);
            baseSurfaceNode.Nodes.Add(baseSurfaceChildNode);
            infoPanelTreeView.Nodes.Add(baseSurfaceNode);

            TreeNode alongCurveNode = new TreeNode("Along Curve", 3, 3);
            alongCurveNode.ExpandAll();
            TreeNode alongCurveChildNode1 = new TreeNode("curve1", 4, 4);
            TreeNode alongCurveChildNode2 = new TreeNode("curve2", 4, 4);
            alongCurveNode.Nodes.Add(alongCurveChildNode1);
            alongCurveNode.Nodes.Add(alongCurveChildNode2);
            infoPanelTreeView.Nodes.Add(alongCurveNode);

            TreeNode toolNode = new TreeNode("Tool", 5, 5);
            toolNode.ExpandAll();
            TreeNode toolChildNode1 = new TreeNode("tool1", 6, 6);
            TreeNode toolChildNode2 = new TreeNode("tool2", 6, 6);
            toolNode.Nodes.Add(toolChildNode1);
            toolNode.Nodes.Add(toolChildNode2);
            infoPanelTreeView.Nodes.Add(toolNode);

            TreeNode toolPathNode = new TreeNode("Tool Path", 7, 7);
            toolPathNode.ExpandAll();
            TreeNode toolPathChildNode1 = new TreeNode("Tool Path No.1", 8, 8);
            toolPathChildNode1.ExpandAll();
            TreeNode toolPathChildNode1StepOver = new TreeNode("Step Over : 1.2mm", 9, 9);
            TreeNode toolPathChildNode1Strategy = new TreeNode("Strategy Distance : 1mm", 9, 9);
            TreeNode toolPathChildNode1Safety = new TreeNode("Safety Distance : 30mm", 9, 9);
            TreeNode toolPathChildNode1Style = new TreeNode("Style : 1 Way", 9, 9);
            TreeNode toolPathChildNode1Contour = new TreeNode("Contour : TRUE", 9, 9);
            TreeNode toolPathChildNode1Angle = new TreeNode("Angle : 90˚", 9, 9);
            TreeNode toolPathChildNode1IncrementAngle = new TreeNode("Increment : 45˚", 9, 9);
            TreeNode toolPathChildNode1Link = new TreeNode("Link : skim", 9, 9);
            TreeNode toolPathChildNode1StartPoint = new TreeNode("Start Point : Right-Up", 9, 9);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1StepOver);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Strategy);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Safety);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Style);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Contour);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Angle);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1IncrementAngle);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1Link);
            toolPathChildNode1.Nodes.Add(toolPathChildNode1StartPoint);

            toolPathNode.Nodes.Add(toolPathChildNode1);
            infoPanelTreeView.Nodes.Add(toolPathNode);

            TreeNode toolPathChildNode2 = new TreeNode("Tool Path No.2", 8, 8);
            toolPathNode.Nodes.Add(toolPathChildNode2);

            dataGridView1.Rows.Add("surface 1");
            dataGridView2.Rows.Add("piece 1");
            dataGridView3.Rows.Add("curve 1");
            dataGridView3.Rows.Add("curve 2");
            dataGridView4.Rows.Add("tool 1");
            dataGridView4.Rows.Add("tool 2");
        }

        private void InfoPanelButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = true;
            setWorkPiecePanel.Visible = false;
            setBasePlanePanel.Visible = false;
            setAlongCurvePanel.Visible = false;
            setToolPanel.Visible = false;
            makeStrategyToolPathPanel.Visible = false;
        }

        private void SetWorkPieceButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = false;
            setWorkPiecePanel.Visible = true;
            setBasePlanePanel.Visible = false;
            setAlongCurvePanel.Visible = false;
            setToolPanel.Visible = false;
            makeStrategyToolPathPanel.Visible = false;
        }

        private void SetBasePlaneButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = false;
            setWorkPiecePanel.Visible = false;
            setBasePlanePanel.Visible = true;
            setAlongCurvePanel.Visible = false;
            setToolPanel.Visible = false;
            makeStrategyToolPathPanel.Visible = false;
        }

        private void SetAlongCurveButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = false;
            setWorkPiecePanel.Visible = false;
            setBasePlanePanel.Visible = false;
            setAlongCurvePanel.Visible = true;
            setToolPanel.Visible = false;
            makeStrategyToolPathPanel.Visible = false;
        }

        private void SetToolButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = false;
            setWorkPiecePanel.Visible = false;
            setBasePlanePanel.Visible = false;
            setAlongCurvePanel.Visible = false;
            setToolPanel.Visible = true;
            makeStrategyToolPathPanel.Visible = false;
        }

        private void MakeStrategyBoolPathButton_Click(object sender, EventArgs e)
        {
            infoPanelTreeView.Visible = false;
            setWorkPiecePanel.Visible = false;
            setBasePlanePanel.Visible = false;
            setAlongCurvePanel.Visible = false;
            setToolPanel.Visible = false;
            makeStrategyToolPathPanel.Visible = true;
        }
    }
}
