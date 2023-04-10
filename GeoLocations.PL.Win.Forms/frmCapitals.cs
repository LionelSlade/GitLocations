using GeoLocations.Net.BL.DAO;
using GeoLocations.Net.BL.Enums;
using GeoLocations.Net.BL.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeoLocations.PL.Win.Forms
{
    public partial class frmCapitals : Form
    {
        private List<Capitals.Root> Capitals { get; set; }
        private string CurrentQuestion { get; set; }

        public frmCapitals()
        {
            InitializeComponent();
        }

        private void frmCapitals_Load(object sender, EventArgs e)
        {
            //load capitals
            if (Capitals == null) { var cJsonObjects = new CreateJsonObjects(enumJsonFileType.Capitals); Capitals = cJsonObjects.CapitalsObject; }
            if (CurrentQuestion == null) { SetCurrentQuestion(); }


        }

        private void SetCurrentQuestion()
        {
            var rnd = new Random();
            int cIndex = rnd.Next(Capitals.Count);
            var root = Capitals[cIndex];
            CurrentQuestion = root.name.ToString();
            lblQuizQuestionHolder.Text = CurrentQuestion + "?";


        }
    }
}
