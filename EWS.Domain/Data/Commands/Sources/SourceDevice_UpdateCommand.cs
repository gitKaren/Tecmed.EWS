﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceDeviceUpdateCommand : CommandWithIdDefinition<int>
    {
        public int roomID { get; set; }
        public int deviceTypeID { get; set; }
        public System.Guid submodalityID { get; set; }
        public string SerialNo { get; set; }
        public System.DateTime CommissionedDate { get; set; }
        public Nullable<System.Guid> commissioningCertID { get; set; }
        public Nullable<System.DateTime> FactoryShipmentFrom { get; set; }
        public Nullable<System.DateTime> FactoryShipmentTo { get; set; }
        public int ProductLineID { get; set; }
        public bool Deleted { get; set; }
        public string SalesLicenceNumber { get; set; }
        public string ModelNumber { get; set; }
        public string RadiationBoardSerialNumber { get; set; }
        public string SalesLicenceFileReferenceNumber { get; set; }
        public string EquipmentIDNumber { get; set; }
        public bool RequiresIBQCTests { get; set; }
    }

    public class SourceDeviceUpdateCommandHandler : ICommandHandler<SourceDeviceUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceDeviceUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceDeviceUpdateCommand command)
        {
            var entity = _entities.Get<Device>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Device()
                {
                    ID = command.Id,
                    CommissionedDate = command.CommissionedDate,
                    commissioningCertID = command.commissioningCertID,
                    deviceTypeID = command.deviceTypeID,
                    EquipmentIDNumber = command.EquipmentIDNumber,
                    FactoryShipmentFrom = command.FactoryShipmentFrom,
                    FactoryShipmentTo = command.FactoryShipmentTo,
                    ModelNumber = command.ModelNumber,
                    ProductLineID = command.ProductLineID,
                    RadiationBoardSerialNumber = command.RadiationBoardSerialNumber,
                    RequiresIBQCTests = command.RequiresIBQCTests,
                    roomID = command.roomID,
                    SalesLicenceFileReferenceNumber = command.SalesLicenceFileReferenceNumber,
                    SalesLicenceNumber = command.SalesLicenceNumber,
                    SerialNo = command.SerialNo,
                    submodalityID = command.submodalityID,

                    Deleted = command.Deleted
                };
                _entities.Create(entity);
            }
            else
            {
                entity.CommissionedDate = command.CommissionedDate;
                entity.commissioningCertID = command.commissioningCertID;
                entity.deviceTypeID = command.deviceTypeID;
                entity.EquipmentIDNumber = command.EquipmentIDNumber;
                entity.FactoryShipmentFrom = command.FactoryShipmentFrom;
                entity.FactoryShipmentTo = command.FactoryShipmentTo;
                entity.ModelNumber = command.ModelNumber;
                entity.ProductLineID = command.ProductLineID;
                entity.RadiationBoardSerialNumber = command.RadiationBoardSerialNumber;
                entity.RequiresIBQCTests = command.RequiresIBQCTests;
                entity.roomID = command.roomID;
                entity.SalesLicenceFileReferenceNumber = command.SalesLicenceFileReferenceNumber;
                entity.SalesLicenceNumber = command.SalesLicenceNumber;
                entity.SerialNo = command.SerialNo;
                entity.submodalityID = command.submodalityID;

                entity.Deleted = command.Deleted;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}