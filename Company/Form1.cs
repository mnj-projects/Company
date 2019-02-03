using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Company
{
    public partial class Form1 : Form
    {
        static int EmployeeCostControl = 0;

        public Form1()
        {
            InitializeComponent();
        }

        static void CostControl(TreeNode<EmployeeNode> employee)
        {
            //Add the salary of the considered employee
            if (EmployeeCostControl == 0)
            {
                EmployeeCostControl += employee.Data.Salary;
            }

            //If employee has no subordinates, stop there
            if (!employee.Children.Any())
            {
                return;
            }

            //Add the salary. Then recursively pass the employee to traverse through it's subordinates
            foreach (TreeNode<EmployeeNode> emp in employee.Children)
            {
                EmployeeCostControl += emp.Data.Salary;
                CostControl(emp);
            }
        }

        // The root node.
        private TreeNode<EmployeeNode> root =
            new TreeNode<EmployeeNode>(new EmployeeNode("Alazar", "CEO", 50000));

        // Make a tree.
        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode<EmployeeNode> marketingVP =
                new TreeNode<EmployeeNode>(new EmployeeNode("Thomas", "Marketing VP", 35000));
            TreeNode<EmployeeNode> productionVP =
                new TreeNode<EmployeeNode>(new EmployeeNode("Sarah", "Production VP", 35000));

            TreeNode<EmployeeNode> salesManager =
                new TreeNode<EmployeeNode>(new EmployeeNode("Daniel", "Sales Manager", 25000));
            TreeNode<EmployeeNode> marketingManager =
                new TreeNode<EmployeeNode>(new EmployeeNode("Solan", "Marketing Manager", 25000));

            TreeNode<EmployeeNode> productionManager =
                new TreeNode<EmployeeNode>(new EmployeeNode("Ammanuel", "Production Manager", 20000));
            TreeNode<EmployeeNode> shippingManager =
                new TreeNode<EmployeeNode>(new EmployeeNode("Rachel", "Shipping Manager", 20000));

            TreeNode<EmployeeNode> sales1 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Abebe", "Sales", 10000));
            TreeNode<EmployeeNode> sales2 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Berhan", "Sales", 10000));

            TreeNode<EmployeeNode> secretary1 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Dana", "Secretary", 10000));

            TreeNode<EmployeeNode> manufacturer1 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Abel", "Manufacturer", 10000));
            TreeNode<EmployeeNode> manufacturer2 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Tedla", "Manufacturer", 10000));
            TreeNode<EmployeeNode> manufacturer3 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Kalkidan", "Manufacturer", 10000));

            TreeNode<EmployeeNode> shipping1 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Mahlet", "Shipping", 10000));
            TreeNode<EmployeeNode> shipping2 =
                new TreeNode<EmployeeNode>(new EmployeeNode("Sophia", "Shipping", 10000));

            root.AddChild(marketingVP);
            root.AddChild(productionVP);

            marketingVP.AddChild(salesManager);
            marketingVP.AddChild(marketingManager);

            productionVP.AddChild(productionManager);
            productionVP.AddChild(shippingManager);

            salesManager.AddChild(sales1);
            salesManager.AddChild(sales2);

            marketingManager.AddChild(secretary1);

            productionManager.AddChild(manufacturer1);
            productionManager.AddChild(manufacturer2);
            productionManager.AddChild(manufacturer3);

            shippingManager.AddChild(shipping1);
            shippingManager.AddChild(shipping2);
            
            //CostControl(root);

            // Arrange the tree.
            ArrangeTree();
        }

        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        // Center the tree on the form.
        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }
        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            picTree.Refresh();
        }

        // The currently selected node.
        private TreeNode<EmployeeNode> SelectedNode;

        // Display the text of the node under the mouse.
        private void picTree_MouseMove(object sender, MouseEventArgs e)
        {
            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse, reset the CostControl Value
            if (SelectedNode == null)
            {
                EmployeeCostControl = 0;
            }
        }


        // If this is a right button down and the
        // mouse is over a node, display a context menu.
        private void picTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the context menu.
            if (SelectedNode != null)
            {
                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)
                ctxNodeDelete.Enabled = (SelectedNode != root);

                // Display the context menu.
                ctxNode.Show(this, e.Location);
            }
        }


        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }
        }

        // Add a child to the selected node.
        private void ctxNodeAddChild_Click(object sender, EventArgs e)
        {
            NodeTextDialog dlg = new NodeTextDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<EmployeeNode> child =
                    new TreeNode<EmployeeNode>(new EmployeeNode(dlg.txtName.Text, dlg.txtDepartment.Text, Convert.ToInt32(dlg.txtSalary.Text)));
                SelectedNode.AddChild(child);

                // Rearrange the tree to show the new node.
                ArrangeTree();
            }
        }

        // Delete this node from the tree.
        private void ctxNodeDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this node?",
                "Delete Node?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete the node and its subtree.
                root.DeleteNode(SelectedNode);

                // Rearrange the tree to show the new structure.
                ArrangeTree();
            }
        }

        private void picTree_Click(object sender, MouseEventArgs e)
        {
            //Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse, display it's cost control
            if (SelectedNode != null)
            {
                CostControl(SelectedNode);
                String info = $"Name: {SelectedNode.Data.Name}\nDepartment: {SelectedNode.Data.Department}\nSalary: {SelectedNode.Data.Salary}\nCost Control: {EmployeeCostControl}";
                lblNodeText.Text = info;
            }
            else
            {
                lblNodeText.Text = "";
            }

        }
    }
}
