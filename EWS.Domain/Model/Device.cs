using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Core;

namespace EWS.Domain.Model
{
    public class Device : Entity<int>
    {
        public new int Id { get { return base.Id; } set { base.Id = value; } }
        public string Site { get; set; }
        public string Department { get; set; }
        public string Room { get; set; }
        public string Modality { get; set; }
        public string SubModality { get; set; }
        public string Supplier { get; set; }
        public string BrandModel { get; set; }
        public string DisplayName { get; set; }

        public Device()
        {

        }

        internal Device(int ID, string Site, string Department, string Room, 
                            string Modality, string SubModality, string Supplier,
                                string BrandModel, string Name)
        {
            if (ID == 0) throw new ArgumentNullException("Entity must have an id.");
            if (string.IsNullOrEmpty(Name)) throw new ArgumentNullException("Must have a Name");
            this.Id = ID;
            this.Site = Site;
            this.Department = Department;
            this.Room = Room;
            this.Modality = Modality;
            this.SubModality = SubModality;
            this.Supplier = Supplier;
            this.BrandModel = BrandModel;
            this.DisplayName = Name;
        }

    }
}
