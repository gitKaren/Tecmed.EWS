using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace EWS.Domain.Model
{
    public class Device : Entity<int>
    {
        public new int Id { get { return base.Id; } set { base.Id = value; } }

        public bool Selected { get; set; }

        [Display(Name="Serial No")]
        public string SerialNo { get; set; }

        public string Site { get; set; }
        public string Department { get; set; }
        public string Room { get; set; }
        public string Modality { get; set; }
        public string ModalityID { get; set; }

        public string SubModality { get; set; }
        public string Supplier { get; set; }

        public string BrandModel { get; set; }

        [Display(Name = "System")]
        public string DisplayName { get; set; }

        [Display(Name="SID No")]
        public string SID { get; set; }

        public Device()
        {

        }

        internal Device(int ID, string SerialNo, string Site, string Department, string Room, 
                            string Modality, string ModalityID, string SubModality, string Supplier,
                                string BrandModel, string Name)
        {
            if (ID == 0) throw new ArgumentNullException("Entity must have an id.");
            if (string.IsNullOrEmpty(Name)) throw new ArgumentNullException("Must have a Name");

            this.SerialNo = SerialNo;
            this.Id = ID;
            this.Site = Site;
            this.Department = Department;
            this.Room = Room;
            this.Modality = Modality;
            this.ModalityID = ModalityID;
            this.SubModality = SubModality;
            this.Supplier = Supplier;
            this.BrandModel = BrandModel;
            this.DisplayName = Name;
        }

    }
}
