sap.ui.define([
    "sap/ui/model/json/JSONModel",
    "sap/ui/Device"
],
    /**
     * provide app-view type models (as in the first "V" in MVVC)
     * 
     * @param {typeof sap.ui.model.json.JSONModel} JSONModel
     * @param {typeof sap.ui.Device} Device
     * 
     * @returns {Function} createDeviceModel() for providing runtime info for the device the UI5 app is running on
     */
    function (JSONModel, Device) {
        "use strict";

        return {
            createDeviceModel: function () {
                var oModel = new JSONModel(Device);
                oModel.setDefaultBindingMode("OneWay");
                return oModel;
            },
            createToDoModel: function () {
                var oModel = new JSONModel({
                    todo_list: [{
                        title: "Create a todo Video",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("07/21/2023"),
                        status: 0
                    }, {
                        title: "Create a rest api Video 2",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("06/22/2023"),
                        status: 0
                    }, {
                        title: "Create a rest api Video 1",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("05/21/2023"),
                        status: 0
                    }, {
                        title: "Create a json model Video",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("05/10/2023"),
                        status: 0
                    }, {
                        title: "Create a calculator Video",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("04/21/2023"),
                        status: 0
                    }, {
                        title: "Create a training Video",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("03/21/2023"),
                        status: 1
                    }, {
                        title: "Create a another training Video",
                        description: "Subscriber requested a new video. Implement it ASAP!!",
                        targetDate: new Date("02/21/2023"),
                        status: 1
                    }]
                });
                return oModel;
            }
        };
    });