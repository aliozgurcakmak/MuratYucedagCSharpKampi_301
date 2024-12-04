using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuratYucedagCSharpKampi_301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice).ToString() + " TL";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Cappadocia").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            lblTürkiyeCapacityAvg.Text = db.Location.Where(x=>x.LocationCountry=="Türkiye").Average(y => y.LocationCapacity).ToString();

            var romeGuideId=db.Location.Where(x=> x.LocationCity== "Rome-Florence").Select( y => y.GuideId).FirstOrDefault(); 
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==romeGuideId) .Select(y=>y.GuideName + " " + y.GuideSurname) .FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x=>x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x=>x.LocationCapacity == maxCapacity).Select(y=>y.LocationCity).FirstOrDefault().ToString();
       
            var maxPrice = db.Location.Max(y=>y.LocationPrice);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y=>y.LocationCity).FirstOrDefault().ToString();
      
           var guideIdByNameAysegülCinar = db.Guide.Where(x=>x.GuideName == "Ayşenur" &&  x.GuideSurname == "Çelik").Select(y=> y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameAysegülCinar).Count().ToString();
        }
    }
}
