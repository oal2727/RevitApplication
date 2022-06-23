using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AppExternalUIForm
{
    public partial class ExampleForm : System.Windows.Forms.Form
    {
        Document Doc; 
        public ExampleForm(Document doc)
        {
            InitializeComponent();
            Doc = doc;
        }

        private void ExampleForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ICollection<Element> walls = new FilteredElementCollector(Doc)
                           .OfCategory(BuiltInCategory.OST_Walls).ToElements();

            MessageBox.Show("Total Walls " + walls.Count.ToString());
        }
    }
}
