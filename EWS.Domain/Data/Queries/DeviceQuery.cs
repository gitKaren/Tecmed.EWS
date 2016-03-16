using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class DeviceQuery : IQueryDefinition<Domain.Model.Device>
    {
        public int DeviceID { get; set; }
    }

    public class DeviceQueryHandler : IQueryHandler<DeviceQuery, Domain.Model.Device>
    {
        private readonly IEntityReader _entities;

        public DeviceQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Domain.Model.Device Handle(DeviceQuery query)
        {
            Device device = 
                _entities.Query<Device>()
                    .Where(p => p.ID == query.DeviceID ).Single<Device>();

       
                Domain.Model.Device model = new Model.Device(device.ID,
                                                                device.Room.Department.Site.SiteName,
                                                                device.Room.Department.HospitalDepartment.HospitalDepartmentName,
                                                                device.Room.RoomNo,
                                                                device.SubModality.Modality.ModalityName,
                                                                device.SubModality.SubModalityName,
                                                                device.ProductLine.supplierID,
                                                                device.ProductLine.ProductLineName,
                                                                device.ProductLine.ProductLineName + " " + device.SerialNo

                                                                );
               
            

            return model;
        }
    }
}
