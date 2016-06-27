using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class DevicesQuery : IQueryDefinition<IEnumerable<Domain.Model.Device>>
    {

        public int? roomID { get; set; }
        public int? deviceTypeID { get; set; }
        public Guid modalityID { get; set; }
        public Guid subModalityID { get; set; }
        public int? productLineID { get; set; }
    }

    public class DevicesQueryHandler : IQueryHandler<DevicesQuery, IEnumerable<Domain.Model.Device>>
    {
        private readonly IEntityReader _entities;

        public DevicesQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<Domain.Model.Device> Handle(DevicesQuery query)
        {
            IEnumerable<Device> devices = 
                _entities.Query<Device>()
                    .Where(p => (!query.roomID.HasValue || p.roomID == query.roomID ) &&
                                (!query.deviceTypeID.HasValue || p.deviceTypeID == query.deviceTypeID) &&
                                (query.modalityID == null || p.SubModality.ID == query.modalityID) &&
                                (query.subModalityID == null || p.submodalityID == query.subModalityID) &&
                                (!query.productLineID.HasValue || p.ProductLineID == query.productLineID)
                           ).AsEnumerable();

            List<Domain.Model.Device> models = new List<Domain.Model.Device>();
            foreach (Device device in devices)
            {
                Domain.Model.Device model = new Model.Device(device.ID,
                                                                device.SerialNo,
                                                                device.Room.Department.Site.SiteName,
                                                                device.Room.Department.HospitalDepartment.HospitalDepartmentName,
                                                                device.Room.RoomNo,
                                                                device.SubModality.Modality.ModalityName,
                                                                device.SubModality.Modality.ID,
                                                                device.SubModality.SubModalityName,
                                                                device.ProductLine.Supplier.SupplierName,
                                                                device.ProductLine.ProductLineName,
                                                                device.ProductLine.ProductLineName + " " + device.SerialNo

                                                                );
                models.Add(model);
            }

            return models;
        }
    }
}
