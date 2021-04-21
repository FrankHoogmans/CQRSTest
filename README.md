# CQRSTest
This is a small proof-of-concept repo for having a dynamic projection based query using automapper and mediatr.

# Explanation
The intention was to create a projection based variant of the GetById found in many repository examples.
Projection is used to only retrieve relevant fields from the database.
In addition, an additional mapping step is done in the RequestHandler to allow a developer to access AutoMapper features that are unsupported in the 'Projection' flow.

Relevant code:
- Request: [/Queries/DeviceGetByIdRequest.cs](https://github.com/FrankHoogmans/CQRSTest/blob/main/Queries/DeviceGetByIdRequest.cs)
- Request Handler: [/Queries/Handlers/DeviceGetByIdRequestHandler.cs](https://github.com/FrankHoogmans/CQRSTest/blob/main/Queries/Handlers/DeviceGetByIdRequestHandler.cs)
- ViewModel and mapping: [/ViewModels/SimpleDeviceViewModel.cs](https://github.com/FrankHoogmans/CQRSTest/blob/main/ViewModels/SimpleDeviceViewModel.cs)
- Execution of the Request: [/Controllers/HomeController.cs](https://github.com/FrankHoogmans/CQRSTest/blob/main/Controllers/HomeController.cs)

- Plumbing: [/Startup.cs](https://github.com/FrankHoogmans/CQRSTest/blob/main/Startup.cs)
