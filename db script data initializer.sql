
DELETE FROM Tecmed_EWS..BrandModel

INSERT INTO Tecmed_EWS..Supplier
Select * FROM TecmedSpectrum..Suppliers


Delete FROM Tecmed_EWS..ProductLine
Set IDENTITY_INSERT Tecmed_EWS..ProductLine ON
INSERT INTO Tecmed_EWS..ProductLine (ID, supplierID, ProductLineName, Deleted)
Select * FROM TecmedSpectrum..ProductLines

Set IDENTITY_INSERT Tecmed_EWS..ProductLine OFF


INSERT INTO Tecmed_EWS..SubModality
Select * FROM TecmedSpectrum..SubModalities

Set IDENTITY_INSERT Tecmed_EWS..Device ON
INSERT INTO Tecmed_EWS..Device (ID, [roomID]
           ,[deviceTypeID]
           ,[submodalityID]
           ,[SerialNo]
           ,[CommissionedDate]
           ,[commissioningCertID]
           ,[FactoryShipmentFrom]
           ,[FactoryShipmentTo]
           ,[ProductLineID]
           ,[Deleted]
           ,[SalesLicenceNumber]
           ,[ModelNumber]
           ,[RadiationBoardSerialNumber]
           ,[SalesLicenceFileReferenceNumber]
           ,[EquipmentIDNumber]
           ,[RequiresIBQCTests])
Select * FROM TecmedSpectrum..Devices

Set IDENTITY_INSERT Tecmed_EWS..Device OFF






